#include <C:\Users\USER\AppData\Local\Arduino15\packages\esp32\hardware\esp32\1.0.6\libraries\SD\src\SD.h>
#include <sd_defines.h>
#include <sd_diskio.h>
#include <SPI.h>
//引入函式庫
#include <WiFi.h>
#include <esp_now.h>
#include <esp_wifi.h>


// 預設SD卡和Arduino板溝通用的pin
// CS: Chip Select pin
#define CSpin 5
//固定變數
#define NUMSLAVES 20
#define CHANNEL 0
#define PRINTSCANRESULTS 0

//ESP32掃描
esp_now_peer_info_t peerInfo[NUMSLAVES] = {};
int SlaveCnt = 0;

//從esp32那接到訊號
int stage = 0;

int number;
//設置變數
#define board_number 1

// 可手動更換讀檔檔名(Default: data.csv)
const String filename = "/stage_";
int file_num = 2;

// 宣告dataFile物件(用於讀檔,尚未初始化)
File dataFile;

// 用來計時的,當作開始的時間點,用來算出當下經過的時間
unsigned long startTime;

// 讀取的字串
String line;
String buffer = "";
// 讀取的index
int idx = 0;
// 讀取的時間軸
int T = 0;
// 讀取到的參數
String op[2];

// 判斷是否繼續讀取
bool reading = true;

typedef struct struct_message {
  String data_number;
  String board_name;

} struct_message;
struct_message myData[20];
struct_message database;

const byte light[7][2] = {
  { 13, 12 },
  { 14, 27 },
  { 26, 25 },
  { 33, 32 },
  { 15, 2 },
  { 0, 4 },
  { 16, 17 }
};

void setup() {
  Serial.begin(115200);
  // 設定開始時間, 每次setup()重新初始化

  // pinMode setup
  for (int i = 0; i < 7; i++) {
    pinMode(light[i][0], OUTPUT);
    pinMode(light[i][1], OUTPUT);
  }
  for (int i = 0; i < 7; i++) {
    digitalWrite(light[i][0], 0);
    digitalWrite(light[i][1], 0);
  }


  // 檢查是否CS pin有接到SD卡
  if (SD.begin(CSpin) == false) {
    Serial.println("[Error] Unable to initialize SD card");
    return;
  } else {
    Serial.println("[Success] SD card initialize done");
  }

  for (int i = 1; i <= file_num; i++) {
    String stage_filename = filename + String(i) + ".csv";
    // 檢查檔名是否有對應檔案
    if (SD.exists(stage_filename) == false) {
      Serial.println("[Error] File: " + stage_filename + " not exist");
      //return;
    } else {
      Serial.println("[Success] File: " + stage_filename + " is available");
    }
  }

  //設定wifi
  configDeviceAP();
  WiFi.mode(WIFI_AP_STA);
  InitESPNow();
  delay(10);
  // 設定接收資料回撥函式
  esp_now_register_recv_cb(OnDataRecv);

  myData[board_number].data_number = "0";
  number = 1;
  myData[board_number].board_name = "WiFi_#" + String(board_number);
}

