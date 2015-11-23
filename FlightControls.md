# Introduction #

This page describes the flight controls and physics of the ICARUS QTR Flyer.  This page will host the control modes, Control Loops/Equations, Analysis, etc.


# Details #

## Cruise Mode ##
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/xFrameCruiseMode.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/xFrameCruiseMode.png)

## Hover Mode ##
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/xFrameHoverMode.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/xFrameHoverMode.png)

## Input/Output Equations ##

```
RollAngle //Roll Angle in Degrees, Range: -90[Roll Left] -> 90[Roll Right]
PitchAngle //Pitch Angle in Degrees, Range:  -90[Pitch Down] -> 90[Pitch Up]
YawAngle //Yaw Angle in Degrees, Range: -90[Turn Left] -> 90[Turn Right]
TiltAngle //Tilt Angle in Degrees, Range: 90[Hover] -> 0[Cruise]
ThrottlePerc  //Throttle in Percentage, Range: 0 -> 1

FLSpeed //Front Left Rotor Speed in Percentage, Range: 0 -> 1
FRSpeed //Front Right Rotor Speed in Percentage, Range: 0 -> 1
BLSpeed //Back Left Rotor Speed in Percentage, Range: 0 -> 1
BRSpeed //Back Right Rotor Speed in Percentage, Range: 0 -> 1

FLAngle //Front Left Rotor Angle in Degrees, Range: 90[Vertical] -> 0[Horizontal]
FRAngle //Front Right Rotor Angle in Degrees, Range: 90[Vertical] -> 0[Horizontal]
BLAngle //Back Left Rotor Angle in Degrees, Range: 90[Vertical] -> 0[Horizontal]
BRAngle //Back Right Rotor Angle in Degrees, Range: 90[Vertical] -> 0[Horizontal]

PitchPerc //Pitch Angle in Percentage
RollPerc //Roll Angle in Percentage
YawPerc //Yaw Angle in Percentage

PitchPerc = PitchAngle/90;
RollPerc = RollAngle/90;
YawPerc = YawAngle/90;


FLSpeed = (sin(TiltAngle)*(PitchPerc + RollPerc)-(2*sin(TiltAngle)-1)*YawPerc) + ThrottlePerc;
FRSpeed = (sin(TiltAngle)*(PitchPerc - RollPerc) + (2*sin(TiltAngle)-1)*YawPerc) + ThrottlePerc;
BLSpeed = (sin(TiltAngle)*(-PitchPerc + RollPerc) + YawPerc) + ThrottlePerc;
BRSpeed = (sin(TiltAngle)*(-PitchPerc - RollPerc) - YawPerc) + ThrottlePerc;

FLAngle = TiltAngle - cos(TiltAngle) * RollAngle;
FRAngle = TiltAngle + cos(TiltAngle) * RollAngle;
BLAngle = TiltAngle - cos(TiltAngle) * (RollAngle - PitchAngle);
BRAngle = TiltAngle - cos(TiltAngle) * (-RollAngle - PitchAngle);
```

## Input/Output Table ##
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/ControlMapping.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/ControlMapping.png)

# System Identification #

# System Model #

# Simulations #

## MatLab Graphs of Input/Output Equations for Control Maps ##
NOTE:  I still need to go through each of these and verify they are at least feasible.

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Hover-PitchSweep.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Hover-PitchSweep.png)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Hover-RollSweep.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Hover-RollSweep.png)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Hover-YawSweep.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Hover-YawSweep.png)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Hover-ThrottleSweep.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Hover-ThrottleSweep.png)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Cruise-PitchSweep.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Cruise-PitchSweep.png)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Cruise-RollSweep.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Cruise-RollSweep.png)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Cruise-YawSweep.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Cruise-YawSweep.png)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Transition-SweepPitch-Sweep.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Configuration/FlightControls/Transition-SweepPitch-Sweep.png)