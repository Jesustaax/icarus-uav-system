# Motion Controller #

[Source Code](https://github.com/dgitz/icarus_mc)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/IsoLED.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/IsoLED.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/CADIso.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/CADIso.png)
# Operation #
## Indicators ##
LED1:  Blinks during MC startup, is off otherwise.

LED2: Blinks when in MANUAL-DISARMED, is ON when in MANUAL-ARMED, off otherwise.

LED3: Blinks when in TEST-DISARMED, is ON when in TEST-ARMED, off otherwise.

LED4: Blinks during an Error Condition, is OFF otherwise.

## Initialization ##
  1. Pins are set as Inputs/Outputs
  1. All Drivers/Cogs are Started
  1. Motors are tested: Front, Left, Back, Right x3

# Normal Operation #
  * Fast Loop: 100 Hz
    * Runs Armed Handler
    * Flight Mode Handler
    * Sonar Reads
  * Medium Loop: 10 Hz
    * Read FC PWM Inputs
    * Set PWM Outputs (MANUAL-MODE,TEST-MODE)
  * Slow Loop: 1 Hz
    * Reset Sonar Counters
    * Debugging

# Media #
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Top.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Top.jpg)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Back.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Back.jpg)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Bottom.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Bottom.jpg)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Left.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Left.jpg)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Right.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Right.jpg)