# Primary Controller #

[Operating Instructions](PrimaryController#Operating-Instructions.md)

[Source Code](https://github.com/dgitz/icarus_pc)

![http://com.odroid.com/sigong/_Files/2012/201211/images/201211151702013304.jpg](http://com.odroid.com/sigong/_Files/2012/201211/images/201211151702013304.jpg)
![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/PrimaryController/top.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Components/PrimaryController/top.jpg)

# Configuration #
  * Image: [Ubuntu 12.11 Robotics Edition v2 (ROS+OpenCV+OpenNI+PCL) X2 Image](http://forum.odroid.com/viewtopic.php?f=15&t=2090)
  * Ethernet IP Address:  10.7.44.119
  * Wlan IP Address:  10.7.45.158
  * Hostname:  linaro-ubuntu-desktop

# Remote Operation via WiFi #
  1. Remote Desktop into OLDHP-LAPTOP-UBUNTU
  1. Ensure WiFi Network on this Laptop is CVRL
  1. Open a Terminal
  1. Open a Putty Session
  1. Load: icaruspc-wlan and Open
  1. Login with linaro/linaro

# Remote Operation via Console #
  1. Remote Desktop into OLDHP-LAPTOP-UBUNTU
  1. Open a Terminal
  1. Enter the following:
```
sudo chmod 0777 /dev/ttyUSB0
```
  1. Open a Putty Session
  1. Load: icaruspc-console and Open
  1. Press Enter

## Modules installed ##
  * pp - TODO
  * pybrain - TODO
  * opencv2

## HDMI Output ##
```
sudo nano /etc/X11/xorg.conf
"Option "fbdev" "/dev/fb6"
```

# Operating-Instructions #
  1. Either do [Manual Start](PrimaryController#Manual.md) or [Automatic Start](PrimaryController#Automatic.md)
  1. [Image Acquisition (for ANN Training)](PrimaryController#ImageAcquisition.md)

## Automatic ##
  1. Open a New Terminal and enter
```
su roscore &
roslaunch icarus_pc xtion+icarus_pc.launch
rosrun icarus_pc primarycontroller.py
```
## Manual ##
### Start Xtion Camera ###
  1. Open a New Terminal and enter
```
su roscore &
cd ~/catkin_ws
source ./devel/setup.bash
rosrun icarus_pc xtionsender
```
## Test Xtion Camera Publisher ##
  1. Open a New Terminal and enter
```
rosrun icarus_pc listener.py
```

## ImageAcquisition ##
  1. Open a New Terminal and enter:
```
rosrun icarus_pc primarycontroller.py --targetmode=Acquire --target_acquire_class=Stupid2 --target_acquire_rate=50 --target_acquire_count=25

```
## To Compile Xtion Camera Code ##
  1. Open a New Terminal and enter
```
cd ~/catkin_ws
catkin_make
```

# Notes #


# Troubleshooting #
[ODroid Forum](http://forum.odroid.com/viewforum.php?f=15)

[Troubleshooting Guide](http://forum.odroid.com/viewtopic.php?f=15&t=936)

## Display ##
http://forum.odroid.com/viewtopic.php?=0&t=2083&p=16527&hilit=lcd#p16527

http://forum.odroid.com/viewtopic.php?f=15&t=600&p=2701&hilit=lcd#p2701
# Documentation #

## Kinect Integration ##
[How to convert an an opencv image using cvBridge??](http://answers.ros.org/question/32880/how-to-convert-an-an-opencv-image-using-cvbridge/)

[Converting between ROS images and OpenCV images (C++)](http://wiki.ros.org/cv_bridge/Tutorials/UsingCvBridgeToConvertBetweenROSImagesAndOpenCVImages)

[Working with ROS and OpenCV](http://siddhantahuja.wordpress.com/2011/07/20/working-with-ros-and-opencv-draft/)


## Basic ROS Stuff ##
[Odroid-X2 Specifications and Ordering Info](http://www.hardkernel.com/renewal_2011/products/prdt_info.php?g_code=G135235611947)

[ODroid-X2 Ubuntu, ROS Image](http://forum.odroid.com/viewtopic.php?f=15&t=2090)

[Image Flashing on SD Card (Linux)](http://forum.odroid.com/viewtopic.php?f=53&t=23)

[[Archlinux install instructions](http://archlinuxarm.org/platforms/armv7/samsung/odroid-x)

[Basic Linux instructions on ODroid](http://www.linux.com/learn/tutorials/711478-how-to-run-linux-on-odroid-u2-a-monster-of-an-arm-machine)

[ODroid Forum for X2 Ubuntu](http://forum.odroid.com/viewforum.php?f=15)

[ODroid T-Shooting Guidelines](http://forum.odroid.com/viewtopic.php?f=61&t=936)

[In-depth imaging instructions](http://com.odroid.com/sigong/blog/blog_list.php?bid=130)

[Official ODroid Image Repository](http://com.odroid.com/sigong/nf_file_board/nfile_board.php?keyword=&tag=&page=2)