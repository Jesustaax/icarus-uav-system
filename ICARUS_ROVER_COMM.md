# ROS Topics #
## ICARUS\_Target\_Status ##
Message pertinent to target location found by Targeting\_Node.
```
Targeting_Node -> Motion_Controller_Node
```
```
Header header
int Target_Type
Point Target_Point
```

**Target\_Type
_Definitions_
```
TARGET_NONE = 1
TARGET_TRACKING = 2

```
## ICARUS\_Sonar\_Scan ##
Message pertinent to the ICARUS Sonar Sensors.  Formatted as a LaserScan Topic.
```
Motion_Controller_Node->Targeting_Node
```**

## ICARUS\_Probe\_Status ##
```
Motion_Controller_Node -> Targeting_Node
```
Message pertinent to the ICARUS Probe.

```
Header header
int Probe_State
int Extended_Switch
int Retracted_Switch
int Probe_Error
```

**Probe\_State**

_Definitions_
```
PROBE_MOVING_FORWARD = 1
PROBE_MOVING_REVERSE = 2
PROBE_EXTENDED = 3
PROBE_RETRACTED = 4
```

**Probe\_Switch**

Broadcast from the Motion\_Controller Node.  Specifies current state of Probe Limit Switches.

_Definitions_
```
EXTENDED_SWITCH
REVERSE_SWITCH
```

**Probe\_Error
Various Probe Error States**

_Definitions_
```
NO_ERROR = 0
EXTENSION_ERROR = 1
RETRACTION_ERROR = 2
```

## ICARUS\_Probe\_Command ##
```
? -> Motion_Controller_Node
```
```
Header header
int Charge_Command
```
**Charge\_Command**

_Definitions_
```
RECHARGE_START = 1
RECHARGE_STOP = 2
RECHARGE_WAIT = 3
```