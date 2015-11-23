# Remarks #
Clean Up.
# Introduction #

Add your content here.


# Details #

Add your content here.  Format your content with:
  * Text in **bold** or _italic_
  * Headings, paragraphs, and lists
  * Automatic links to other wiki pages
Concept of Operations
29-Nov-2012

This document serves to identify and notate the different operational modes of ICARUS and how each mode is initialized and executed.
Notes
All numbers to be defined are represented by “xx”.


Operations
OPERATIONAL MODE – HOVER


Pilot wishes to adjust:	Flyer performs:
Pitch Up	Front Rotors increase Speed, Back Rotors decrease Speed, All Winglets at constant 0 Degree Angle.
Roll Right	Left Rotors increase Speed, Right Rotors decrease Speed, All Winglets at constant 0 Degree Angle.
Yaw Right	Front Left and Back Right Rotors decrease Speed, Front Right and Back Left Rotors increase Speed, All Winglets at constant 0 Degree Angle.
Increase speed of Flyer	All Rotors increase Speed, All Winglets at constant Perpendicular Angle.


OPERATIONAL MODE – STOL/TRANSITION


Pilot wishes to adjust:	Vehicle performs:
Increase Pitch	Front Rotors increase Speed, Back Rotors decrease Speed, Both Rear Winglets rotate up.
Roll Left	Left Rotors increase Speed, Right Rotors decrease Speed, Left Winglets rotate up, Right Winglets rotate down.
Yaw Left	Front Left and Back Right Rotors decrease Speed, Front Right and Back Left Rotors increase Speed, Left Rotors decrease Speed, Right Rotors increase speed.
Increase speed of Flyer	All Rotors increase Speed.


OPERATIONAL MODE – CRUISE

Pilot wishes to adjust:	Vehicle performs:
Increase Pitch	Both Rear Winglets rotate up, No other changes.
Roll Left	Left Winglets rotate up, Right Winglets rotate down, No other changes.
Yaw Left	Left Rotors decrease Speed, Right Rotors increase speed, all Winglets at constant rotation angle.
Increase speed of Flyer	All Rotors increase Speed, all Winglets at constant rotation angle.



