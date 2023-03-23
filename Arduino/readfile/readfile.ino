#include <SD.h>
#include <SPI.h>
/*
到時候要把LED_Control轉成*.cpp和*.h(變成一個自定義的library)
再include <LED_Control.h>來使用
*/

// 預設SD卡和Arduino板溝通用的pin
// CS: Chip Select pin
const int CSpin=10;

// 可手動更換讀檔檔名(Default: data.csv)
const String filename="data.csv";

// 宣告dataFile物件(用於讀檔,尚未初始化)
File dataFile;

// 用來計時的,當作開始的時間點,用來算出當下經過的時間
unsigned long startTime;

void setup(){
    Serial.begin(9600);
    // 設定開始時間, 每次setup()重新初始化
    startTime=millis();
    // 檢查是否CS pin有接到SD卡
    if(SD.begin(CSpin)==false){
        Serial.println("[Error] Unable to initialize SD card");
        return;
    }
    else{
        Serial.println("[Success] SD card initialize done");
    }
    
    // 檢查檔名是否有對應檔案
    if(SD.exists(filename)==false){
        Serial.println("[Error] Filename not exist");
        return;
    }
    else{
        Serial.println("[Success] Filename available");
    }

    // 檢查檔案是否能正常開啟讀取
    dataFile=SD.open(filename);
    if(dataFile==false){
      Serial.println("[Error] Failed to open "+filename);
      return;
    }
    else{
        Serial.println("[Success] File opened successfully");
    }
    // 印出檢查完畢開始讀檔操控LED
    Serial.println("[Done] All check up good!");
}

void loop(){
    // 開始讀取檔案內容(一次讀完)
    // 預設檔案室依時間順序排序 所以逐行讀檔
    while(dataFile.available()){
        // 因為SD Library依賴於Stream Library
        // 所以利用Stream內建的讀字串函式
        String line=dataFile.readStringUntil('\n');
        unsigned long elapsedTime=getElapsedTime();
        /*
        開始讀取檔案內容
        如果時間對不上, break while-loop, 等下一輪loop再次檢查
        如果時間對上, 繼續一直讀下去, 直到時間對不上
        (時間對上者, 呼叫LED_Control library的函式)
        */
    }
    // 結束之前 把檔案關掉
    dataFile.close();
    Serial.println("[End] All progress done!");
}

// 用來讀取從開始到當下所經過的時間(單位: ms)
unsigned long getElapsedTime(){
    unsigned long currTime;
    currTime=millis();
    unsigned long elapsedTime=currTime-startTime;
    return elapsedTime;
}
