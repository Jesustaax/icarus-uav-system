[Operating Instructions](ICARUS_ROVER_OA#Operating-Instructions.md)

# Introduction #

Matlab based.

# Tasks #
  1. Develop Vehicle simulation for Ackermann steering UGV based on real-world parameters. - DONE
  1. Develop simulation of rotating Sonar Sensors. - DONE
  1. Develop simulated environment that includes circular Obstacles. - DONE
  1. Develop mapping code between Sonar Sensors and Occupancy Grid. - IN WORK
  1. Develop Obstacle Avoidance code based on Obstacles and random goal position. - NOT STARTED

# Operating-Instructions #
## Vehicle Parameters ##
```
Vehicle.Width = 12; %Inches
Vehicle.Length = 18; %Inches
Vehicle.Current_Point_Angle = 290; %Degrees
Vehicle.Max_Speed = 10; %Inches/Second
Vehicle.Max_Left = -30; %Degrees
Vehicle.Max_Right = 30; %Degrees
Vehicle.Wheel_Radius = 3; %Inches
```
## Sonar Parameters ##
```
Sonar_Beamwidth %Degrees
Sonar_Max_Distance %Inches
SonarSensor_MaxAngle %Degrees
SonarSensor_MinAngle %Degrees
```
## Environment & Obstacle Parameters ##
```

Room_Width = 255; %Inches
Room_Height = 255; %Inches
Obstacle_Density = .3; %Percent
Obstacle_Small_Diameter = 5; %Inches
Obstacle_Large_Diameter = 50; %Inches
```

## Test Scripts ##

  * TestSensorSweep: Sweeps Sonar Sensors back and forth
  * TestVehicleRandomWalk: Randomly drives Vehicle around Environment
  * TestOccupancyGrid: Tests Occupancy Grid functionality

# References #
[D\* Lite Search](http://idm-lab.org/bib/abstracts/papers/aaai02b.pdf)

[ROS gmapping Stack](http://wiki.ros.org/gmapping)

[ROS LaserScan Message](http://docs.ros.org/api/sensor_msgs/html/msg/LaserScan.html)

[ROS navigation Stack](http://wiki.ros.org/navigation)