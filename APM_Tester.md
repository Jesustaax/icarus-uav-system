# APM Tester #

[Test-Patterns](APM_Tester#Test-Patterns.md)

[Results](APM_Tester#Results.md)

[Source Code](https://bitbucket.org/uicrobotics/apm_tester/src)

[Code Issues](https://bitbucket.org/uicrobotics/apm_tester/issues?status=new&status=open)

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/TestRig_1.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/TestRig_1.jpg)
![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/TestRig_2.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/TestRig_2.jpg)
# Introduction #

The objective of this project was to analyze and provide documentation on the precision and accuracy of the Ardupilot Mega, or APM.  The APM is a fantastic piece of engineering marvel created by 3D Robotics and improved upon by the DIYDrones community, and is one of the most popular and cheapest autopilot/AHRS systems for robots available.  However, there is a significant lack of proper engineering data, such as how stable the board is overtime, how accurate it is, etc. that prompted this project.  Additionally there has been some speculation amongst our lab engineers of how stable the APM is over time, along with how it performs AHRS duties in an indoor environment (i.e. GPS-denied) and near EM fields, such as brushed/brushless motors.

At the UIC Robotics Lab, we also have access to a few PUMA Robot Manipulators.  It was determined this would be a good platform to test the APM on, as it is a stable and accurate robot arm with many more degrees of freedom than are measured by the APM.

Although all the design and software information is made available on this site, it is not intended that this project would be replicated (unless for verification purposes) as the PUMA robot is not a common fixture in a robotics lab.  This webpage is more intended to document the way the testing data was gathered for independent analysis and educational purposes.  However, if you would like to reproduce this project by all means go for it!


# Methodology #
A series of tests were carried out on the APM by rotating 3 axis's of the PUMA robot, performing data collection on the APM for a specified period of time and proceeding on to the next test.  Although the PUMA robot is an industrial grade robot, it is unknown to what precision its sensors are.  So the PUMA robot was used to provide a stable platform and the angle readings from the APM were the only sensors used in these tests.  QGroundControl performed data logging on the M1:ATTITUDE.roll, M1:ATTITUDE.pitch and M1:ATTITUDE.yaw packets.  Finally, a Matlab program was written to provide data analysis, such as graphing each test, the drift rate of each axis on each test, and calculating average results for each specified axis.  NOTE:  Since the Yaw Angle on the APM is calculated using the Compass on board, All Yaw Angles in the Tests section below are referenced from the initial Yaw Angle.  However, in the actual Yaw Data the actual APM Yaw angle is reported.

# Experiment Setup #
APM Board: v2.0
APM Firmware: 2.9.1b
The APM is attached to the tool-end of a PUMA robot via heavy-duty velcro.  The APM was connected to QGroundControl by USB cable.  QGroundControl performed data logging on the M1:ATTITUDE.roll, M1:ATTITUDE.pitch and M1:ATTITUDE.yaw packets.

# Test-Patterns #
| **Test#** | **Desired Roll Angle** | **Desired Pitch Angle** | **Yaw Desired Angle** | **Run-Time (min)** |
|:----------|:-----------------------|:------------------------|:----------------------|:-------------------|
| 1         | 0                      | 0                       | 0                     | 15                 |
| 2         | 0                      | 0                       | 90                    | 15                 |
| 3         | 0                      | 0                       | 180                   | 15                 |
| 4         | 0                      | 0                       | 270                   | 15                 |
| 5         | 0                      | 45                      | 0                     | 15                 |
| 6         | 0                      | 90                      | 0                     | 15                 |
| 7         | 0                      | -45                     | 0                     | 15                 |
| 8         | 0                      | -90                     | 0                     | 15                 |
| 9         | 45                     | 0                       | 0                     | 15                 |
| 10        | 90                     | 0                       | 0                     | 15                 |
| 11        | -45                    | 0                       | 0                     | 15                 |
| 12        | -90                    | 0                       | 0                     | 15                 |
| 13        | 0                      | 45                      | 0                     | 30                 |
| 14        | 0                      | 45                      | 90                    | 30                 |
| 15        | 0                      | 45                      | 180                   | 30                 |
| 16        | 0                      | 45                      | 270                   | 30                 |

# Results #
Here are two figures from these tests (the rest are listed below).  The first shows a typical result, showing the high amount of accuracy on each sensor axis.  The second shows the worst result, coming from the Yaw Axis.

## Good Test Run ##
![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/GoodTest.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/GoodTest.png)

## Not So Good Test Run ##
![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/BadTest.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/BadTest.png)

| **Test#** | **1st Roll Angle** | **Avg Roll Angle** | **Avg Roll Error** | **1st Pitch Angle** | **Avg Pitch Angle** | **Avg Pitch Error** | **1st Yaw Angle** | **Avg Yaw Angle** | **Avg Yaw Error** |
|:----------|:-------------------|:-------------------|:-------------------|:--------------------|:--------------------|:--------------------|:------------------|:------------------|:------------------|
| 1         | -8.01              | -8.03              | -.019              | -1.23               | -1.18               | .046                | 54.81             | 54.87             | .066              |
| 2         | -8.01              | -8.03              | -.025              | -1.10               | -1.10               | -.005               | -14.51            | -14.92            | -.414             |
| 3         | -8.18              | -8.15              | .025               | -1.01               | -1.11               | -.092               | -147.66           | -147.16           | .501              |
| 4         | -8.17              | -8.17              | -.003              | -1.18               | -1.22               | -.041               | 98.41             | 98.79             | .385              |
| 5         | -10.45             | -9.99              | .455               | 42.27               | 42.4                | .132                | 57.43             | 56.54             | .894              |
| 6         | -72.93             | -73.35             | -.419              | 81.73               | 81.63               | -.1                 | -10.46            | -5.61             | 4.851             |
| 7         | -12.0              | -12.15             | -.148              | -45.12              | -45.13              | -.009               | 56.1              | 56.34             | .236              |
| 8         | -92.78             | -92.43             | .354               | -81.35              | -81.36              | -.006               | 141.14            | 141.82            | .677              |
| 9         | -51.45             | -51.5              | -.053              | -5.29               | -5.32               | -.028               | 55.35             | 55.57             | .215              |
| 10        | -91.7              | -91.61             | .083               | 1.49                | 1.47                | -.019               | 64.03             | 60.48             | -3.552            |
| 11        | 36.93              | 36.87              | -.06               | 4.59                | 4.77                | .183                | 40.27             | 40.48             | .211              |
| 12        | 83.83              | 83.89              | .068               | .13                 | .3                  | .171                | 49.87             | 54.54             | 4.579             |
| 13        | -10.51             | -10.37             | .14                | 41.51               | 41.56               | .049                | 57.15             | 56.98             | -.17              |
| 14        | -10.15             | -10.38             | -.23               | 41.83               | 41.73               | -.097               | -55.72            | -55.07            | .647              |
| 15        | -10.6              | -10.55             | .056               | 41.78               | 41.72               | -.061               | -152.1            | -151.87           | .237              |
| 16        | -10.54             | -10.53             | .018               | 41.66               | 41.57               | -.095               | 106.34            | 106.81            | .464              |

For the most part, we found that the the Pitch and Roll axis's were highly accurate, with less than +/-1 degree of an error for the Roll Axis and less than +/-.2 degrees for the Pitch Axis.  The Yaw Error went as high as +/-5 degrees at points, but usually stayed to within 2 degrees.  This can be seen in the figure below.

## Final Results ##
![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/Results.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/Results.png)
# Future Work #
  * Test dynamic situations, such as how quickly and how accurately the APM reports AHRS data as it moves.
  * Perform the same tests with a EM field producer, such as mounting an ArduCopter onto the PUMA robot and varying the throttle, and analyzing how this affects the AHRS data.

# Files #
[Log Files & Images](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/8-July-2013-PUMA.zip)

[Matlab Code](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/APM_Tester/MainProgram_QGroundControl.zip)