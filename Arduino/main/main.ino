#include <SPI.h> // SPI is Serial Peripheral Interface, for SD communication usage 
#include <SD.h> // enable Arduino ESP32 read the SD card data
#include <FastLED.h> // used to control `Address controllable led light strip`

// Define part for LED strip
#define LED_PIN     5
#define NUM_LEDS    50
#define BRIGHTNESS  64
#define LED_TYPE    WS2811
#define COLOR_ORDER GRB
CRGB leds[NUM_LEDS];
#define UPDATES_PER_SECOND 100

void setup(){
    
}

void loop(){
    
}

