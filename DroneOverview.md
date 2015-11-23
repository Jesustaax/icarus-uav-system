The ICARUS Drone Project is designed to give an AR Drone autonomous navigation along with providing a stable platform for developing machine learning algorithms.
# Goals #
## Primary ##
A) The ICARUS Drone should be capable of mapping its environment and determining where in that map it is.

B) The ICARUS Drone should be capable of identifying various Targets Of Interest in its environment and navigating between them.

C) The ICARUS Drone should be capable of interfacing with a simulation environment such that algorithms can be tested in the simulated world, as realistically as possible, before implementing in the real environment.

## Secondary ##
D) The ICARUS Drone should be capable of path planning based on targets placed on the ground.
# Architecture #
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/Architecture/DroneSystemDiagram.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/Architecture/DroneSystemDiagram.png)

# Mapping/Localization #

# Target Identification #
## Media ##
The following are different signs that the ICARUS Drone should be able to recognize in its environment:

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/SecurityCompound.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/SecurityCompound.png)

Security Compound Sign

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/MinistryTorture.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/MinistryTorture.png)

Ministry of Torture Sign

![http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/ChiefSecurity.png](http://dgitz.ipower.com/ICARUSRepo/Media/Projects/ICARUS_NET/ChiefSecurity.png)

Chief of Security Sign

# Simulation #
Using [V-Rep](http://www.coppeliarobotics.com/) I have created a simulation environment where the quadrotor can communicate over ROS and therefore looks identical to the different navigation algorithms running on the _droneserver_.

![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/Simulation/Screenshot1-8Apr2014.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/Simulation/Screenshot1-8Apr2014.jpg)
This is a view of the scene in V-Rep that is similar to our lab space.

![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/Simulation/Screenshot2-8Apr2014.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/Simulation/Screenshot2-8Apr2014.jpg)
This is a view of the [state estimation node](https://github.com/dgitz/tum_ardrone) running using the simulated video.

![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/Simulation/Screenshot3-8Apr2014.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/Simulation/Screenshot3-8Apr2014.jpg)
This is a view of the simulated image & state estimation, along with live video from the AR Drone & state estimation.

# Path Planning #