void loop() {
  vTaskDelay(10 / portTICK_PERIOD_MS);  // 延遲1000ms
  if (stage != 0) {
    // 檢查檔案是否能正常開啟讀取
    String stage_filename = filename + String(stage) + ".csv";
    dataFile = SD.open(stage_filename);
    if (dataFile == false) {
      Serial.println("[Error] Failed to open " + stage_filename);
      return;
    } else {
      Serial.println("[Success] File: " + stage_filename + " opened successfully");
    }
    // 印出檢查完畢開始讀檔操控LED
    Serial.println("[Done] All check up good!");
    startTime = millis();  // 接收wifi訊號之後，設定startTime
    reading = true;        // 預設直接開始讀取
    // 開始讀取檔案內容(一次讀完)
    // 預設檔案室依時間順序排序 所以逐行讀檔
    while (dataFile.available()) {
      // 中斷讀取
      if (stage == 0) {
        Serial.println("stop");
        break;
      }
      // 因為SD Library依賴於Stream Library
      // 所以利用Stream內建的讀字串函式
      if (reading) {
        Serial.print("Step1: reading? ");
        Serial.println(reading);
        line = dataFile.readStringUntil('\n');
        // 結束讀檔
        if (line == "End File") {
          Serial.println("Command:End File");
          stage = 0;
          break;
        }
      }
      unsigned long elapsedTime = getElapsedTime();
      /*
      開始讀取檔案內容
      如果時間對不上, break while-loop, 等下一輪loop再次檢查
      如果時間對上, 繼續一直讀下去, 直到時間對不上
      (時間對上者, 呼叫LED_Control library的函式)
      */
      // 讀取執行時間
      for (idx = 0; line[idx] != ','; idx++) {
        buffer += line[idx];
      }
      T = buffer.toInt();  //讀取執行時間
      buffer = "";
      if (T > elapsedTime)  // 時間對不上
      {
        reading = false;  // 暫停不繼續讀取
      } else {
        reading = true;  //執行完這一行，繼續讀取
        idx++;           //buffer_index前進
        // debug
        Serial.print("Time:");
        Serial.print(elapsedTime);
        Serial.print(" ,Command:");
        Serial.println(line);

        Serial.println("Step2: read parameter");
        int info = 0;  // 目前讀到第幾個參數
        for (idx; idx < line.length(); idx++) {
          if (line[idx] == ',') {
            op[info] = buffer;
            buffer = "";
            info++;
          } else
            buffer += line[idx];
        }
        // last parameter
        op[info] = buffer;
        buffer = "";
        // 部位
        int part = op[0].toInt();
        // 狀態
        int state = op[1].toInt();
        Serial.println("Step3: change sate");
        control(part, state);
      }
    }
    // 結束之前 把檔案關掉
    dataFile.close();
    for (int i = 0; i < 7; i++) {
      digitalWrite(light[i][0], 0);
      digitalWrite(light[i][1], 0);
    }
  }
}

// 用來讀取從開始到當下所經過的時間(單位: ms)
unsigned long getElapsedTime() {
  unsigned long currTime;
  currTime = millis();
  unsigned long elapsedTime = currTime - startTime;
  return elapsedTime;
}

// controller function
void control(int part, int state) {
  if (state == 0) {
    // all dark
    digitalWrite(light[part][0], 0);
    digitalWrite(light[part][1], 0);
  } else if (state == 1) {
    // color 0 lighten, color 1 dark
    digitalWrite(light[part][0], 1);
    digitalWrite(light[part][1], 0);
  } else if (state == 2) {
    // color 0 dark, color 1 lighten
    digitalWrite(light[part][0], 0);
    digitalWrite(light[part][1], 1);
  } else if (state == 3) {
    // all lighten
    digitalWrite(light[part][0], 1);
    digitalWrite(light[part][1], 1);
  }
  // debug
  Serial.print("Part: ");
  Serial.print(part);
  Serial.print(", State: ");
  Serial.println(state);
  Serial.println("All port state:");
  for (int i = 0; i < 7; i++) {
    Serial.print("part ");
    Serial.print(i);
    Serial.print(": ");
    Serial.print(digitalRead(light[i][0]));
    Serial.print(" ");
    Serial.println(digitalRead(light[i][1]));
  }
}

void InitESPNow() {
  WiFi.disconnect();
  if (esp_now_init() == ESP_OK) {
    Serial.println("ESPNow Init Success");
  } else {
    Serial.println("ESPNow Init Failed");
    ESP.restart();
  }
}

//讀取master資料
void OnDataRecv(const uint8_t *mac, const uint8_t *incomingData, int len) {
  memcpy(&database, incomingData, sizeof(database));
  Serial.printf("data: %s , from: %s\n", database.data_number, database.board_name);
  // 判斷接收到的訊息是要執行stage檔案還是暫停
  /*if (database.data_number.substring(0, 4) == "stage") {
    stage = database.data_number.substring(6, 7).toInt();
  } else if (database.data_number == "stop") {
    stage = 0;
  }*/
  stage = database.data_number.toInt();
  Serial.print("Now stage: ");
  Serial.println(stage);
}

void configDeviceAP() {
  String Prefix = "Slave:";
  String Mac = WiFi.macAddress();
  String SSID = Prefix + Mac;
  String Password = "123456789";
  bool result = WiFi.softAP(SSID.c_str(), Password.c_str(), CHANNEL, 0);
  if (!result) {
    Serial.println("AP Config failed.");
  } else {
    Serial.println("AP Config Success. Broadcasting with AP: " + String(SSID));
  }
}
