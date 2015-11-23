[Operating Instructions](ICARUS_SLAM#Operation.md)
[Source Code](https://bitbucket.org/davidgitz/icarus_slam)

[Primary Controller](PrimaryController.md)
[Flight Controller](FlightController.md)

# Introduction #

## Summary ##
This project is to implement a mapping system onboard a flying UAV (ICARUS Flyer).  The ICARUS Flyer employs a reputable and wide-supported autopilot system (The DIYDrones APM 2.0) with GPS based navigation.  For indoor environments GPS is rendered useless so a different approach is required.  However it is not appropriate to alter the source code on the APM as it is in a constant state of development.  So a solution is developed using a Kinect Sensor, RGBDSLAM and a Single-Board-Computer (SBC) that is able to produce a GPS-like coordinate system that is transferred to the APM, which then can conduct its very well developed navigation algorithms.

This project is currently on hold until some form of safety or obstacle avoidance is implemented, to keep the UAV from crashing into the hallway walls here.  For more information, please visit [ICARUS Obstacle Avoidance](https://code.google.com/p/icarus-uav-system/wiki/ICARUS_OBSTACLE_AVOIDANCE)

## Basic Operation ##

  1. Primary Controller creates a map of an indoor environment using the Kinect Sensor and open-source SLAM algorithms (RGBDSLAM).
  1. Primary Controller converts position estimate from SLAM algorithm to GPS-like coordinate system, using an initial GPS position.
  1. Primary Controller transmits GPS-like coordinates to APM at 5-10Hz rate, using the NMEA 0183 protocol.
  1. Primary Controller transmits information to GCS (QGroundControl) about current position using MAVLink
  1. User using GCS creates Waypoints which are transmitted to Primary Controller.
  1. Primary Controller transmits Waypoints and other required information to APM (including Arming information)
  1. APM performs flight maneuvers to navigate between current position and target waypoints.

NOTE: In the future, the waypoints will be selected autonomously.  Look here for more information: [TargetDetection](TargetDetection.md)

NOTE: In the future, the ICARUS Flyer will be able to transition between an outdoor environment with actual GPS data to an indoor (or other GPS-denied) environment with the GPS-like position data.

# Tasks #
  * Joystick (Not Started)
  * GPS Hacking, Checksum (DONE)
  * MAVLink Commands (INW)
  * SLAM (Requires Testing)
  * MAVLink connection to Mission Planner/QGroundControl (QGC-INW,MP-Not Started)
  * Install Kinect on UAV (Not Started)
  * Connection to Tablet running DroidPlanner (INW)


# Milestones #
  1. Manual Flight of UAV (INW)
  1. Position estimation (GPS) of UAV (DONE)
    * Require initial Heading information (DONE)
  1. Minimal comm links established with APM and GCS
    * GPS 3D Fix on APM (DONE)
    * Position update on GCS (DONE)
    * Waypoint commands to APM over MAVLink (DONE)
  1. APM autonomous navigation between waypoints using rolling cart testbed (INW)
  1. Implementation on SBC (Not Started)
  1. APM navigation between waypoints using actual flying maneuvers (Not Started)

# Media #
![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_SLAM/UAV_Software.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_SLAM/UAV_Software.jpg)

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_SLAM/Environment.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_SLAM/Environment.jpg)

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_SLAM/GCS.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_SLAM/GCS.jpg)
Not much to look at here, but I was walking directly East in the hall and the GCS shows that I am indeed going East.

[Initial Project Video](http://www.youtube.com/watch?v=6oq6S1b4y3E&feature=youtu.be)

# Installation/Development Instructions #

# SLAM Stuff #
Original source code:
[ROS-RGBDSLAM](http://www.ros.org/wiki/rgbdslam)

http://answers.ros.org/question/11755/rgbdslam-camera-location/

http://mediabox.grasp.upenn.edu/roswiki/doc/api/rgbdslam/html/annotated.html

http://answers.ros.org/question/11181/getting-position-and-orientation-from-rgbdslam/

http://answers.ros.org/question/33909/rgbdslam-octomap-for-continuous-realtime-mapping/

# MAVLink Stuff #
https://code.google.com/p/ardupilot-mega/wiki/MAVLink

http://qgroundcontrol.org/mavlink/start

https://pixhawk.ethz.ch/mavlink/

## Commands ##
The following are commands that may be required to transmit to/from the APM


Relevant Arducopter Code: GCS\_Mavlink.pde

# GPS Stuff #
https://code.google.com/p/arducopter/wiki/GPSDisable

Emaluated GPS: Mediatek, 38400 baud

Default Position:

Latitude: 41.870404

Longitude: -87.649293

Latitude: 1 deg = 110.54 km

Longitude: 1 deg = 111.320\*cos(latitude) km


## Required APM Messages ##
(From AP\_GPS\_NMEA.cpp)
```
case _GPS_SENTENCE_GPRMC:
                    time                        = _new_time;
                    date                        = _new_date;
                    latitude            = _new_latitude * 10;   // degrees*10e5 -> 10e7
                    longitude           = _new_longitude * 10;  // degrees*10e5 -> 10e7
                    ground_speed_cm     = _new_speed;
                    ground_course_cd    = _new_course;
                    fix                 = GPS::FIX_3D;          // To-Do: add support for proper reporting of 2D and 3D fix
                    break;
case _GPS_SENTENCE_GPGGA:
                    altitude_cm         = _new_altitude;
                    time                        = _new_time;
                    latitude            = _new_latitude * 10;   // degrees*10e5 -> 10e7
                    longitude           = _new_longitude * 10;  // degrees*10e5 -> 10e7
                    num_sats            = _new_satellite_count;
                    hdop                        = _new_hdop;
                    fix                 = GPS::FIX_3D;          // To-Do: add support for proper reporting of 2D and 3D fix
                    break;
case _GPS_SENTENCE_GPVTG:
                    ground_speed_cm     = _new_speed;
                    ground_course_cd    = _new_course;
                    // VTG has no fix indicator, can't change fix status
                    break;
```

## NMEA 0183 ##
Required GPS Packets for ArduCopter v3.0.1:
RMC,GGA,VTG

http://en.wikipedia.org/wiki/NMEA_0183

http://www.tronico.fi/OH6NT/docs/NMEA0183.pdf

### RMC ###
RMC Recommended Minimum Navigation Information

$--RMC,hhmmss.ss,A,llll.ll,a,yyyyy.yy,a,x.x,x.x,xxxx,x.x,a\*hh

  1. Time (UTC)
  1. Status, V = Navigation receiver warning
  1. Latitude
  1. N or S
  1. Longitude
  1. E or W
  1. Speed over ground, knots
  1. Track made good, degrees true
  1. Date, ddmmyy
  1. Magnetic Variation, degrees
  1. E or W
  1. Checksum

NOTE:  For the APM, the Latitude and Longitude is in the format: ddmm.mmm

### GGA ###
GGA Global Positioning System Fix Data. Time, Position and fix related data
for a GPS receiver

$--GGA,hhmmss.ss,llll.ll,a,yyyyy.yy,a,x,xx,x.x,x.x,M,x.x,M,x.x,xxxx\*hh
  1. Time (UTC)
  1. Latitude
  1. N or S (North or South)
  1. Longitude
  1. E or W (East or West)
  1. GPS Quality Indicator: 0 - fix not available, 1 - GPS fix, 2 - Differential GPS fix
  1. Number of satellites in view, 00 - 12
  1. Horizontal Dilution of precision
  1. Antenna Altitude above/below mean-sea-level (geoid)
  1. Units of antenna altitude, meters
  1. Geoidal separation, the difference between the WGS-84 earth ellipsoid and mean-sea-level (geoid), "-" means mean-sea-level below ellipsoid
  1. Units of geoidal separation, meters
  1. Age of differential GPS data, time in seconds since last SC104  type 1 or 9 update, null field when DGPS is not used
  1. Differential reference station ID, 0000-1023
  1. Checksum

NOTE:  For the APM, the Latitude and Longitude is in the format: ddmm.mmm
### VTG ###

VTG Track Made Good and Ground Speed

$--VTG,x.x,T,x.x,M,x.x,N,x.x,K\*hh
  1. Track Degrees
  1. T = True
  1. Track Degrees
  1. M = Magnetic
  1. Speed Knots
  1. N = Knots
  1. Speed Kilometers Per Hour
  1. K = Kilometres Per Hour
  1. Checksum

## Compiling ##
```
roscd slam_icarus
rosmake slam_icarus
```
On my Ubuntu Laptop it required 837.7 seconds to compile.

## Commit ##
  1. Add any uncommitted files:
```
git add .
```
  1. Make a comment on the commit and then push it to the main branch.
```
git commit -m "Comment Text"
git push -u origin master
```

# Operation #
## Headless ##
  * In Terminal 1:
```
roscore
```

  * In Terminal 2:
```
roslaunch rgbdslam slow_computer2.launch
```

  * In Terminal 3:
```
sudo chmod 0777 /dev/ttyACM0
rosservice call /rgbdslam/ros_ui_b pause false
```

Execute the main program with the following:
```
python nodes/primarycontroller.py
```
The following options are available.  Use the text in the <> where applicable, | signifies different options, and omit the <> and |:
  * Connection to GCS (Transmit GPS and Attitude Completed)
```
--gcs-device-type=<udp|Serial>
--gcs-device=<Device> #Where Device is an IP address if the type is udp, or a Serial Device such as /dev/ttyUSB0 or /dev/ttyACM0
--gcs-device-speed=<Speed> #Where Speed is a compatible baud rate if the type is Serial (default is 115200) and not used the type is udp 
```
  * Connection to Flight Controller (Receive Attitude Completed)
```
--fc-device-type=<udp|Serial>
--fc-device=<Device> #Where Device is an IP address if the type is udp, or a Serial Device such as /dev/ttyUSB0 or /dev/ttyACM0
--fc-device-speed=<Speed> #Where Speed is a compatible baud rate if the type is Serial (default is 115200) and not used the type is udp 
```
  * Connection to Flight Controller GPS (In Progress)
```
--fcgps-device-type=<udp|Serial>
--fcgps-device=<Device> #Where Device is an IP address if the type is udp, or a Serial Device such as /dev/ttyUSB0 or /dev/ttyACM0
--fcgps-device-speed=<Speed> #Where Speed is a compatible baud rate if the type is Serial (default is 115200) and not used the type is udp 
```
  * Connection to Motion Controller (In Progress)
```
--mc-device-type=<udp|Serial>
--mc-device=<Device> #Where Device is an IP address if the type is udp, or a Serial Device such as /dev/ttyUSB0 or /dev/ttyACM0
--mc-device-speed=<Speed> #Where Speed is a compatible baud rate if the type is Serial (default is 115200) and not used the type is udp 
```
  * Connection to Remote (Transmit GPS and Attitude In Progress)
```
--remote-device-type=<udp|Serial>
--remote-device=<Device> #Where Device is an IP address if the type is udp, or a Serial Device such as /dev/ttyUSB0 or /dev/ttyACM0
--remote-device-speed=<Speed> #Where Speed is a compatible baud rate if the type is Serial (default is 115200) and not used the type is udp 
```

  * Example
```
rgbdslam/nodes/primarycontroller.py --fcgps-device-type=Serial --fcgps-device=/dev/ttyUSB0 --fc-device-type=Serial --fc-device=/dev/ttyACM0 --gcs-device-type=udp --gcs-device=10.7.45.208
```

## GUI ##
  * In Terminal 1:
```
roscore
```

  * In Terminal 2:
```
rosrun rviz rviz
```

  * In Terminal 3:
```
roslaunch rgbdslam slow_computer2.launch
```
When GUI opens, press SPACE.
In RVIZ, Global Status should turn from ERROR to OK after moving.
  * In Terminal 4:
```
rosrun tf tf_echo /map /camera_link
```