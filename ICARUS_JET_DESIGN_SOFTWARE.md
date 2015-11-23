[Primary Controller Source Code](https://github.com/dgitz/icarus_jet_pc)

[Flight Controller Source Code](https://github.com/dgitz/icarus_jet_fc)

[Motion Controller Source Code](https://github.com/dgitz/icarus_jet_mc)

# Evolution Algorithm Controller #
The idea is to develop a controller for the ICARUS Jet that will be tuned based on an Evolution Algorithm.  The final controller will control each Engine's Thrust and Rotation angles, based on manual/autonomous control, flight modes and given sensor data.

For ease of development the first phase of this controller will be based on a normal quadrotor (AR Drone) simulated in VRep.  Also, the entire controller will be implemented on the Primary Controller.

## Phase 1 ##
### TODO ###
  1. Build PID Controller in Python

### Controller ###
The Controller will consist of:
  1. A Roll PID Controller
  1. A Pitch PID Controller
  1. A Yaw PID Controller
  1. An Altitude PID Controller

The following equations will be used to generate the appropriate thrust from each motor, where:

FL: Thrust command sent to Front Left Engine

FR: Thrust command sent to Front-Right Engine

BL: Thrust command sent to Back-Left Engine

BR: Thrust command sent to Back-Right Engine


Cur<sub>Yaw</sub>: Current Yaw Angle.  Yaw is measured in Degrees.  0 is True North, and continues to 360 before 0, clockwise.

Set<sub>Yaw</sub>: Set Yaw Angle, similar to Cur<sub>Yaw</sub>.


Cur<sub>Pitch</sub>: Current Pitch Angle.  Pitch is measured in Degrees.  0 is level, Pitch down until 180 at inverted, then to -180 and back to 0 for level.

Set<sub>Pitch</sub>: Set Pitch Angle, similar to Cur<sub>Pitch</sub>.


Cur<sub>Roll</sub>: Current Roll Angle.  Roll is measured in Degrees.  0 is level, Roll left until 180 at inverted, then to -180 and back to 0 for level.

Set<sub>Roll</sub>: Set Roll Angle, similar to Cur<sub>Roll</sub>.

Cur<sub>Alt</sub>: Current Altitude.  Altitude is measured in meters above Ground.

Set<sub>Alt</sub>: Set Altitude, similar to Cur<sub>Alt</sub>.

#### Roll Controller ####
FL<sub>1</sub> = BL<sub>1</sub> = PID<sub>Roll</sub>(Cur<sub>Roll</sub>,Set<sub>Roll</sub>)

FR<sub>1</sub> = BR<sub>1</sub> = -PID<sub>Roll</sub>(Cur<sub>Roll</sub>,Set<sub>Roll</sub>)
#### Pitch Controller ####
FL<sub>2</sub> = FR<sub>2</sub> = PID<sub>Pitch</sub>(Cur<sub>Pitch</sub>,Set<sub>Pitch</sub>)

BL<sub>2</sub> = BR<sub>2</sub> = -PID<sub>Pitch</sub>(Cur<sub>Pitch</sub>,Set<sub>Pitch</sub>)
#### Yaw Controller ####
FL<sub>3</sub> = BR<sub>3</sub> = PID<sub>Yaw</sub>(Cur<sub>Yaw</sub>,Set<sub>Yaw</sub>)

FR<sub>3</sub> = BL<sub>3</sub> = -PID<sub>Yaw</sub>(Cur<sub>Yaw</sub>,Set<sub>Yaw</sub>)
#### Altitude Controller ####
FL<sub>4</sub> = FR<sub>4</sub> = BL<sub>4</sub> = BR<sub>4</sub> = PID<sub>Alt</sub>(Cur<sub>Alt</sub>,Set<sub>Alt</sub>)

### Complete Controller ###

FL = max(FL<sub>1</sub>,FL<sub>2</sub>,FL<sub>3</sub>,FL<sub>4</sub>)

FR = max(FR<sub>1</sub>,FR<sub>2</sub>,FR<sub>3</sub>,FR<sub>4</sub>)

BL = max(BL<sub>1</sub>,BL<sub>2</sub>,BL<sub>3</sub>,BL<sub>4</sub>)

BR = max(BR<sub>1</sub>,BR<sub>2</sub>,BR<sub>3</sub>,BR<sub>4</sub>)


### Evolution Algorithm ###
To tune the 12 PID Constants for the above controller, an Evolution Algorithm will be used.

Candidate constants will be applied to a simulation of the Quadrotor in VRep, on the following scenario.  On each scenario segment the target is a world position of (t,x,y,z,theta).  The initial and final position is (0,0,0)
  1. Takeoff (1,0,0,1,0)
  1. Hover (3,0,0,1,0)
  1. Fly Forward (3,0,1,1,0)
  1. Hover (3,0,1,1,0)
  1. Roll Left (3,1,1,1,0)
  1. Hover (3,1,1,1,0)
  1. Yaw Left (3,1,1,1,-90)
  1. Fly Backward (3,0,1,1,-90)
  1. Hover (3,0,1,1,-90)
  1. Yaw Right (3,0,0,1,90)
  1. Roll Right (3,0,0,1,90)
  1. Hover (3,0,0,1,90)
  1. Yaw Right (3,0,0,1,0)
  1. Land (1,0,0,0,0)

To evaluate the EA algorithm the fitness of each scenario segment will be calculated, based on:
  1. Time to complete
  1. Error in final x,y,z,theta
  1. Average Ground Velocity (Vx,Vy)
  1. Others?

If a certain trial set results in a crash (walls/floor), inverted flight, or other "bad" solutions it will be set the lowest level of selection for the next round of evolution.

# Velocity Over Ground #
STATUS: In Development

To Use:

In primarycontroller.py:

Set --targetmode=Execute

Set --opticflow=True


## References ##
[OpenCV Optic Flow Example](http://docs.opencv.org/trunk/doc/py_tutorials/py_video/py_lucas_kanade/py_lucas_kanade.html)