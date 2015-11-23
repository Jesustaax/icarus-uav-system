# Introduction #

This page shows different logical diagrams of the ICARUS QTR Flyer.  Logical Diagrams are used to show relationships and communication between different elements of this system.

# General Overview #

## Hardware Description ##

### Main Controller ###
  * ROS Machine
  * Set Waypoints using GPS Sensor (Outdoor) or Waypoints derived from SLAM/Target Identification (Indoor)
  * Performs SLAM
  * Front Collision Avoidance Sensors (Kinect Depth)
  * Provides Forward Collision Data to Flight Executor


### Flight Executor ###
  * Need a new name.
  * DIY Drones APM 2.0 (2.5 in the Future) running Arducopter Code
  * Controls Rotor Speed
  * Controls Rotor Tilt
  * Battery Power Monitoring

### I/O Board ###
  * Parallax Quickstart & FAST Robotics QuickStartPlus
  * Side/Top/Bottom Collision Avoidance Sensors (Ultrasonics)
  * Provides Side/Top/Bottom Collision Data to Flight Executor
  * All Data Logging
  * Backup Motor Controller for the Flight Executor (Future)
  * Any Manipulator Accessories (Future)

### Manual Control Board ###
  * Provides Redundant R/C Control in case of severe in-flight emergency (Bypasses Flight Executor).

# Diagrams #

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/LogicalDesign/SystemDiagram.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/LogicalDesign/SystemDiagram.png)
This is a general Logical Diagram of the ICARUS Flyer.