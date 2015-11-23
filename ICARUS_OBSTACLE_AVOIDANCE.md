[Operating Instructions](ICARUS_OBSTACLE_AVOIDANCE#Operation.md)
[ROS Source Code](https://bitbucket.org/uicrobotics/icarus_oa)
[Propeller Source Code](https://www.dropbox.com/sh/5k0mwuku06bbsmt/agLkb_57Lh)

[Primary Controller](PrimaryController.md)
[Flight Controller](FlightController.md)
[Motion Controller](MotionController.md)


# Milestones #
  * Design and Fabricate Sonic Sensor mounts (DONE)
  * Design and Fabricate Sonic Sensor Board for Daisy Chaining (DONE)
  * Install Sonic Sensors on UAV (5 out of 6 DONE)
  * Calibrate Sensors to real Distances (DONE)
  * Dev code for Force Mapping Algorithm (DONE)
  * Dev Code to acquire Sensor values. (DONE)
  * Test & Refine OA Code (Not Started)

## Summary ##
This project builds upon the previous project, [ICARUS\_SLAM](ICARUS_SLAM.md).  This project also uses the Quickstart and QuickstartPlus, along with Ultrasonic sensors and a Force Mapping algorithm to provide obstacle avoidance.  This can be used in cluttered environments, such as office spaces.

## Basic Operation ##

This project employs obstacle avoidance using Ultrasonic Sensors placed around the UAV.  These Sensors are placed at the Front, Left, Right, Back, Top and Bottom of the UAV.

The Ultrasonic Sensors have very little resolution, as they only report back the distance to the nearest obstacle they see.  But, since they have a fairly wide field of view and they consume little system resources (memory, space, weight, energy, etc) and they respond quickly to changes in their environment they are used to provide immediate feedback to the Force Mapping Algorithm used to adjust the motor speeds to avoid obstacles they perceive.

## Sensor Operation ##
The Sonar Sensors used in this Project are the [Maxbotix LV-EZ0](http://www.maxbotix.com/documents/MB1000_Datasheet.pdf) Ultrasonic Sensors.  These sensors were selected due to their small size, variety of interfacing options, community support and precision.  Additionally the EZ0 sensors were selected due to their wide beamwidth necessary to find obstacles near the UAV.  In other applications sonar sensors with narrower beamwidths may be preferred, especially when performing mapping operations.

With these Sensors, it is necessary to daisy-chain them to avoid one sonar's transmit interfering with another sonar's reception.  As these sensors provide the necessary pinout and specifications to allow for daisy-chaining, see [link](http://www.maxbotix.com/documents/LV_Chaining_Constantly_Looping_AN_Out.pdf) all that is necessary is to build a board to facilitate this operation:

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/SonarBoard/SonarBoard.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/SonarBoard/SonarBoard.png)

To prevent spurious readings from the sonars interfering with the UAV's motion, each sensor is checked to make sure that the distance it reports is greater than 1" (the minimum range of the sensor) and averaged with the previous sensor reading.

## Force Mapping Algorithm ##

The Force Mapping Algorithm is fairly simple as the UAV requires high throughput and quick response times to mitigate risks it can cause to its environment, and risks the environment can cause the UAV.

Here is a breakdown of the tasks involved in the Force Mapping Algorithm:
  1. The Flight Controller (FC) computes the PWM values for each Rotor Motor.
  1. Instead of the FC normally sending these PWM values to each Rotor ESC directly, the Motion Controller (MC) reads this data instead.
  1. The MC also reads the distance read for each of the Sonar Sensors.
  1. Based on which Sonar reading is the lowest (i.e. closest) the MC applies an equation that offsets the appropriate motor PWM values.
  1. The modified rotor PWM values are then applied to every rotor, providing obstacle avoidance on the UAV.

### Mapping between the lowest Sonar reading and the Rotor PWM modifications ###

| **_Lowest Sonar_** | **_Required Action_** | **_Front Rotor Change_** | **_Left Rotor Change_** | **_Back Rotor Change_** | **_Right Rotor Change_** |
|:-------------------|:----------------------|:-------------------------|:------------------------|:------------------------|:-------------------------|
| Top                | Decrease Altitude     | Decrease                 | Decrease                | Decrease                | Decrease                 |
| Bottom             | Increase Altitude     | Increase                 | Increase                | Increase                | Increase                 |
| Left               | Roll Right            | No Change                | Increase                | No Change               | Decrease                 |
| Front              | Pitch Back            | Increase                 | No Change               | Decrease                | No Change                |
| Right              | Roll Left             | No Change                | Decrease                | No Change               | Increase                 |
| Back               | Pitch Forwards        | Decrease                 | No Change               | Increase                | No Change                |

A good algorithm will provide a large change in motion when an obstacle is near the UAV and a very small (or no) change when there are no obstacles near the UAV.  To generate the appropriate Force Mapping equation a Matlab script was created.  After some experimentation the equation
```
x: Distance (in)
max_us: Maximum Change of PWM Value, in micro-seconds, at x=0 inches
pwm_delta(x) = (200*max_us)/(x^3)
```

It will be required to determine the appropriate value of ` max_us ` to provide good feedback for the UAV, as this will be hard (impossible?) to find analytically.  Currently, `max_us` is set to 1000 to provide the maximum change of motion, acknowledging that the PWM driver running on the MC limits the minimum/maximum PWM value to the the industry standard range of 1000 uS to 2000 uS.


![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_OA/ForceMapping.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_OA/ForceMapping.png)

This figure is a graph of the previously defined equation, with x = 0:72 inches.

It is also noted that during the Pitch/Roll movements the desired change for each corresponding motor is exactly equal and opposite to each other.  Currently there is no support for changing the Yaw Angle of the UAV.

# Media #

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_OA/Flyer_AssywUltrasonicBeams.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_OA/Flyer_AssywUltrasonicBeams.png)

ICARUS Flyer w/ Ultrasonic Beams

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_OA/Flyer_AssywUltrasonicBeams_Top.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_OA/Flyer_AssywUltrasonicBeams_Top.png)

ICARUS Flyer w/ Ultrasonic Beams (Top)

# References #