# Introduction #

Provided here is documentation on the software running on the ICARUS Flyer as well as software that is directly used to support the design/analysis process on the ICARUS Flyer.

[Primary Controller Code](https://github.com/dgitz/icarus_pc)
This code is meant to run on an ODroid-X2 Linux Board.  See [the PC wikipage](https://code.google.com/p/icarus-uav-system/wiki/PrimaryController) for more information.

[Flight Controller Code](https://github.com/dgitz/icarus_fc)
This code is meant to run on a 3DR ArdupilotMega 2.0.  See [the FC wikipage](https://code.google.com/p/icarus-uav-system/wiki/FlightController) for more information.

[Motion Controller Code](https://github.com/dgitz/icarus_mc)
This code is meant to run on a Parallax Propeller.  See [the MC wikipage](https://code.google.com/p/icarus-uav-system/wiki/MotionController) for more information.

[Support Code](https://github.com/dgitz/icarus_support)
This repository is meant for all official documentation of the ICARUS Flyer along with other support code, simulation, testing, etc.

# Future Work #
## Aero Design ##
  * Center of Gravity/Center of Pitching Moment Axis Optimization
  * Front/Back Wing Area/Span Optimization

## Flyer Analysis ##
  * Improvements in Analysis software (MatLab APM Analyzer)

## Flyer Controls ##
  * Secondary Controller Software

# Software #

## Onboard ##

### Navigation ###
  * Obstacle Avoidance using Splines
  * Setting waypoints using available signage
  * Local Path Planning using SLAM: Including Ingress/Egress

### Main Controller ###
  * ROS Machine
  * Set Waypoints


### Flight Executer ###
  * Need a new name.
  * DIY Drones APM running Arducopter Code
  * Control Servo Tilt?
  * 

### I/O Board ###
  * Parallax Quickstart & FAST Robotics QuickStartPlus
  * Control Servo Tilt?
  * Collision Avoidance Sensors (Ultrasonics)


## Analysis ##
### APM Analyzer ###
Current Version:  1.0
This software was created in MatLab and is used to analyze the Data Logs of the DIYDrones APM (2.0 or 2.5).  If you do not have MatLab all you need for this software is the MatLab RunTime Compiler, which is free. The original source code is also available in the download.

[APMAnalyzer Software](http://code.google.com/p/icarus-uav-system/downloads/detail?name=APMAnalyzerv1.0.zip&can=2&q=)

### AirFoil Optimizer ###
Current Version: 1.0
This software was created in MatLab and is used to help select an airfoil given constraints.  It uses the airfoil data collected from [UIUC](http://www.ae.illinois.edu/m-selig/ads/coord_database.html) and you can then filter and graph the airfoil data as you see fit. If you do not have MatLab all you need for this software is the MatLab RunTime Compiler, which is free. The original source code is also available in the download.

[Airfoil Optimizer](http://code.google.com/p/icarus-uav-system/downloads/detail?name=AirfoilOptimizerv1.0.zip&can=2&q=)


# References #
[ArduPlane Repo](http://code.google.com/p/ardupilot-mega/downloads/list)

[ArduCopter Repo](http://code.google.com/p/arducopter/downloads/list)