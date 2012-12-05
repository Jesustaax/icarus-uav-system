using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
    class Pylon
    {
        public int PylonID { get; set; }
        public int PylonCount { get; set; }
        public string ServoAID { get; set; }
        public string ServoBID { get; set; }
        public string MotorAID { get; set; }
        public string MotorBID { get; set; }
        public int ServoACmd { get; set; }
        public int ServoBCmd { get; set; }
        public int MotorACmd { get; set; }
        public int MotorBCmd { get; set; }
        public int MotorASpd { get; set; }
        public int MotorBSpd { get; set; }
        public Pylon() 
        {
            //PylonID = 0;
        }
        public Pylon(int newPylonID, string newServoID, string newMotorAID, string newMotorBID)
        {
            Pylon myPylon = new Pylon();
            PylonID = newPylonID;
            ServoAID = newServoID;
            MotorAID = newMotorAID;
            MotorBID = newMotorBID;
            PylonCount++;
            
        }
        public bool PylonCmd(int newPylonID, int newServoCmd, int newMotorACmd, int newMotorBCmd)
        {
            return true;
        }

    }
    class INU
    {
        public int INUTimeStampID { get; set; }
        public int INUCount { get; set; }
        public double PitchCmd { get; set; }
        public double PitchVal { get; set; }
        public double YawCmd { get; set; }
        public double YawVal { get; set; }
        public double RollCmd { get; set; }
        public double RollVal { get; set; }
        public INU() { }
        public INU(int newTimeStamp, double newPCmd, double newPVal, double newYCmd, double newYVal, double newRCmd, double newRVal)
        {
            INUTimeStampID = newTimeStamp;
            PitchCmd = newPCmd;
            YawCmd = newYCmd;
            RollCmd = newRCmd;
            PitchVal = newPVal;
            YawVal = newYVal;
            RollVal = newRVal;
            INUCount++;
        }
    }
    /*class Pylon
    {
        public int PylonID { get; set; }
        public int PylonCount { get; set; }
        //public 
    }*/

}
