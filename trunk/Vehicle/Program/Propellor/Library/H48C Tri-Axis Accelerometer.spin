{{
***********************************************

  Hitachi H48C 3-Axis Acceleromenter
                                                                    
  Author: Auburn Sky Ltd,  D. Daniels,  05-Sep-06
  Modified: Travis, 07-Jan-09
        
***********************************************

Pin Diagram for H48C

          ┌──────────┐
  CLK ──│1 ‣‣••6│── VCC +5V
          │  ┌°───┐  │            
  DIO ──│2 │ /\ │ 5│── CS
          │  └────┘  │
  VSS ──│3  4│── ZERO-G (not used in this demo) 
          └──────────┘

Orientation

         Z   Y    
         │  /    /   °/  reference mark on H48C Chip, not white dot on 6-Pin module 
         │ /    /    /
         │/     o   white reference mark on 6-Pin module indicating Pin #1
          ──── X

Relevant Documentation:

  HitachiH48C3AxisAcelerometer.pdf (Schematic of H48C Accelerometer)
    http://www.parallax.com/Portals/0/Downloads/docs/prod/acc/HitachiH48C3AxisAccelerometer.pdf

}}

CON

  xRegister = 0
  yRegister = 1
  zRegister = 2  
  vRegister = 3
  
  High  =  1
  Low   =  0
  Out   = %1
  
  #0,MSBPRE,LSBPRE,MSBPOST,LSBPOST
  #4,LSBFIRST,MSBFIRST
  
VAR

  long  _csPin
  long  _clkPin
  long  _dioPin

  long _xOffset
  long _yOffset
  long _zOffset

  long _variance

OBJ

  spi  : "Library.SPI"    'standard SPIN file located in source folder
         
PUB Start ( clkPin, dioPin, csPin, variance ) : okay

  'Pin Mapping to Propeller Chip (Direct connections between H48C and PROP; no resistors needed)
  'CS  -> _csPin
  'CLK -> _clkPin
  'DIO -> _dioPin

  'define pin assignments
  _csPin  := csPin
  _dioPin := dioPin
  _clkPin := clkPin

  _variance := variance
  
  'start SPI
  okay := spi.start

  'calibrate
  if (okay)
    _Calibrate

  return okay
    
  
PUB Stop

  spi.stop

PUB X
  'return _xNorm - _xOffset
  return (_GetData ( xRegister ) - _xOffset) / _variance

PUB Y
  'return _yNorm - _yOffset
  return (_GetData ( yRegister ) - _yOffset) / _variance

PUB Z
  'return _zNorm - _zOffset
  return (_GetData ( zRegister ) - _zOffset) / _variance

PRI _GetData ( axis )  | data

  dira [ _csPin ] := Out

  outa [ _csPin ] := Low
  spi.shiftout        ( _dioPin, _clkPin, MSBFIRST, 2,  %11 )
  spi.shiftout        ( _dioPin, _clkPin, MSBFIRST, 3, axis )
  data := spi.shiftin ( _dioPin, _clkPin, MSBPOST, 13 )
  outa [ _csPin ] := High

  return  data

PRI _Calibrate

  'calculates the offset so the values returned are zeroed based on start position (presumably level/flat)

  _xOffset := 0
  _yOffset := 0
  _zOffset := 0

  'calculate offsets
  repeat 10
    _xOffset := _GetData ( xRegister ) + _xOffset
    _yOffset := _GetData ( yRegister ) + _yOffset
    _zOffset := _GetData ( zRegister ) + _zOffset
    waitcnt(clkfreq / 6 + cnt)

  _xOffset := (_xOffset / 10)
  _yOffset := (_yOffset / 10)
  _zOffset := (_zOffset / 10)

DAT
{{
┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
│                                                   TERMS OF USE: MIT License                                                  │
├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
│Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation    │
│files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy,    │
│modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software│
│is furnished to do so, subject to the following conditions:                                                                   │
│                                                                                                                              │
│The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.│
│                                                                                                                              │
│THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE          │
│WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR         │
│COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,   │
│ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                         │
└──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
}}      