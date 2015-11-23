# Development #

## Milestones ##
  1. Implement basic communication between drone\_server and Drone. (DONE)
  1. Implement SLAM operation on drone\_server. (In Progress)
  1. Implement Simulation on sim\_server.
  1. Implement Target Identification/Navigation Tasks on drone\_server, matlab\_server and Drone. (In Progress)
  1. Implement Obstacle Avoidance on drone\_server (Not Started).
  1. Implement Path Planning on Drone and drone\_server. (Not Started)
## Tasks ##

## Simulation ##
[V-Rep ROS Tutorial](http://www.coppeliarobotics.com/helpFiles/en/rosTutorial.htm)

[V-Rep User Manual](http://www.coppeliarobotics.com/helpFiles/index.html)

## SLAM ##

### References ###
[RatSLAMROS](https://code.google.com/p/ratslam/wiki/RatSLAMROS)

## Target Identification ##
A Matlab Program (MatlabServer) was created that runs on the matlab\_server.  The drone\_server continually acquires images from the drone and sends them over a WiFi TCP/IP channel to the matlab\_server target recognition.  After the matlab\_server processing is complete on an image a message is sent back to the drone\_server.

The Matlab program has the following modes:
  1. Train
  1. Test
  1. Sim
  1. Live

The Train mode goes through every training sample to produce a Principal Component Analysis (PCA) along with a K-Nearest Neighbors (KNN) Classifier.  This process is completed many times by varying the parameters used for the preprocessing script, to increase the accuracy of the classification system.  The Training process is fairly fast, taking about 20 seconds to load all training samples, process them and create the classifiers.  As such many variations of the preprocessing script are allowed to run.  For my initial work, approximately 52,000 different iterations were employed.  For the Training processing, the initial samples are split into a training and testing set.  However, these samples are a subset of the inital training samples as some training items are unsuitable for training, but should still be validated upon.  The best classifier/preprocessing scripts are able to achieve a 99% success rate for this dataset.

The Testing mode goes through every classifier generated during the Training process and tests on every training sample available.  As such, the error during this process is higher than the Training process.  The highest success rate for the entire dataset is reduced to approximately 76%.

The Sim mode is designed to test the performance of the selected classifiers without requiring a live connection to the drone\_server.  To improve the performance of the classifiers, the best 7 classifiers/preprocessors are evaluated on the data sample.  If there is agreement in the majority of the classifiers that classification is used.  Otherwise the previous classification found is used.  This method increases the success rate to approximately 81%.

[Pattern Recognition Toolbox](http://newfolder.github.io/prtdoc/prtDocLanding.html)


![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0001.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0001.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0002.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0002.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0003.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0003.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0004.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0004.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0005.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0005.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0006.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0006.png)![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0007.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0007.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0008.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0008.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0009.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0009.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0010.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0010.png)![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0011.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0011.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0012.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0012.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0013.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0013.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0014.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0014.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0015.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0015.png)![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0016.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0016.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0017.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0017.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0018.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0018.png)
![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0019.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0019.png)![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0020.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0020.png)![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0021.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0021.png)![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0022.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0022.png)![http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0023.png](http://dgitz.ipower.com/ICARUSRepo/Media/Drone/EnvironmentImages/Image0023.png)

Examples of Acquired Images