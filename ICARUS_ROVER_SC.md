# Sonic Controller #

[Source Code](https://github.com/dgitz/icarus_rover_mc)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/IsoLED.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/IsoLED.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/CADIso.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/CADIso.png)
# Operation #
## Indicators ##
LED1:  Blinks during SC startup, is off otherwise.

LED2: Blinks during normal Operation at approx 10 Hz.


## Initialization ##
  1. Pins are set as Inputs/Outputs
  1. All Drivers/Cogs are Started
  1. 

# Normal Operation #
  * Fast Loop: 1000 Hz
    * 
  * Medium Loop: 20 Hz
    * Read All Ping Sensors
    * Send $SON Message to Robot Controller
  * Slow Loop: 10 Hz
    * Toggle Run LED
    * Debugging

# Media #
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Top.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Top.jpg)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Back.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Back.jpg)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Bottom.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Bottom.jpg)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Left.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Left.jpg)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Right.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/MotionController/Right.jpg)