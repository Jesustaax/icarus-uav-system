# Introduction #
The ICARUS\_ROVER\_RECHARGE Project is designed to allow a robot to autonomously find a standard AC outlet (using visual images) and insert a plug to recharge its batteries.  There are several different components of this project, including:
  * [Target Finding](ICARUS_ROVER_RECHARGE#Target-Finding.md)
  * [Target Alignment](ICARUS_ROVER_RECHARGE#Target-Alignment.md)
  * [Battery Recharging](ICARUS_ROVER_RECHARGE#Battery-Recharging.md)

# Target-Finding #
Finding a Target in an image is broken into several pieces.  First, a large amount of exemplar images are taken.  Then the targets in each image are specified manually.  Finally an image processor is tuned (either extensively or with an Evolutionary Algorithm) with a feature detection process.

![https://raw.githubusercontent.com/dgitz/icarus_rover_rc/master/media/imagesamples-9Dec2014/Image1.png](https://raw.githubusercontent.com/dgitz/icarus_rover_rc/master/media/imagesamples-9Dec2014/Image1.png)
> An examplar of a Target Image

## Training Target Data ##
Filename: capturedate.cvs
|Filename|Target1\_x|Target1\_y|Target2\_x|Target2\_y|
|:-------|:---------|:---------|:---------|:---------|

## Training Result Data ##
Filename: filtermethod\_detectmethod\_capturedate\_pickeddate.csv

|Threshold|Erode|Dilate|Score|FPS|
|:--------|:----|:-----|:----|:--|

## Testing ##
## Test Camera Operation ##
```
luvcview -d /dev/video1
--or--
sudo ./test
--or--
sudo ./tracking
```

## Operating Instructions ##
### Perform Image Acquisition Process ###
  1. Terminal 1:
```
roscore
```
  1. Terminal 2:
```
cd ~/catkin_ws
source ./devel/setup.bash
roslaunch icarus_rover_rc acquire_train_images.launch 
```
Every time you left-click the image window it will save the image to a folder.
### Pick Targets from Training Images ###
  1. Terminal 1:
```
roscore
```
  1. Terminal 2:
```
cd ~/catkin_ws
source ./devel/setup.bash
roslaunch icarus_rover_rc pick_targets_from_train_images.launch 
```
For each image click at most 2 Targets.  If the image doesn't contain a Target right-click anywhere in the image.  Press space to see the selected targets (or nothing happens if right-click was pressed).  Press space again to advance to the next image.

### Tuning Process ###
#### Extensive (non-EA) ####

#### Evolution Algorithm ####
Of course the Evolution Algorithm here is based on the natural processes found in Nature.  If one does not necessarily believe in Evolution, consult this [Evolution FAQ](http://evolutionfaq.com/) or [More Information](http://lmgtfy.com/?q=psychiatrist+near+me)

[Intro to EA](http://www.cs.vu.nl/~gusz/ecbook/Eiben-Smith-Intro2EC-Ch2.pdf)
The following functions need to be defined for an EA process:

**INITIALIZE**

Initialize 20 candidates (a population) with a random selection of Genes with the following specifications:

_GENE\_ERODE_ Integer, between 1 and 11.  1 Meaning no Erosion process, so the Erosion process can be skipped.

_GENE\_DILATE_ Integer, between 1 and 11.  1 Meaning no Dilation process, so the Dilation process can be skipped.

_GENE\_THRESHOLD_ Integer, between 0 and 255.

**EVALUATE**

Evaluate the image pre-processing with the feature detection method and compute the target\_score and processing\_score, where:
target\_score is a piecewise function.

If a target is found and a target is present:
```
target_score = min(||found_target-target1||,||found_target-target2||)
```
If a target is found and no target is actually present:
```
target_score = image_width*image_height
```
If no target is found and a target is actually present:
```
target_score = image_width*image_height
```
If no target is found and no target is actually present:
```
target_score = 0
```
Finally, the target\_score is normalized by:
```
target_score = target_score/(image_width*image_height)
```

process\_score is found by:
```
process_score = fps/30
```

Finally, the composite\_score is found by:
```
composite_score = (target_score + process_score)/2
```
So the composite\_score will be a value between 0 and 1, with 0 being an extremely poor fitness and a 1 being an extremely good fitness.

**SELECT**

The purpose of the Selection process is to select the best candidates for reproduction, and then to kill off the worst candidates.  However, the best and worst candidates are also selected based on a probability.

This is computed on each Candidate by:
```
pick_score = rand*composite_score
```
The Candidates of a Population are sorted based on their pick\_score.  The top 5 are selected for the next process, the bottom 5 are selected to be removed from the population.  Here is an example:

|Candidate ID|Candidate Fitness|Order Picked|W/O Probability|W/ Probability|
|:-----------|:----------------|:-----------|:--------------|:-------------|
|8           |0.9612           |0.9223      |BEST LIST      |BEST LIST     |
|15          |0.9401           |0.9085      |BEST LIST      |BEST LIST     |
|3           |0.9659           |0.7109      |BEST LIST      |BEST LIST     |
|18          |0.6241           |0.5530      |               |BEST LIST     |
|5           |0.7967           |0.4890      |BEST LIST      |BEST LIST     |
|20          |0.7793           |0.4634      |               |              |
|4           |0.5370           |0.3970      |               |              |
|10          |0.7462           |0.3960      |               |              |
|11          |0.4749           |0.3948      |               |              |
|19          |0.7289           |0.3703      |               |              |
|16          |0.6843           |0.2991      |               |              |
|12          |0.7333           |0.2571      |               |              |
|14          |0.5845           |0.2323      |               |              |
|1           |0.5465           |0.1961      |               |              |
|7           |0.4464           |0.1611      |WORST LIST     |              |
|17          |0.2048           |0.1439      |WORST LIST     |WORST LIST    |
|6           |0.3314           |0.0579      |WORST LIST     |WORST LIST    |
|9           |0.2675           |0.0480      |WORST LIST     |WORST LIST    |
|13          |0.1308           |0.0181      |WORST LIST     |WORST LIST    |
|2           |0.9357           |0.0157      |BEST LIST      |WORST LIST    |

As you can see, although Candidate 2 had one of the best composite\_scores, it will not be picked due to his pick\_score.

**RECOMBINE**

Now with the best 5 Candidates, their Children must be created.  We use 2 different parents for this.  This is done by:
```
for(i=0;i<5;i++)
{
     parent_A = Candidate[ceil(rand*5)]
     parent_B = Candidate[ceil(rand*5)]
     while(parent_A == parent_B)
     {
          parent_B = Candidate[ceil(rand*5)]
     }
     for(j=0;j<GENE_COUNT;j++)
     {
          New_Candidate[i].Gene[j] = average(Parent_A.Gene[j],Parent_B.Gene[j])
     }
}
```


**MUTATE**

The Mutation process works by randomly mutating the New Candidate's genes by:
```
for(i=0;i<5;i++)
{
     for(j=0;j<GENE_COUNT;j++)
     {
          New_Candidate[i].Gene[j] = New_Candidate[i].Gene[j] + scaling_factor*(1-rand)
     }
}
```

# Target-Alignment #
# Battery-Recharging #

Battery Recharging is performed using the [ICARUS\_ROVER\_CHARGE\_PROBE](ICARUS_ROVER_CHARGE_PROBE.md).

# References #

http://stevenhickson.blogspot.com/2013/03/using-webcam-with-raspberry-pi.html

http://hackaday.com/2014/09/05/an-obsessively-thorough-battery-and-more-showdown/

http://www.ti.com/lit/an/snva557/snva557.pdf

http://docs.opencv.org/doc/tutorials/features2d/feature_detection/feature_detection.html

http://robocv.blogspot.com/2012/02/real-time-object-detection-in-opencv.html

http://find-object.googlecode.com/svn/trunk/find_object/example/main.cpp

https://github.com/savsun/Filters