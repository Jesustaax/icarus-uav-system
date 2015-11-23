# Introduction #

Add your content here.


# Requirements #
## Function ##
  * Communication to [ICARUS\_ROVER\_RC](ICARUS_ROVER_RC.md)
  * Drive Servos
  * Command/Response for Recharging

## I/O ##
  * PWM Output: 3 (Drive,Steer,Winch)
  * DI Interrupts: 4 (Drive Quadrature Encoder, Winch Quadrature Encoder)
  * DI: 2(Charger x2)
  * Analog In: 2 (Power Sensor x2)
  * Comm: 1 (UART)
  * 

# References #
[APM2](http://rover.ardupilot.com/wiki/common-apm-2-board-2/)

[Arduino Encoder Example](https://www.pjrc.com/teensy/td_libs_Encoder.html)

[Another Arduino Encoder Example with 1 Interrupt per Quadrature Encoder](http://www.robotoid.com/appnotes/circuits-quad-encoding.html)