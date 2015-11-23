# Software #

[Drone Server Source Code](https://github.com/dgitz/icarus_drone_server)

[Matlab Server Source Code](https://github.com/dgitz/icarus_support)

[AR Drone ROS Driver](https://github.com/AutonomyLab/ardrone_autonomy)

[AR Drone Tum Driver](https://github.com/tum-vision/tum_ardrone)

## Installation Instructions ##
  1. Install Ubuntu 12.04
  1. Install ROS Fuerte (Full version is best)
  1. Install the [AR Drone ROS Navigation Packages](http://wiki.ros.org/tum_ardrone)
  1. 

## ROS Topics ##
### Drone Camera ###
```
/ardrone/bottom/camera_info
/ardrone/bottom/image_raw
/ardrone/bottom/image_raw/compressed
/ardrone/bottom/image_raw/compressed/parameter_descriptions
/ardrone/bottom/image_raw/compressed/parameter_updates
/ardrone/bottom/image_raw/compressedDepth
/ardrone/bottom/image_raw/compressedDepth/parameter_descriptions
/ardrone/bottom/image_raw/compressedDepth/parameter_updates
/ardrone/bottom/image_raw/theora
/ardrone/bottom/image_raw/theora/parameter_descriptions
/ardrone/bottom/image_raw/theora/parameter_updates
/ardrone/camera_info
/ardrone/front/camera_info
/ardrone/front/image_raw
/ardrone/front/image_raw/compressed
/ardrone/front/image_raw/compressed/parameter_descriptions
/ardrone/front/image_raw/compressed/parameter_updates
/ardrone/front/image_raw/compressedDepth
/ardrone/front/image_raw/compressedDepth/parameter_descriptions
/ardrone/front/image_raw/compressedDepth/parameter_updates
/ardrone/front/image_raw/theora
/ardrone/front/image_raw/theora/parameter_descriptions
/ardrone/front/image_raw/theora/parameter_updates
/ardrone/image_raw
/ardrone/image_raw/compressed
/ardrone/image_raw/compressed/parameter_descriptions
/ardrone/image_raw/compressed/parameter_updates
/ardrone/image_raw/compressedDepth
/ardrone/image_raw/compressedDepth/parameter_descriptions
/ardrone/image_raw/compressedDepth/parameter_updates
/ardrone/image_raw/theora
/ardrone/image_raw/theora/parameter_descriptions
/ardrone/image_raw/theora/parameter_updates
```
### Sim Camera ###

### Navigation ###
```
/ardrone/imu
```

  * Not Published

```
/ardrone/mag
```

```
/ardrone/navdata
```
Type:ardrone\_autonomy/Navdata

Sample Message:
```
header: 
  seq: 6528
  stamp: 
    secs: 1396979899
    nsecs: 256982834
  frame_id: ardrone_base_link
batteryPercent: 72.0
state: 2
magX: 68
magY: -100
magZ: -68
pressure: 98647
temp: 335
wind_speed: 0.0232343282551
wind_angle: -82.8048019409
wind_comp_angle: 0.0
rotX: -3.18799996376
rotY: -3.23300004005
rotZ: -24.920999527
altd: 0
vx: 0.0
vy: -0.0
vz: -0.0
ax: 0.152488067746
ay: 0.0058117271401
az: 0.92906743288
motor1: 0
motor2: 0
motor3: 0
motor4: 0
tags_count: 0
tags_type: []
tags_xc: []
tags_yc: []
tags_width: []
tags_height: []
tags_orientation: []
tags_distance: []
tm: 192302336.0
```
```
/ardrone/predictedPose
```

  * Header
  * x,y,z
  * dx,dy,dz
  * roll,pitch,yaw,dyaw
  * droneState
  * batteryPercent

```
/tf
```

  * Header
  * transform translation: x,y,z
  * transform rotation: x,y,z,w
### Commands ###
```
/ardrone/land
/ardrone/reset
/ardrone/takeoff
```

```
/cmd_vel
```

  * linear: x,y,z
  * angular: x,y,z

### Other ###
```
/drone_autopilot/parameter_descriptions
/drone_autopilot/parameter_updates
/drone_stateestimation/parameter_descriptions
/drone_stateestimation/parameter_updates
/joy
/rosout
/rosout_agg
/tum_ardrone/com
```


## References ##
[ROS Fuerte Installation](http://wiki.ros.org/fuerte/Installation/Ubuntu)

[tum\_ardrone ROS package](http://wiki.ros.org/tum_ardrone)

[V-REP ROS Tutorial](http://www.coppeliarobotics.com/helpFiles/en/rosTutorial.htm)