# Introduction #

This is the Home page for the ICARUS Wiki.  All content is currently completely in development, so use at your own risk.  All code and information, unless otherwise specified is completely open-source/open-hardware (OSHW).

![http://dgitz.ipower.com/ICARUSRepo/Media/me.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/me.jpg)
That's Me!  [David Gitz.](https://www.facebook.com/david.gitz)

# Sponsors #
[![](http://www.4pcb.com/images/logo.png)](http://www.4pcb.com/)

Advanced Circuits has sponsored this project and provides PCB Fabrication services.  If you want to get sponsored from them too, go [here](http://www.4pcb.com/pcb-student-discount.html).

[![](http://www.fast-robotics.com/wp-content/uploads/2012/06/long-logo.png)](http://www.fast-robotics.com)

FAST Robotics has donated time in designing/supporting various components of this project.

[![](http://engineering.uic.edu/pub/COE/WebTopBar/coelogo_ds.png)](http://engineering.uic.edu/COE/WebHome)

The University of Illinois at Chicago College of Engineering is gracious enough to provide me with decent labspace and facilities for development.

# Details #

I am building a QuadTiltRotor UAV for my Thesis Project at UIC and to compete in the Sparkfun Autonomous Vehicle Competition.  Here is my Blog on the ICARUS System: http://davidgitz.blogspot.com/

I have found very little information regarding building a TiltRotor UAV, at least information that is attainable to the general public.  I also believe that these kinds of vehicles are the future of Aviation, either Manned or Unmanned.  As such this Wiki also serves to disseminate as much accurate information as possible about the design, fabrication, operation and analysis of TiltRotor UAV's.

# Thesis Objectives #
  * Conduct Literature Review on TiltRotor UAV's.
    * Provide analysis on failure modes of prior TiltRotor UAV's.
    * Provide information on control systems, design parameters (Wing Area, Lift Moment, Airfoil profile, etc) and figures of merit on TiltRotor UAV's.
  * Design QuadTiltRotor (QTR) UAV capable of autonomous transition between Vertical and Horizontal Flight Modes.
    * Model QTR in Simulink to design Control System.
    * Model QTR in Star-CCM (or other CFD Package) to assist in Aerodynamic design.
    * Model QTR in Xplane to test Flight Controls (Optional).
  * Build and Test QTR
    * Build scale model of QTR.
    * Test QTR using appropriate Wind-Tunnels.
    * Perform System Identification on QTR.
    * Perform Test Flights and validate design on QTR.

# Flyer's #
I have fairly recently changed the objective of my Thesis to build a QuadTiltRotor (QTR) from a QuadTiltWing (QTW) as I believe it is a more practical UAV to build and sell for commercial applications.  I've gone through several design iterations so far on this project, from initial concepts to more refined designs.

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/v6RevA.1/Flyer_Assy_Real.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/v6RevA.1/Flyer_Assy_Real.jpg)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/v6RevA.1/Flyer_Assy_Real_Detail.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/v6RevA.1/Flyer_Assy_Real_Detail.jpg)

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/v6RevA.1/Flyer_Aerial.jpg](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/v6RevA.1/Flyer_Aerial.jpg)

ICARUS QTR Flyer v6RevA-1.  As some can see, the original frame is based on the Arducopter frame, with some heavy modifications. I still have to mount the other computer systems, and for now the tilt mechanisms aren't in place.  Soon though...

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/v6RevA.1/Flyer_Assy.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/v6RevA.1/Flyer_Assy.png)

This is the current CAD of the ICARUS Flyer and is very true to the real thing.


![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/v5RevA.2/Cruise.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Design/v5RevA.2/Cruise.png)
ICARUS QTR Flyer v5RevA-2, in Cruise Mode.  This was only a conceptual design.


Here are some pictures of the QTW that was being developed before I changed to the QTR.

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v4RevA-2.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v4RevA-2.png)
ICARUS QTW Flyer v4RevA-2, in Cruise Mode.

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v4RevA-1.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v4RevA-1.png)
ICARUS QTW Flyer v4RevA-1, in Cruise Mode.  This was designed with Carbon Fiber as almost the entire structure, which was just too heavy.

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v3RevE.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v3RevE.png)
ICARUS QTW Jet Flyer v4RevE, in Cruise Mode.  Jet Engines are neat, but too expensive.

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v3RevD.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v3RevD.png)
ICARUS QTW Ducted Fan v4RevD, in Cruise Mode.  This was a try with a ducted fan embedded in each wing.  This design made the wing almost useless and unnecessarily heavy.

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v3RevC.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v3RevC.png)
ICARUS QTW Flyer v4RevC, in Hover Mode.  This was a try at having each wing at ~90 degrees to each other and forming an X, to give the Flyer the ability to perform maneuvers like an advanced hover.

![http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v3RevB.png](http://dgitz.ipower.com/ICARUSRepo/Media/Flyer/Archive/v3RevB.png)
ICARUS QTW Flyer v4RevB, in Hover Mode.  One of my initial designs for a QuadRotor with rotating wings and rotating pylons.  Very complicated and heavy on drag, but this thing could move anyway it wanted.