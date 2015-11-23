[Operating Instructions](TargetDetection#Operation.md)

[Primary Controller Wiki](PrimaryController.md)
[Flight Controller Wiki](FlightController.md)
[Motion Controller Wiki](MotionController.md)

[Primary Controller Source Code](https://github.com/dgitz/icarus_sourcecode/tree/master/PrimaryController)

[Flight Controller Source Code](https://github.com/dgitz/icarus_sourcecode/tree/master/FlightController)

[Motion Controller Source Code](https://github.com/dgitz/icarus_sourcecode/tree/master/MotionController)

# Tasks #

# Milestones #

1. Develop code to acquire a large amount of training/testing images with each of the different signs in a consistent environment. (DONE)

2. Develop code to automatically generate training/testing images using environment images and master target images. (In Progress, completed in Matlab)

3. Develop an Artificial Neural Network (ANN) capable of classifying each image according to which sign is visible (or no sign visible). (In Progress, completed in Matlab)

4. Develop an ANN capable of locating the center of the recognized sign, for the purpose of passing onto a waypoint navigation algorithm. (In Progress, completed in Matlab)

5. Develop the appropriate pre-processing for the images to convert the RGB image data to make each of the above ANN's more effective. (In Progress, completed in Matlab)

6. Use Parallel Processing for Milestone 2 to create training/testing images faster and compare with Milestone 2. (In Progress)

7. Use Parallel Processing for Milestones 3-4 for faster ANN training. (In Pgoress)


# Summary #

[IARC Mission 6 Rules](http://www.aerialroboticscompetition.org/past_missions/pastmissionimages/mission6/mission6scenario.pdf)

The objective of the AUVSI IARC 6th Mission is to have a UAV fly into an office-space (which includes hallways, rooms, rooms off rooms, etc), locate a flash-drive in an unknown location, retrieve the flash drive and leave the office-space.  The office-space is in an environment designed to simulate a foreign government with no access to GPS signals.

Two key parts of the competition are to a) navigate the office-space using the available signage placed in the environment and b) visually identify the flash drive in the office-space.  Both of these components are complex, as the signage is in a foreign language and the flash drive may be placed anywhere in the office-space.

For ease of development, Milestones 1-5 were originally acocmplished using a Windows 7 PC and Matlab's Neural Network Toolbox.  Now, I am working on porting the code over to an ODroid-X2 with the Python Modules PP (Parallel Processing) and PyBrain (Neural Network).

The innovative portion of this project is that different "Master Target Images" could be loaded onto the UAV along with sample Images of the Environment and the UAV would automatically train its ANN's and employ waypoint navigation to navigate a course in a similar environment.

This project is intended for the UIC class ECE 559: Neural Networks and ECE 566: Parallel Processing.

## Hardware Overview ##
### ODroid-X2 ###
The ODroid-X2 is a small Linux Single Board Computer.  Some specs are:
  * 1.7GHz Quad core ARM Cortex-A9 MPCore
  * 2GB Memory
  * 6 x High speed USB2.0 Host port
  * 10/100Mbps Ethernet with RJ-45 LAN Jack

![http://com.odroid.com/sigong/_Files/2012/201211/images/201211151702013304.jpg](http://com.odroid.com/sigong/_Files/2012/201211/images/201211151702013304.jpg)

The ODroid-X2 is running Python code with the following modules:
  * [Pybrain](http://pybrain.org/)
  * [ParallelProcessing](http://www.parallelpython.com/)
  * [Opencv](http://opencv.org/)

### MS Kinect ###
## Basic Operation ##

For navigating around the officespace, there are 3 different offices with associated signage placed in the environment.  These are arabic signs, which translate to "Chief of Security", "Ministry of Torture" and "Security Compound".  The Flash Drive is known to be in the "Chief of Security" office.

To get the current UAV's position, it uses the project shown before in [ICARUS\_SLAM](ICARUS_SLAM.md).  To determine the UAV's waypoints, it uses 2 Neural Networks:  The first one is used to define which sign, if any, is in the current FOV of the UAV.  If the sign in view is the "Chief of Security" sign, the 2nd Neural Network is employed, which identifies the center point of that sign.  The UAV then determines the distance between itself and the center of that sign, and calculates a new waypoint based on its current position, feeds it to the Flight Controller when in turns generates the correct motor outputs to navigate successfully to that sign.

## In Depth Operation ##
  * The UAV preprocesses the images that come from the Kinect.  It converts the RGB image to a grayscale image, and performs some contrast stretching since all the room signs are black text on a white background.
  * A Classification Neural Network (BP) is used to classify each processed image.  The identifiable classes are [ChiefSecurity,MinistryTorture,SecurityCompound,None].
  * If the recognized image class identified is the ChiefSecurity, a second Neural Network is used to determine where in the image is the center of the sign.

# Demos #
[Matlab Image Classification Demo](http://www.youtube.com/watch?v=a0_e6MfYZ2c&feature=youtu.be)

[Matlab Object Localization Demo](http://www.youtube.com/watch?v=vI8BS2Jikn8&feature=youtu.be)

# Media #
![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/SecurityCompound.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/SecurityCompound.png)

Security Compound Sign

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/MinistryTorture.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/MinistryTorture.png)

Ministry of Torture Sign

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/ChiefSecurity.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/ChiefSecurity.png)

Chief of Security Sign

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/cs_orig_image0000.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/cs_orig_image0000.png)

Chief of Security Sign in the environment

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/cs_proc_image0000.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/cs_proc_image0000.png)

Processed Chief of Security Sign suitable for NN classification.

# Installation/Development Instructions #

# Operation #
## Automated Train/Test Image Creation ##
createtrainingimages.py
Options:
```
--Trials
--Patterns
--UseParallel
```
Example:
```
sudo python createtrainingimages.py --Trials=3 --Patterns=11 --UseParallel=True
```
## Automated ANN Training ##

# Resources #

[PyBrain](http://pybrain.org/docs/index.html#tutorials)

[OpenCV Machine Learning](http://docs.opencv.org/modules/ml/doc/ml.html)

[PIRobot Neural Network & ROS](http://www.pirobot.org/blog/0002/)