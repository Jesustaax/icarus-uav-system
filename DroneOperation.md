# Operation #

## Simulation ##
This setup assumes there are 2 computers, a _simserver_ ([simserver code](https://github.com/dgitz/icarus_sim_server)) and a _droneserver_ ([droneserver code](https://github.com/dgitz/icarus_drone_server)) that are fully capable of ROS communication.  See [this link](http://wiki.ros.org/ROS/Tutorials/MultipleMachines) for more information.
The _droneserver_ will run the roscore service.
### On the _droneserver_ ###
In Terminal 1:
```
roscore
```
In Terminal 2:
Identify which joystick will be used using jstest-gdk
```
rosparam set joy_node/dev "/dev/input/js2"
rosrun joy joy_node
```
In Terminal 3:
```
rosrun ardrone_autonomy ardrone_driver
```
In Terminal 4:
```
rosrun icarus_drone_server drone_server.py
```
In Terminal 5:
```
rosrun tum_ardrone drone_stateestimation _mode:=Sim
```
### On the _simserver_ ###
In Terminal 1:
```
cd ~/Desktop/V-REP_PRO_EDU_V3_1_1_64_LINUX
./vrep.sh
```

In V-Rep load the correct scene (in icarus\_sim\_server/vrep\_scenes/ and start the simulation.
## Record Point Cloud ##
```
roscore
```
```
rosparam set joy_node/dev "/dev/input/js1"
rosrun joy joy_node
```
```
rosrun ardrone_autonomy ardrone_driver
```
```
rosrun tf static_transform_publisher 0 0 0 0 0 0 base_link cam_front 100
```
```
rosrun tum_ardrone drone_stateestimation
```
```
rosrun icarus_drone_server drone_server.py
```
```
rosbag record -o DPG /ardrone/imu /ardrone/navdata /ardrone/point_cloud /ardrone/predictedPose /ardrone/std_pose /cmd_vel /tf /tum_ardrone/com
```
```
rosrun pcl_ros bag_to_pcd DPG_2014-03-20-12-01-08.bag /ardrone/point_cloud ./pointclouds
```

## Start Matlab ##
```
sudo openvpn --config ~/Documents/UIC-dgitz2.ovpn
/usr/local/MATLAB/R2013b/bin/matlab
```

## Image Acquisition ##
### Real Image Acquisition (for Pattern Recognition Training) ###
  1. Open a Terminal and Enter:
```
roscore
```
  1. Open a Terminal and Enter:
```
rosrun ardrone_autonomy ardrone_driver
```
  1. Open a Terminal and start the [State Estimation Node](http://wiki.ros.org/tum_ardrone/drone_stateestimation):
```
rosrun tum_ardrone drone_stateestimation
```
  1. Open a Terminal and start the [Drone Autopilot Node](http://wiki.ros.org/tum_ardrone/drone_autopilot):
```
rosrun tum_ardrone drone_autopilot
```
  1. Open a Terminal and start the Image Acquisition Process:
```
rosrun icarus_drone_server drone_server.py --targetmode=Acquire --target_acquire_class='classname'
```
  1. Open Matlab and run the ImageMapper.m script to find and rename each image with the center of the sign.
### Simulated Image Acquisition (for ANN Training) ###
```
python createtrainingimages.py --Patterns=50
```
## Pattern Recognition Training ##
  1. On the Matlab Server:
```
addpath 'prt'
prtPath
prtSetup
```

## Normal Operation ##
  1. Open a Terminal and Enter:
```
roscore
```
  1. Open a Terminal and Enter:
```
rosrun ardrone_autonomy ardrone_driver
```
  1. Open a Terminal and start the [State Estimation Node](http://wiki.ros.org/tum_ardrone/drone_stateestimation):
```
rosrun tum_ardrone drone_stateestimation
```
  1. Open a Terminal and start the [Drone Autopilot Node](http://wiki.ros.org/tum_ardrone/drone_autopilot):
```
rosrun tum_ardrone drone_autopilot
```
  1. Open a Terminal and Enter:
```
rosrun tum_ardrone drone_gui
```
  1. Open a Terminal and Enter:
```
rosrun icarus_drone_server drone_server.py --targetmode=Execute
```
## Software-In-The-Loop Simulation ##

# Tele-Op Control #
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/Controls/JoystickMapping.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/Controls/JoystickMapping.png)
  1. Open a Terminal and Enter:
```
roscore
```
  1. Open a Terminal and Enter:
```
rosrun ardrone_autonomy ardrone_driver
```
  1. Open a Terminal and Enter:
```
rosrun joy joy_node
```
  1. Open a Terminal and Enter:
```
rosrun icarus_drone_server drone_server.py --use_joystick=True
```
# Bag File Record/Playback #
```
rosbag record -o DPG /ardrone/imu /ardrone/navdata /ardrone/point_cloud /ardrone/predictedPose /ardrone/std_pose /cmd_vel /tf /tum_ardrone/com
```
```
rosbag play -r 10 -l "bagfile.bag"
```
[ROS Bag File Record/Playback Tutorial](http://ros.informatik.uni-freiburg.de/roswiki/ROS(2f)Tutorials(2f)Recording(20)and(20)playing(20)back(20)data.html)