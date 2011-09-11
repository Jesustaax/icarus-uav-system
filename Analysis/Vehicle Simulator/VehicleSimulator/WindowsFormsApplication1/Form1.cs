using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        #region GlobalVariables

        //Control
        double timebase;
        double timedelay;
        double kP;  //PID Constants for P Term
        double kI;  //PID Constants for I Term
        double kD;  //PID Constants for D Term
        double[] Ierror = new double[4];  //Integral History
        double accuracy;
        double Px, Yx, Rx, Tx;  //PID Calculated Value
        double Ps, Ys, Rs, Ts;  //PID SetPoint
        double Pc, Yc, Rc, Tc;  //PID Current Value


        //Vehicle
        List<Pylon> VehiclePylons = new List<Pylon>();
        List<INU> myINUHistory = new List<INU>();
        string VehicleControlMode;
        
        #endregion
        #region MainTab
        #region Usage
        public MainForm()
        {
            //Initialize Variables

            Ierror[0] = 0;
            Ierror[1] = 0;
            Ierror[2] = 0;
            Ierror[3] = 0;
            InitializeComponent();
            backgroundWorkerPID.WorkerReportsProgress = true;
            backgroundWorkerPID.WorkerSupportsCancellation = true;
            pProgress.Value = 0;
            lProgress.Text = "0%";
            InitializeVariables();
            InitializeVehicle();
                
                //cFlightMode.Items
               
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker newworker = sender as BackgroundWorker;
            Ps = Convert.ToDouble(nPitchCmd.Text);
            Ys = Convert.ToDouble(nYawCmd.Text);
            Rs = Convert.ToDouble(nRollCmd.Text);
            Ts = Convert.ToDouble(nThrottleCmd.Text);
            PIDControl(newworker, e, VehicleControlMode);
        }    

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tPrimaryCommand.Text = string.Format("$MAN,{0},{1},{2},{3}*", Ps, Ys, Rs, Ts);
            nPylon1PWM.Value = (decimal)CoercePWM((((Px - 127.0) / 2.0 + (Yx - 127.0) / 2.0 + (Tx + 127.0) / 2.0) * 4) + 1000);
            nPylon2PWM.Value = (decimal)CoercePWM((((Rx - 127.0) / 2.0 + (127.0 - Yx) / 2.0 + (Tx + 127.0) / 2.0) * 4) + 1000);
            nPylon3PWM.Value = (decimal)CoercePWM((((127.0 - Px) / 2.0 + (Yx - 127.0) / 2.0 + (Tx + 127.0) / 2.0) * 4) + 1000);
            nPylon4PWM.Value = (decimal)CoercePWM((((127.0 - Rx) / 2.0 + (127.0 - Yx) / 2.0 + (Tx + 127.0) / 2.0) * 4) + 1000);
            tSecondaryCommand.Text = string.Format("$MAN-#,{0},{1},{2},{3}*", (int)nPylon1PWM.Value, (int)nPylon2PWM.Value, (int)nPylon3PWM.Value, (int)nPylon4PWM.Value);
            nPylon1Value.Value = ((decimal)nPylon1PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
            nPylon2Value.Value = ((decimal)nPylon2PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
            nPylon3Value.Value = ((decimal)nPylon3PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
            nPylon4Value.Value = ((decimal)nPylon4PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                tResults.AppendText("Canceled\n");
            }
            else if(e.Error != null)
            {
                tResults.Text = "Error" + e.Error.Message;
            }

        }
        private void bRUN_Click(object sender, EventArgs e)
        {
            VehicleControlMode = cFlightMode.SelectedItem.ToString() + "-" + cAutoMode.SelectedItem.ToString() + "-" + cControllerMode.SelectedItem.ToString();
            VehicleControl(VehicleControlMode);
            
            
        }
        #endregion

            
        #region Functions
        public bool InitializeVariables()
        {
            INU newINUSample = new INU();
            newINUSample.INUTimeStampID = 0;
            newINUSample.PitchCmd = 0;
            newINUSample.PitchVal = 0;
            newINUSample.YawCmd = 0;
            newINUSample.YawVal = 0;
            newINUSample.RollVal = 0;
            newINUSample.RollCmd = 0;
            myINUHistory.Add(newINUSample);
            timebase = Convert.ToDouble(tTimeBase.Text);
            timedelay = Convert.ToDouble(tDelay.Text);
            /*for(int i = 0; i < VehiclePylons.Count; i++)
            {
                kP[i] = 1;
                kI[i] = 0;
                kD[i] = 0;
                Ierror[i] = 0;
            }*/
            kP = Convert.ToDouble(tkP.Text);
            kI = Convert.ToDouble(tkI.Text);
            kD = Convert.ToDouble(tkD.Text);
            accuracy = Convert.ToDouble(tAccuracyPercent.Text);
            Ps = Convert.ToDouble(nPitchCmd.Text);
            Ys = Convert.ToDouble(nYawCmd.Text);
            Rs = Convert.ToDouble(nRollCmd.Text);
            Ts = Convert.ToDouble(nThrottleCmd.Text);
            return true;
        }
        public bool InitializeVehicle()
        {
            for (int i = 0; i < 4; i++)
            {
                Pylon newpylon = new Pylon();
                newpylon.PylonID = i + 1;
                newpylon.ServoAID = "Servo" + Convert.ToString(i + 1);
                newpylon.MotorAID = "Motor" + Convert.ToString(i + 1) + "A";
                newpylon.MotorBID = "Motor" + Convert.ToString(i + 1) + "B";
                VehiclePylons.Add(newpylon);

            }
            
            return true;
        }
        
        public bool VehicleControl(string mode)
        {
            
            double temp;
            Ps = ScaleAngle(Convert.ToDouble(nPitchCmd.Text));
            Ys = ScaleAngle(Convert.ToDouble(nYawCmd.Text));
            Rs = ScaleAngle(Convert.ToDouble(nRollCmd.Text));
            Ts = ScaleThrottle(Convert.ToDouble(nThrottleCmd.Text));
            
            
            switch (mode)
            {
                case ("Normal-Direct-Secondary Controller"):
                    {
                        tPrimaryCommand.Text = "N/A";
                        tSecondaryCommand.Text = string.Format("$MAN,{0},{1},{2},{3}*", nPitchCmd.Value, nYawCmd.Value, nRollCmd.Value, nThrottleCmd.Value);
                        nPylon1PWM.Value = (decimal)CoercePWM((((Ps - 127.0) / 2.0 + (Ys - 127.0) / 2.0 + (Ts + 127.0) / 2.0) * 4) + 1000);
                        nPylon2PWM.Value = (decimal)CoercePWM((((Rs - 127.0) / 2.0 + (127.0 - Ys) / 2.0 + (Ts + 127.0) / 2.0)*4)+1000);
                        nPylon3PWM.Value = (decimal)CoercePWM((((127.0 - Ps) / 2.0 + (Ys - 127.0) / 2.0 + (Ts + 127.0) / 2.0) * 4) + 1000);
                        nPylon4PWM.Value = (decimal)CoercePWM((((127.0 - Rs) / 2.0 + (127.0 - Ys) / 2.0 + (Ts + 127.0) / 2.0) * 4) + 1000);
                        nPylon1Value.Value = ((decimal)nPylon1PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
                        nPylon2Value.Value = ((decimal)nPylon2PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
                        nPylon3Value.Value = ((decimal)nPylon3PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
                        nPylon4Value.Value = ((decimal)nPylon4PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
                        return true;
                    }
                case ("Normal-Direct-Primary Controller/Secondary Controller"):
                    {
                        tPrimaryCommand.Text = string.Format("$MAN,{0},{1},{2},{3}*", nPitchCmd.Value, nYawCmd.Value, nRollCmd.Value, nThrottleCmd.Value);
                        nPylon1PWM.Value = (decimal)CoercePWM((((Ps - 127.0) / 2.0 + (Ys - 127.0) / 2.0 + (Ts + 127.0) / 2.0) * 4) + 1000);
                        nPylon2PWM.Value = (decimal)CoercePWM((((Rs - 127.0) / 2.0 + (127.0 - Ys) / 2.0 + (Ts + 127.0) / 2.0) * 4) + 1000);
                        nPylon3PWM.Value = (decimal)CoercePWM((((127.0 - Ps) / 2.0 + (Ys - 127.0) / 2.0 + (Ts + 127.0) / 2.0) * 4) + 1000);
                        nPylon4PWM.Value = (decimal)CoercePWM((((127.0 - Rs) / 2.0 + (127.0 - Ys) / 2.0 + (Ts + 127.0) / 2.0) * 4) + 1000);
                        tSecondaryCommand.Text = string.Format("$MAN-#,{0},{1},{2},{3}*", (int)nPylon1PWM.Value, (int)nPylon2PWM.Value, (int)nPylon3PWM.Value, (int)nPylon4PWM.Value);
                        nPylon1Value.Value = ((decimal)nPylon1PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
                        nPylon2Value.Value = ((decimal)nPylon2PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
                        nPylon3Value.Value = ((decimal)nPylon3PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
                        nPylon4Value.Value = ((decimal)nPylon4PWM.Value - (decimal)1000.0) * Convert.ToDecimal(tBaseVoltage.Text) / (decimal)1000.0;
                        return true;
                    }
                case ("Normal-Semi-Primary Controller/Secondary Controller"):
                    {
                        if (backgroundWorkerPID.IsBusy != true)
                        {
                            backgroundWorkerPID.RunWorkerAsync();
                        }
                        return true;
                    }
                default:
                    {
                        return true;
                    }
            }

            return true;

        }
        public double ScaleAngle(double angle)
        {
            return (angle + 90.0) * 255.0 / 180.0;
        }
        public double ScaleThrottle(double throttle)
        {
            return throttle * 255.0 / 100.0;
        }
        public double CoercePWM(double value)
        {
            if (value <= 1000.0)
            {
                value = 1000;
            }
            else if (value >= 2000.0)
            {
                value = 2000;
            }
            return value;
        }
        

        public bool PIDControl(BackgroundWorker worker, DoWorkEventArgs e, string mode)
        {
            double error = 100;
            Px = Ps;
            Rx = Rs;
            Yx = Ys;
            Tx = Ts;
            double PErrorHistory = 0;
            double YErrorHistory = 0;
            double RErrorHistory = 0;
            
            switch (mode)
            {
                case "Normal-Semi-Primary Controller/Secondary Controller":
                    {
                        while (error > accuracy)
                        {
                            if (worker.CancellationPending)
                            {
                                e.Cancel = true;
                                return false;
                            }
                            Random random = new Random();
                            Pc = Px * random.NextDouble(); //Fake Vehicle movement
                            Yc = Yx * random.NextDouble();
                            Rc = Rc * random.NextDouble();
                            PErrorHistory += (Pc - Ps);
                            YErrorHistory += (Yc - Ys);
                            RErrorHistory += (Rc - Rs);
                            Px = PID(PErrorHistory, Pc, Ps);
                            Rx = PID(RErrorHistory, Rc, Rs);
                            Yx = PID(RErrorHistory, Yc, Ys);
                            error = (Px - Ps) / Ps * 100.0;
                            worker.ReportProgress((int)error);

                        }
                        return true;
                    }
                default:
                    return true;

            }
        }
        public double PID(double errorhistory, double currentvalue, double commandvalue)
        {
            double value = 0;
            
            return value;
        }
        #endregion
        #endregion

    }
}
