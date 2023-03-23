#include <FastLED.h>

// define index
#define Head 1
#define Body 2
#define R_Hand 3
#define R_Lag 4
#define L_Hand 5
#define L_Leg 6
#define Num_LED 60
// define LED type
#define LED_TYPE WS2811
// definr Order of Color
#define Color_Order GRB

// 建立LED光條
CRGB Head_LED[Num_LED];
CRGB Body_LED[Num_LED];
CRGB R_H_LED[Num_LED];
CRGB R_L_LED[Num_LED];
CRGB L_H_LED[Num_LED];
CRGB L_L_LED[Num_LED];
/*CRGB leds[NUM_LEDS];
CLEDController *controllers[6];
*/
void setup() {
  // put your setup code here, to run once:
  FastLED.addLeds<LED_TYPE, Head, Color_Order>(Head_LED, Num_LED);   // 頭部設定
  FastLED.addLeds<LED_TYPE, Body, Color_Order>(Body_LED, Num_LED);   // 身體設定
  FastLED.addLeds<LED_TYPE, R_Hand, Color_Order>(R_H_LED, Num_LED);  // 右手設定
  FastLED.addLeds<LED_TYPE, R_Lag, Color_Order>(R_L_LED, Num_LED);   // 右腳設定
  FastLED.addLeds<LED_TYPE, L_Hand, Color_Order>(L_H_LED, Num_LED);  // 左手設定
  FastLED.addLeds<LED_TYPE, L_Leg, Color_Order>(L_L_LED, Num_LED);   // 左腳設定

  /*controllers[0] = &FastLED.addLeds<LED_TYPE,Head>(leds, Num_LED);
  controllers[1] = &FastLED.addLeds<LED_TYPE,Body>(leds, Num_LED);
  controllers[2] = &FastLED.addLeds<LED_TYPE,R_Hand>(leds, Num_LED);
  controllers[3] = &FastLED.addLeds<LED_TYPE,R_Lag>(leds, Num_LED);
  controllers[4] = &FastLED.addLeds<LED_TYPE,L_Hand>(leds, Num_LED);
  controllers[5] = &FastLED.addLeds<LED_TYPE,L_Leg>(leds, Num_LED);*/

  FastLED.setBrightness(128);
}

void loop() {
  // put your main code here, to run repeatedly:
  Marquee(Head_LED, 3, 5, 60, CRGB::Red);
  Gradient(Head_LED, 30, Num_LED);
}
// 跑馬燈
void Marquee(CRGB pin, int t, int BrightNum, int NumOfLED, uint32_t color) {
  // pin:部位
  // t:跑馬燈每幾毫秒變一次
  // BrightNum:一次有幾個LED在跑
  // NumOfLED:全部LED數量
  // color:顏色
  int pos = 0;
  EVERY_N_MILLISECONDS(t) {
    for (int i = 0; i < NumOfLED; i++) {
      pin[i] = 0x000000;  // 變黑
    }
    //FastLED[pin].clear();
    for (int i = 0; i < BrightNum; i++) {
      pin[(pos + i) / NumOfLED] = color;  // 發光
    }
    FastLED.show();
    pos = (pos++) % NumOfLED;
  }
}

// 閃爍
void Flashing(CRGB pin, int time, int NumOfLED, uint32_t color) {
  // pin:部位
  // time:閃爍週，單位:ms
  // NumOfLED:全部LED數量
  // color:顏色
  EVERY_N_MILLISECONDS(time / 2) {
    for (int i = 0; i < NumOfLED; i++) {
      //pin[i] = (r, g, b);  // 發光
      pin[i] = color;
    }
    FastLED.show();
  }
  EVERY_N_MILLISECONDS(time / 2) {
    for (int i = 0; i < NumOfLED; i++) {
      pin[i] = 0x000000;  // 變黑
    }
  }
}

// 漸亮
void Brighter(int pin, int interval, int start_brightness, int max_brightness) {
  // pin:部位
  // interval:亮度間隔,瞬間亮起的話，interval設為255
  // start_brightness:初始亮度
  // max_brightness:最大亮度
  for (int brightness = start_brightness; brightness < max_brightness; brightness += interval) {
    if (brightness > max_brightness)
      brightness = max_brightness;
    FastLED[pin].showLeds(brightness);
  }
}

// 漸暗、瞬亮、瞬暗、漸層、變色
void Darker(int pin, int interval, int start_brightness, int min_brightness) {
  // pin:部位
  // interval:亮度間，瞬間暗掉的話，interval設為255
  // start_brightness:初始亮度
  // min_brightness:最大亮度
  for (int brightness = start_brightness; brightness > min_brightness; brightness -= interval) {
    if (brightness < min_brightness)
      brightness = min_brightness;
    FastLED[pin].showLeds(brightness);
  }
}
void Darker(CRGB* pin, int time, int NumOfLED) {
  // pin:部位
  // time:時間間隔
  EVERY_N_MILLISECONDS(time) {
    fadeToBlackBy(pin, NumOfLED, 10);
  }
  FastLED.show();
}

// 逐漸變色
void Gradient(CRGB* pin, int time, int NumOfLED) {
  // pin:部位
  // time:時間間隔
  static uint8_t hue = 0;
  EVERY_N_MILLISECONDS(time) {
    /*for (int i = 0; i < NumOfLED; i++) {
      pin[i] = CHSV(hue, 255, 200);
    }*/
    fill_solid(pin, NumOfLED, CHSV(hue, 255, 20));
    FastLED.show();
    hue++;
  }
}

// 直接變色
void ChangeColor(CRGB pin, int NumOfLED, uint32_t color) {
  // pin:部位
  // color:顏色
  for (int i = 0; i < NumOfLED; i++) {
    pin[i] = color;
  }
  FastLED.show();
}

// 呼吸燈
void Breath(int pin, int time, uint32_t color) {
  // pin:部位
  // time:時間間隔
  // color:顏色
  int brightness = 0;
  bool state = 0;  // 變亮=1,變暗=0
  EVERY_N_MILLISECONDS(time) {
    if (state == 0) {
      FastLED[pin].showLeds(brightness += 10);
      if (brightness > 255)
        state = 1;
    } else {
      FastLED[pin].showLeds(brightness -= 10);
      if (brightness > 255)
        state = 1;
    }
  }
}