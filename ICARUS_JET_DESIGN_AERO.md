# Design Parameters #
Thrust/Weight Ratio: 1.2

Lift/Drag Ratio: 5

Airfoil Chord Length: 18 in

Wing Loading: 25 oz/ft^2

Aspect Ratio: 7.5

# Design Scenarios #
  1. Transition: 15:0 AoA, 5-15 mph (Re: 21909-65727)
  1. Cruise: -5:5 AoA, 15-60 mph (Re: 65727-262910)

# Issues #
  1. Stall progression pattern on Front Wing to not affect Back Engines.
  1. Pitching Moment, especially during Transition Phase.
# Steps #
  1. Determine Re min/max
  1. Find sample Symmetrical Airfoils



# Flow Design #
  1. Open the JetRevA\_FlowDesignScene in Inventor
  1. Export Inventor Assembly as STL file with units of mm.
  1. Import this file in Flow Design.  The Orientation and Size should be correct.

# Version 1 #
## Revision B ##
  * To reduce complexity, all Airfoils and Fuselage will be Symmetrical.
  * Front Wing will be a Rectangular+Tapered, Rear Wing will be Rectangular to help with Stall progression.

### Fuselage ###
  * Airfoil: NACA0020
### Front Wing ###

### Rear Wing ###

## Revision A ##
v1RevA is a conceptual model and Aero parameters are not specified.  The Jet is designed using a symmetrical-airfoil for the fuselage, and high-lift airfoils for the front and back wings.  The Airfoil profile is not fully specified.

After the design process was completed it was found that the Jet feaures very high lift, low Thrust/Weight (when fueled) and creates a large amount of turbulent airflow from the front wing to the back wing.

# References #
[Airfoil Database](http://aerospace.illinois.edu/m-selig/ads/coord_database.html)

[Spline Import](http://www.cadstudio.cz/en/apps/importcoord/)