//引入函式庫
#include <WiFi.h>
#include <esp_now.h>
#include <esp_wifi.h>
//固定變數
#define NUMSLAVES 20
#define CHANNEL 0
#define PRINTSCANRESULTS 0
//ESP32掃描
esp_now_peer_info_t peerInfo[NUMSLAVES] = {};
int SlaveCnt = 0;

//
bool start = 0;

int number;
//設置變數
#define board_number 1

typedef struct struct_message {
  String data_number;
  String board_name;

} struct_message;
struct_message myData[20];
struct_message database;

void OnDataRecv(const uint8_t *mac, const uint8_t *incomingData, int len) {

  
  memcpy(&database, incomingData, sizeof(database));
  Serial.printf("number:%s ,from:%s\n", database.data_number, database.board_name);
  //
  if(database.data_number == "start")
  start = 1;
}
void setup() {

  Serial.begin(115200);

  configDeviceAP();
  WiFi.mode(WIFI_AP_STA);
  InitESPNow();

  // 設定傳送資料回撥函式
  //esp_now_register_send_cb(OnDataSent);
  delay(10);
  // 設定接收資料回撥函式
  esp_now_register_recv_cb(OnDataRecv);

  myData[board_number].data_number = "0";
  number = 1;
  myData[board_number].board_name = "WiFi_#" + String(board_number);


  //ScanForSlave();
  //manageSlave();
  delay(1000);
}

void loop() {
  vTaskDelay(10 / portTICK_PERIOD_MS);  // 延遲1000ms
  //
  if(start == 1)
  {
    
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
