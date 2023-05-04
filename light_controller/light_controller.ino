#include <SD.h>
#include <SPI.h>

// 預設SD卡和Arduino板溝通用的pin
// CS: Chip Select pin
#define CSpin 5

// 可手動更換讀檔檔名(Default: data.csv)
const String filename = "/data.csv";

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

const byte light[7][2] = {
  { 13, 12 },
  { 14, 27 },
  { 26, 25 },
  { 33, 32 },
  { 35, 34 },
  { 39, 36 },
  { 16, 17 }
};

void setup() {
  Serial.begin(9600);
  // 設定開始時間, 每次setup()重新初始化

  // pinMode setup
  for (int i = 0; i < 7; i++) {
    pinMode(light[0][i], OUTPUT);
    pinMode(light[1][i], OUTPUT);
  }

  startTime = millis();
  // 檢查是否CS pin有接到SD卡
  if (SD.begin(CSpin) == false) {
    Serial.println("[Error] Unable to initialize SD card");
    return;
  } else {
    Serial.println("[Success] SD card initialize done");
  }

  // 檢查檔名是否有對應檔案
  if (SD.exists(filename) == false) {
    Serial.println("[Error] Filename not exist");
    return;
  } else {
    Serial.println("[Success] Filename available");
  }

  // 檢查檔案是否能正常開啟讀取
  dataFile = SD.open(filename);
  if (dataFile == false) {
    Serial.println("[Error] Failed to open " + filename);
    return;
  } else {
    Serial.println("[Success] File opened successfully");
  }
  // 印出檢查完畢開始讀檔操控LED
  Serial.println("[Done] All check up good!");
  reading = true;  // 預設直接開始讀取
}

void loop() {
  // 開始讀取檔案內容(一次讀完)
  // 預設檔案室依時間順序排序 所以逐行讀檔
  while (dataFile.available()) {
    // reset的部分
    // ESP.restart();

    // 因為SD Library依賴於Stream Library
    // 所以利用Stream內建的讀字串函式
    Serial.print("step1: reading? ");
    if (reading) {
      Serial.println(reading);
      line = dataFile.readStringUntil('\n');
      // 結束讀檔
      if (line == "End File")
        break;
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
    T = buffer.toInt();
    buffer = "";
    if (T > elapsedTime)  // 時間對不上
    {
      Serial.print("Time:");
      Serial.print(elapsedTime);
      Serial.println("  stop reading");
      reading = false;  // 暫停不繼續讀取
    } else {
      reading = true;  //執行完這一行，繼續讀取
      idx++;           // index前進
      // debug
      Serial.print("Time:");
      Serial.print(elapsedTime);
      Serial.print(" ,command:");
      Serial.println(line);

      Serial.println("step2: read parameter");
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
      Serial.println("step3: change sate");
      control(part, state);
    }
  }
  // 結束之前 把檔案關掉
  dataFile.close();
  Serial.println("[End] All progress done!");
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
  Serial.print("part: ");
  Serial.print(part);
  Serial.print(", state: ");
  Serial.println(state);
  Serial.println("all port state:");
  for (int i = 0; i < 7; i++) {
    Serial.print("part ");
    Serial.print(i);
    Serial.print(": ");
    Serial.print(digitalRead(light[i][0]));
    Serial.print(" ");
    Serial.println(digitalRead(light[i][1]));
  }
}
