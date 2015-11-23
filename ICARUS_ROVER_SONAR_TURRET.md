The Sonar Turret consists of a ring of [Parallax Ping Sensors](http://www.parallax.com/product/28015) to be used to map and navigate a complex & dense environment.

Since most inexpensive ultrasonic sensors have a fairly wide (~30 degree) beamwidth and operate at a similar and unchangable frequency, there is a high rick of "ghost echoes", one sonar receiving a transmission from another sonar, or sonar transmissions getting multi-path distortion from bouncing off different obstacles.  It is advantageous for mapping & navigation tasks to overlap coverage of the sensors, which raises some issues.

A good way to solve these issues is to not allow the sonars to transmit continuously, but to trigger them in a pre-defined sequence that will mitigate the issue of ghost echoes.

https://www.dropbox.com/s/nfkbraxtd9xz037/SensorTurretAssy.png?raw=1

https://www.dropbox.com/s/uieeie8dhlu12ya/SensorTurretAssyBeam.png?raw=1