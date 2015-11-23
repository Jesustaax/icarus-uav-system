# Definitions #
## Variable Declarations ##

  * All collections of objects should end with an 's':
```
Obstacles(1).Index 
SonarSensors(4).CurrentAngle
```
  * When indexing a collection of objects the indexing parameter should be the first letter in the collection name:
```
Obstacles(o).Index
SonarSensors(s).CurrentAngle
```
  * All EA Tuned Parameters/User Inputs should be in all CAPITALS, with each word separated by an underscore:
```
BUCKET_ITEMS
TEST_VEHICLE_RANDOM_WALK
```
  * All Functions/Scripts should be in CamelCase with no separation between words:
```
TestOccupancyGrid
BuildEnvironment('SmallObstacles')
```
  * All other variables should be in CamelCase with underscores separating words:
```
Sensor_In_Sight
In_Overlap
```
  * All variables in a Function that are similar to global variables shall be preceeded by 'my