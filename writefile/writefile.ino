#include <SD.h>
#include <SPI.h>

// 預設SD卡和Arduino板溝通用的pin
// CS: Chip Select pin
const int CSpin=10;

// 可手動更換讀檔檔名(Default: data.csv)
const String filename="data.csv";

// 宣告dataFile物件(代表csv檔案)
File dataFile;

// 可手動更換存在SD卡的檔名(Default: SDFile.csv)
const String SDFileName="SDFile.csv";

// 宣告SDFile物件(代表SD卡的檔案) 
File SD_File;

void setup(){
    Serial.begin(9600);
    pinMode(CSpin, OUTPUT);
    // 檢查是否CS pin有接到SD卡
    if(!SD.begin(CSpin)){
        Serial.println("[Error] Unable to initialize SD card");
        return;
    }
    else{
        Serial.println("[Success] SD card initialize done");
    }
    
    // 檢查csv檔案是否能夠正常開啟讀取
    dataFile=SD.open(filename);
    if(dataFile==false){
        Serial.println("[Error] Failed to open "+filename);
        return;
    }
    else{
        Serial.println("[Success] File opened successfully");
    }
    Serial.println("[Done] All check up good");

    // 開始寫入檔案資料, 先打開名叫SDFile.csv的檔案(後面多加檢查確認SDFile.csv存在)
    SD_File=SD.open(SDFileName);
    if(SD_File==false){
        Serial.println("[Error] Failed to create SDFile.csv");
        return;
    }
    // 因為檔案只需要寫入一次, 所以直接把所有code放在setup()裡面
    // lineNum: 用來計算寫入行數, 之後方便debug
    static int lineNum=0;
    // 用while-loop將dataFile所有內容寫入SD卡
    while(dataFile.available()){
        // 因為readStringUntil('\n') 會吃掉最後的newline character
        // 但是println()會自動在line後面加上newline character
        String line=dataFile.readStringUntil('\n');
        SD_File.println(line);
        lineNum++;
    }
    dataFile.close();
    SD_File.close();
    Serial.println("[End] All progress done!");
    Serial.println("[Stats]: total "+String(lineNum)+" lines written");
}

void loop(){
    // empty loop: 因為沒有寫入動作需要重複
    // 所以loop() 裡面沒有任何code
}
