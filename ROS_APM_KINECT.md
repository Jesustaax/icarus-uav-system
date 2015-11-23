[Operating Instructions](ROS_APM_KINECT#Operating-Instructions.md)
[ROS Code](ROS_APM_KINECT#ROS-Code.md)
[APM](ROS_APM_KINECT#APM-Code.md)
# Introduction #

The objective of this project was to implement a system that has a computer running ROS with a Kinect doing target tracking, and outputting commands via MAVLink to an APM Board.

[Project Overview Video Part 1](http://www.youtube.com/watch?v=X8OeJrsW6gA&feature=youtu.be)

[Project Overview Video Part 2](http://www.youtube.com/watch?v=i3rCjBmssP0&feature=youtu.be)

[Preliminary Project Report](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ROS_APM/ROS_APM_Kinect_Progress_Report.pdf)

[Final Project Report](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ROS_APM/ROS_APM_Kinect_Final_Report.pdf)

## Color Tracking ##
The color tracking in this project has seen the most time of development.  Currently it uses the HSV color model (Hue,Saturation, Luminance) which is better than the RGB color model as it is less prone to difficulties with different lighting environments.  The way it works is to run the program with the parameter:
```
--target-track=color_track
```
And then double-click on the camera window what color you would like to track.
![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ROS_APM/ColorTrack1.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ROS_APM/ColorTrack1.jpg)

At a resolution of 640x480, the Color Tracking program runs at about 30 FPS on my mediocre laptop.

The GUI reports the current Pitch/Yaw angles as reported from the APM, the Pitch/Yaw set angles that the Color Tracker is sending to the APM, the X and Y coordinates of the center of the object being tracked in pixels and inches from the center of the image, the distance to the object in inches, the APM's mode, the color of the object being tracked and the frame rate.

## Motion Tracking ##
I have spent less time on the motion tracking, but it is working quite well.  The way that it works is the program takes a screenshot and compares it to the last screenshot it saved.  By subtracting the two and performing some image processing tasks it can determine what is the primary object that has changed, and it draws a bounding box and a center of that object.  To run this mode, run the program with the parameter:
```
--target-track=motion_track
```
![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ROS_APM/MotionTrack1.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ROS_APM/MotionTrack1.jpg)
At a resolution of 640x480, the Motion Tracking program runs at about 30 FPS on my mediocre laptop.

The GUI reports the current Pitch/Yaw angles as reported from the APM, the Pitch/Yaw set angles that the Motion Tracker is sending to the APM, the X and Y coordinates of the center of the object being tracked in pixels and inches from the center of the image, the distance to the object in inches, the APM's mode, the color of the object being tracked and the frame rate.

## Optical Flow ##
I have spent the least amount of time on this mode, as it was not originally in the scope of the project but I decided to do it for fun. Currently I use the openCV Optical Flow function "calcOpticalFlowPyrLK"
To run this mode, run the program with the parameter:
```
--target-track=optical_flow
```
![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ROS_APM/OpticFlow1.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ROS_APM/OpticFlow1.jpg)
Currently this mode uses the RGB color images from the Kinect at a resolution of 640x480, which yields a frame rate of about 5 at best on my laptop.  This is very slow, but could be implemented using Black/White images instead which should speed the algorithm up considerably.
# Hardware #
![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ROS_APM/Hardware1.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ROS_APM/Hardware1.jpg)

For this Project, I used the following hardware:
  * Kinect Sensor
  * APM
  * Parallax Quickstart
  * FAST Robotics Quickstartplus
  * ESC
  * NiMh Battery Pack
  * USB 2.0 Hub
  * 2 Servo's
  * 3DR Wireless Radio
  * 3DR Power Distribution Board

# Details #

## System Overview ##
  * [System Diagram](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/LogicalDesign/SystemDiagram.png)
  * Work Not Completed
    * Auto-start Script
    * Clean up Code
    * Recommend Embedded Controller as a ROS Node
    * Plan implementation for Embedded Controller
  * Work Completed
    * All Electronics Assembled
    * ROS Installation/Configuration
    * ROS To/From APM Communication
    * ROS Set RC Channels Directly (Optional)
    * ROS Set Pitch/Roll Setpoints
    * Kinect Color blob tracking
    * Code Integration:  Kinect and APM\_ROS Code in same project.
    * Target Pitch Setpoints
    * Target Yaw Setpoints
    * Measure Distance to Target
    * Wiki Documentation
    * Finish mounting hardware/cables
    * Implement on ArduCopter
    * Pick color using Mouse
    * Motion Tracking
    * Picking Tracking mode via command line arguments
    * Configure ROS Node to communicate with GCS: Serial & Wifi (UDP)
    * Upload to CVRL BitBucket:  [Link](https://bitbucket.org/uicrobotics/ros_apm_kinect/wiki/Home)
  * Future Work
    * Image Tracking adjusts Roll Angle
    * Integrate ROS w/ GCS System
    * Track other kinds of Targets (geometry, etc)
    * Implement on an Embedded Controller

## Components ##
### Laptop ###
[![](https://wiki.ubuntu.com/IconsPage?action=AttachFile&do=get&target=iconCircle48.png)](http://www.ubuntu.com/download/desktop)
![http://www.warp1337.com/sites/www.warp1337.com/files/fuerte-320w.jpg](http://www.warp1337.com/sites/www.warp1337.com/files/fuerte-320w.jpg)
> A laptop running Ubuntu 12.04 was installed with the Robot Operating System (ROS)-Fuerte.  A laptop was used as it would simplify development, and the usage of ROS implies that it is somewhat device independent.   Here's a list of dependent packages:
    * [MAVLink](https://github.com/mavlink/mavlink)
    * [Openni Kinect Driver](http://www.ros.org/wiki/openni_kinect)

### APM-Code ###

![http://store.diydrones.com/v/vspfiles/photos/BR-ArduPilotMega-03-2T.jpg](http://store.diydrones.com/v/vspfiles/photos/BR-ArduPilotMega-03-2T.jpg)
> The [DIYDrones APM](http://store.diydrones.com/APM_2_0_Kit_p/br-ardupilotmega-03.htm) is already used as a Flight Controller in the ICARUS QTW Flyer.  While it has many functions, including an AHRS System, it lacks the ability to connect to more advanced sensors (such as the Kinect) and the programming space left (after using the Arduplane/Arducopter code) is quite small.  This project slightly modified the ArduPlane 2.68 Default Code.  The download listed above contains the complete APM code required for this project.  If you'd like to make the necessary changes to your own code here they are:

#### ArduPlane Firmware ####
##### Arduplane.ino #####
After the `// Roll, pitch, yaw and thrust commands` lines:
```
 #if ATTITUDE_COMMAND == ENABLED
 static bool in_command = false;
 static uint32_t command_fs_timer;
 static long roll_command;
 static long pitch_command;
 static long yaw_command;
 static int thrust_command;
 #endif
```

In the update\_current\_flight\_mode(void) function, in the default case after calc\_throttle();
```
#if ATTITUDE_COMMAND == ENABLED

            check_command();
            if (in_command) 
            {
                    nav_pitch_cd = pitch_command;
                    nav_roll_cd = roll_command;
                    g.channel_throttle.servo_out = thrust_command;
                    g.channel_rudder.servo_out = yaw_command;
            }
            else
            {
              
            }
#endif
```

Before the check\_command() function:
```
#if ATTITUDE_COMMAND == ENABLED
 static void check_command() {
      if (millis() - command_fs_timer > FAILSAFE_SHORT_TIME) {
        in_command = false;       
      }
 }
 #endif
```

##### Attutide.ino #####
Unfortunately the ArduPlane 2.68 Code does not perform Yaw PID Control as it does with Pitch and Roll.  So instead of setting the desired Yaw state, we have to set the desired Yaw Servo Angle directly.  This requires the following modification in the calc\_nav\_yaw function:

```
#if APM_CONTROL == DISABLED
#if ATTITUDE_COMMAND == DISABLED
    // always do rudder mixing from roll
    g.channel_rudder.servo_out = g.kff_rudder_mix * g.channel_roll.servo_out;
#endif
    // a PID to coordinate the turn (drive y axis accel to zero)
    Vector3f temp = ins.get_accel();
    int32_t error = -temp.y*100.0;
#if ATTITUDE_COMMAND == DISABLED
    g.channel_rudder.servo_out += g.pidServoRudder.get_pid(error, speed_scaler);
#endif
#else // APM_CONTROL == ENABLED
    // use the new APM_Control library
	g.channel_rudder.servo_out = g.yawController.get_servo_out(speed_scaler, ch4_inf < 0.25) + g.channel_roll.servo_out * g.kff_rudder_mix;
#endif
}
```

##### config.h #####
Add:
```
#ifndef ATTITUDE_COMMAND
#define ATTITUDE_COMMAND ENABLED
#endif
```

##### GCS\_Mavlink.ino #####
In the GCS\_MAVLINK::handleMessage function:
```
 #if ATTITUDE_COMMAND == ENABLED              
     case  MAVLINK_MSG_ID_SET_ROLL_PITCH_YAW_THRUST:
         { 
           // Allows a ground control station to command attitude/thrust set points
             //if(msg->sysid != g.sysid_my_gcs) break;            // Only accept control from our gcs
             mavlink_set_roll_pitch_yaw_thrust_t packet;
             mavlink_msg_set_roll_pitch_yaw_thrust_decode(msg, &packet);
             if (mavlink_check_target(packet.target_system,packet.target_component)) break;
                 
             roll_command = (long)(mavlink_msg_set_roll_pitch_yaw_thrust_get_roll(msg)*100.0*180.0/3.14159);
             pitch_command = (long)(mavlink_msg_set_roll_pitch_yaw_thrust_get_pitch(msg)*100.0*180.0/3.14159);
             yaw_command = (long)(mavlink_msg_set_roll_pitch_yaw_thrust_get_yaw(msg)*100.0*180.0/3.14159);
             thrust_command = (int)(mavlink_msg_set_roll_pitch_yaw_thrust_get_thrust(msg)*100.0);            
             
             in_command = true;
             command_fs_timer = millis();
             break;
         }
 #endif
```

#### ArduCopter Firmware ####
For the ArduCopter Firmware, we need to set each yaw, roll and pitch variable in their separate functions, unlike the ArduPlane software.  Also, we bypass all the normal flight modes if the ROS\_COMMAND\_MODE is Enabled, which ensures that the APM doesn't enter a state that we don't want it to enter.
##### ArduCopter.ino #####
In the Global Variables:
```
#if  ROS_COMMAND_MODE == ENABLED
  static long ros_roll_command;
  static long ros_pitch_command;
  static long ros_yaw_command;
  static int ros_thrust_command;
#endif
```
In the update\_yaw\_mode function:
Add a `#if ROS_COMMAND_MODE == DISABLED` and `#endif` around the enter code in this function.  After the `#endif`, add:
```
#if ROS_COMMAND_MODE == ENABLED
        nav_yaw = ros_yaw_command;
        get_stabilize_yaw(nav_yaw);
#endif
```
Continue with this process, for each update\_x\_mode(i.e. in update\_yaw\_mode, update\_roll\_pitch\_mode, update\_throttle\_mode), bypass all the normal code by using the above process.
In the update\_roll\_pitch\_mode, add:
```
#if ROS_COMMAND_MODE == ENABLED
        nav_roll = ros_roll_command;
        nav_pitch = ros_pitch_command; 
        get_stabilize_roll(nav_roll);
        get_stabilize_pitch(nav_pitch);
#endif
```
In the update\_throttle\_mode, add:
```
#if ROS_COMMAND_MODE == ENABLED
    set_throttle_out(ros_thrust_command, false);
#endif
```
We have to initialize the throttle, or else it will never arm.  In the set\_throttle\_mode, add a case:
```
case THROTTLE_ROS:
            throttle_initialised = true;
```

##### defines.h #####
We need to add several new define statements:
```
#define YAW_ROS  8  //This is the Yaw Flight Mode when controlled by a ROS System
#define ROLL_PITCH_ROS 6  //This is the Roll/Pitch Flight Mode when controlled by a ROS System
#define THROTTLE_ROS  9   //This is the Throttle Flight Mode when controlled by a ROS System
```

##### GCS\_Mavlink.ino #####
I want to blink an led whenever I transmit an attitude command via MAVLink:
in the send\_attitude() function, add:
```
digitalWrite(B_LED_PIN, !digitalRead(B_LED_PIN));
```
I need to add a message handler for the MAVLINK\_SET\_ROLL\_PITCH\_YAW\_THRUST command.  In the GCS\_MAVLINK::handleMessage function, add:
```
case MAVLINK_MSG_ID_SET_ROLL_PITCH_YAW_THRUST://56
    { 
             // Allows a ground control station to command attitude/thrust set points
             //if(msg->sysid != g.sysid_my_gcs) break;            // Only accept control from our gcs
             mavlink_set_roll_pitch_yaw_thrust_t packet;
             mavlink_msg_set_roll_pitch_yaw_thrust_decode(msg, &packet);
             if (mavlink_check_target(packet.target_system,packet.target_component)) break;
                 
             ros_roll_command = (long)(mavlink_msg_set_roll_pitch_yaw_thrust_get_roll(msg)*100.0*180.0/3.14159);
             ros_pitch_command = (long)(mavlink_msg_set_roll_pitch_yaw_thrust_get_pitch(msg)*100.0*180.0/3.14159);
             ros_yaw_command = (long)(mavlink_msg_set_roll_pitch_yaw_thrust_get_yaw(msg));
             ros_thrust_command = (int)(mavlink_msg_set_roll_pitch_yaw_thrust_get_thrust(msg)*1000.0);            
             
             break;
         }
```
##### system.ino #####
During the startup procedure I need to arm the motors, and not set a different flight mode.  Bypass the mode changes with a `if ROS_COMMAND_MODE == DISABLED` and the corresponding `#endif`.  Then, add this:
```
#if ROS_COMMAND_MODE == ENABLED
    mode = AUTO;
    control_mode            = AUTO;
    init_arm_motors();
#endif
```

##### UserCode #####
Finally, we need to give the APM a throttle setting higher than 0.  This is done in the userhook\_50hz() function:

```
g.rc_3.control_in = 100;
```

### Kinect Sensor ###
![http://img.gawkerassets.com/img/17nnc7oa1rdrijpg/xlarge.jpg](http://img.gawkerassets.com/img/17nnc7oa1rdrijpg/xlarge.jpg)

> This [Kinect Sensor](http://www.amazon.com/Kinect-Sensor-Adventures-Xbox-360/dp/B002BSA298/ref=sr_1_1?ie=UTF8&qid=1360093357&sr=8-1&keywords=kinect+xbox) was purchased through UIC to be used on this project.

# ROS-Code #
The full ROS Code can be downloaded in the downloads section.  However, here is some useful information on the ROS Node Script.


# Operating-Instructions #
# Start the ROS Core
In Terminal 1:
```
roscore
```
# Start the Kinect Camera Driver
In Terminal 2:
```
roslaunch openni_launch openni.launch
```
# Start the ROS Node Script
In Terminal 3:
```
rosmake ros_apm_kinect
roscd ros_apm_kinect
sudo chmod 0777 /dev/ttyACM0
nodes/ros_apm_kinect.py --apm-device=/dev/ttyACM0 --apm-baudrate=115200
```
# Options #
Currently, the following options can be employed:
  * Run Color Track Mode
When starting the ROS Node, use this line instead:
```
nodes/ros_apm_kinect.py --apm-device=/dev/ttyACM0 --apm-baudrate=115200 --target-track=color_track
```
  * Run Motion Track Mode
When starting the ROS Node, use this line instead:
```
nodes/ros_apm_kinect.py --apm-device=/dev/ttyACM0 --apm-baudrate=115200 --target-track=motion_track
```
  * Run Optical Flow Track Mode
When starting the ROS Node, use this line instead:
```
nodes/ros_apm_kinect.py --apm-device=/dev/ttyACM0 --apm-baudrate=115200 --target-track=optical_flow
```
  * Link to GCS
It is possible to link this system to a GCS.  Currently it only supports sending Heartbeat (#0) and Attitude (#30) MAVLink Packets.  To connect to a GCS over a Serial Connection use this:
```
nodes/ros_apm_kine.py --apm-device=/dev/ttyACM0 --apm-baudrate=115200 --target-track=None --gcs-device=/dev/ttyUSB0 --gcs-baudrate=57600 --gcs-device-type=Serial
```
To connect to a GCS over a UDP Connection, (where the gcs-device is the ip address of the GCS), use this:
```
nodes/ros_apm_kinect.py --apm-device=/dev/ttyACM0 --apm-baudrate=115200 --gcs-device-type=udp --gcs-device=10.7.45.208
```

# Troubleshooting #
To view the RGB image from the Kinect, open a new terminal and use:
```
rosrun image_view image_view image:=/camera/rgb/image_color
```

To view the depth image from the Kinect, open a new terminal and use:
```
rosrun image_view image_view image:=/camera/depth/image
```

## References ##
The following were different resources used for completion of this project:

[ROS & Kinect-Ubuntu Installation](http://robotas.at/ros-and-kinect-ubuntu-installation/)

[Kinect and ROS Tutorial](http://bi.snu.ac.kr/Courses/4ai12s/Projects/KinectWithROSTutorial.pdf)

[Vision, Learning and Robotics](http://surenkum.blogspot.com/2012/06/getting-kinect-to-work.html)

[Doug's Robotics Blog-ROS/Kinect Skeleton Tracking](http://dougsbots.blogspot.com/2012/02/ros-kinect-skeleton-tracking.html)

[Kinect Teardown](http://www.ifixit.com/Teardown/Microsoft-Kinect-Teardown/4066/2)

[MIT Kinect Demos](http://www.ros.org/wiki/mit-ros-pkg/KinectDemos#General_Installation)

[ROS & MAVLink Bridge](https://github.com/mavlink/mavlink_ros)

[Pixhawk MAVLink ROS Package](https://github.com/pixhawk/mavlink-ros-pkg)

[ROS & Arduino Python Node](http://diydrones.com/profiles/blog/show?id=705844%3ABlogPost%3A293351&commentId=705844%3AComment%3A293361)

[APM & MAVLink](https://code.google.com/p/ardupilot-mega/wiki/MAVLink)

[DIYDrones APM](https://code.google.com/p/ardupilot-mega/)

I'd also like to thank the following people/organizations for their contributions to this project:
  * The UIC CVRL Robotics Laboratory.
  * Loughborough University Centre for Autonomous Systems for their [source code](https://code.google.com/p/lucas-research/wiki/APMSimulink) dealing with interfacing the APM with MAVLink.
  * Yogesh Girdhar for his contributions with interfacing the [APM with ROS](https://www.google.com/search?q=roscopter&aq=f&oq=roscopter&aqs=chrome.0.59l2j60j62l3.997&sourceid=chrome&ie=UTF-8).