FLIGHT MODES
FLIGHT MODE – ALT HOLD
FLIGHT MODE – RTL
ArduPlane
Reference:  http://code.google.com/p/ardupilot-mega/wiki/FlightModesFlyByWire
“Ardupilot Mega can fly your plane using input from your radio and the control loops from the autopilot code. You "tell" Ardupilot where to go (all 3 attitude axes).
For example, if you hold the stick 5 degrees to the right the plane will tilt 5 degrees to the right and hold that as long as you hold the stick there. By contrast, in stabilize (or manual), the plane would continue to increase the bank as long as you held the stick to the side, and would eventually do a roll. In short, FBW makes a plane fly like a car drives. (Cars hold a turn at the wheel position)”
FLIGHT MODE – STABILIZE
ArduPlane
Reference:  http://code.google.com/p/ardupilot-mega/wiki/FlightModesStabilize
“Ardupilot will stabilize your plane during RC control. It smooths out your aircraft's movement and when you release the sticks, it will return to level flight.
This is a great mode for all users (it makes landing easy--you'll look like a pro), but is especially useful for beginners. If you get in trouble, just release the sticks and it will recover by itself, regardless of what crazy position it was in.”
ArduCopter
Reference:  http://code.google.com/p/arducopter/wiki/AC2_StableMode
“Stabilize mode automatically levels the multi-copter and maintains the current heading.
•	Stabilize is the primary operating mode and is good for general flying and FPV.
•	The APM must always initially be set to Stabilize mode in order to be able to arm the ESCs before takeoff.
•	It is VERY important to be able to easily and rapidly switch back to Stabilize mode from any other mode in order to regain control from any unexpected or undesirable flight behavior.“
FLIGHT MODE – FLY BY WIRE
ArduPlane
Reference:  http://code.google.com/p/ardupilot-mega/wiki/FlightModesFlyByWire
“Ardupilot Mega can fly your plane using input from your radio and the control loops from the autopilot code. You "tell" Ardupilot where to go (all 3 attitude axes).
For example, if you hold the stick 5 degrees to the right the plane will tilt 5 degrees to the right and hold that as long as you hold the stick there. By contrast, in stabilize (or manual), the plane would continue to increase the bank as long as you held the stick to the side, and would eventually do a roll. In short, FBW makes a plane fly like a car drives. (Cars hold a turn at the wheel position)”
FLIGHT MODE – MANUAL
All Control Loops are bypassed and the ICARUS Flyer matches all outputs with the corresponding inputs.
FLIGHT MODE – DIAGNOSTIC
Flyer enters FLIGHT MODE – DIAGNOSTIC when Commanded by GCS, RCU or itself.
Flyer concurrently enters FLIGHT MODE – HOVERING, SECONDARY CONTROLLER ONLY
Flyer initiates the following actions:
1.	Secondary Controller maintains operation of Communications Processor and PWM Processor.
a.	Secondary Controller Diagnostic sub-routines started.
b.	When complete, transmit any Errors Wirelessly.
2.	Primary Controller maintains operation of Communications
a.	Primary Controller Diagnostic sub-routines started.
b.	When complete, transmit any Errors Wirelessly.
3.	If no Errors on Secondary Controller and some Errors on Primary Controller
a.	Transfer Communications Command to Secondary Controller
b.	Reboot Primary Controller
4.	If no Errors on Primary Controller and Secondary Controller, enter FLIGHT MODE –HOVERING, PRIMARY AND SECONDARY CONTROLLER.
5.	Transmit Diagnostic Success Message wirelessly.



Indicators
Main LED Indicator

Red:  On upon Error
Yellow:  Blinks during Boot Process
Green:  Blinks during Manual Mode
Blue:  Blinks during any Semi or Auto Mode







Flight Modes
Each FLIGHT MODE has a corresponding priority, in the following order:
•	EMERGENCY RECOVERY
•	EMERGENCY LANDING
•	NO COMMUNICATIONS
•	DIAGNOSTIC
•	LANDING
•	All Other FLIGHT MODES.

NORMAL
Vehicle:  Everything Normal.  No Error Conditions.
TAKING OFF
Vehicle:  Everything Normal.  No Error Conditions.
HOVERING
Vehicle:  Everything Normal.  2 Options:
1.	Receive Yaw, Throttle commands and attempt to keep Altitude constant.
2.	Rotate Tilt-Rotors to FLIGHT MODE – CRUISE.
LANDING
Vehicle:  Everything Normal.  No Error Conditions.
OR

DIAGNOSTIC
Vehicle enters FLIGHT MODE – DIAGNOSTIC when any of the following conditions exist:
1.	Vehicle attempting to exit out of the following FLIGHT MODES to FLIGHT MODE – NORMAL:
a.	FLIGHT MODE – NO COMMUNICATIONS
b.	FLIGHT MODE – EMERGENCY LANDING
c.	FLIGHT MODE – EMERGENCY RECOVERY
2.	Initiated by GCS or RCU
3.	Vehicle should enter FLIGHT MODE – HOVER concurrently.
CRUISE
NO COMMUNICATIONS
Vehicle enters this mode when any of the following conditions exist:
1.	No Communications for xx Seconds.
2.	Packet loss per second > xx packets

EMERGENCY LANDING
Vehicle attempting Emergency Landing operation due to one or more of the following reasons:
3.	No Communications for xx Seconds.
4.	Battery Voltage < xx and Altitude over Ground > xx.
5.	Pitch,Roll,Yaw,Throttle or Altitude over Ground uncontrollable.
6.	Loss of Critical Components:  Primary Controller, GPS.

Vehicle Initiates the following actions:
1.	Complete FLIGHT MODE - LANDING
2.	Start Self-Diagnostics
3.	Start GPS Beacon

EMERGENCY RECOVERY
Vehicle attempting Emergency Recovery operation due to one or more of the following reasons:
1.	EMERGENCY LANDING Procedure not appropriate or not possible.
2.	No Communications for X Seconds.
3.	Battery Voltage < X and Altitude over Ground > X.
4.	Pitch,Roll,Yaw,Throttle or Altitude over Ground uncontrollable.
5.	Loss of Critical Components:  Secondary Controller, Main ESC’s.

Vehicle Initiates the following actions:
1.	Attempt remove power from Motors.
2.	Deploy Parachute
3.	Deploy Flare
4.	Start GPS Beacon