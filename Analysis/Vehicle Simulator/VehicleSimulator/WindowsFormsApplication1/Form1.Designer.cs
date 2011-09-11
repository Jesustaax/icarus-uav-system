namespace WindowsFormsApplication1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bRUN = new System.Windows.Forms.Button();
            this.bSTOP = new System.Windows.Forms.Button();
            this.cFlightMode = new System.Windows.Forms.ComboBox();
            this.nPitchCmd = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nYawCmd = new System.Windows.Forms.NumericUpDown();
            this.nRollCmd = new System.Windows.Forms.NumericUpDown();
            this.nThrottleCmd = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorkerPID = new System.ComponentModel.BackgroundWorker();
            this.pProgress = new System.Windows.Forms.ProgressBar();
            this.lProgress = new System.Windows.Forms.Label();
            this.tTimeBase = new System.Windows.Forms.TextBox();
            this.tDelay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cControllerMode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cAutoMode = new System.Windows.Forms.ComboBox();
            this.tPrimaryCommand = new System.Windows.Forms.TextBox();
            this.tSecondaryCommand = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tBaseVoltage = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.nPylon1Value = new System.Windows.Forms.NumericUpDown();
            this.nPylon2Value = new System.Windows.Forms.NumericUpDown();
            this.nPylon3Value = new System.Windows.Forms.NumericUpDown();
            this.nPylon4Value = new System.Windows.Forms.NumericUpDown();
            this.nPylon1PWM = new System.Windows.Forms.NumericUpDown();
            this.nPylon2PWM = new System.Windows.Forms.NumericUpDown();
            this.nPylon3PWM = new System.Windows.Forms.NumericUpDown();
            this.nPylon4PWM = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.tResults = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tAccuracyPercent = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tkP = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tkI = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tkD = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nPitchCmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nYawCmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRollCmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThrottleCmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon1Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon2Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon3Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon4Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon1PWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon2PWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon3PWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon4PWM)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // bRUN
            // 
            this.bRUN.Location = new System.Drawing.Point(105, 25);
            this.bRUN.Name = "bRUN";
            this.bRUN.Size = new System.Drawing.Size(75, 23);
            this.bRUN.TabIndex = 0;
            this.bRUN.Text = "RUN";
            this.bRUN.UseVisualStyleBackColor = true;
            this.bRUN.Click += new System.EventHandler(this.bRUN_Click);
            // 
            // bSTOP
            // 
            this.bSTOP.Location = new System.Drawing.Point(24, 25);
            this.bSTOP.Name = "bSTOP";
            this.bSTOP.Size = new System.Drawing.Size(75, 23);
            this.bSTOP.TabIndex = 1;
            this.bSTOP.Text = "STOP";
            this.bSTOP.UseVisualStyleBackColor = true;
            // 
            // cFlightMode
            // 
            this.cFlightMode.FormattingEnabled = true;
            this.cFlightMode.Items.AddRange(new object[] {
            "Normal",
            "Takeoff",
            "Hovering",
            "Landing",
            "Cruise",
            "Diagnostic",
            "Emergency Landing",
            "Emergency Recovery"});
            this.cFlightMode.Location = new System.Drawing.Point(24, 74);
            this.cFlightMode.Name = "cFlightMode";
            this.cFlightMode.Size = new System.Drawing.Size(121, 21);
            this.cFlightMode.TabIndex = 2;
            // 
            // nPitchCmd
            // 
            this.nPitchCmd.Location = new System.Drawing.Point(176, 211);
            this.nPitchCmd.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nPitchCmd.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nPitchCmd.Name = "nPitchCmd";
            this.nPitchCmd.Size = new System.Drawing.Size(120, 20);
            this.nPitchCmd.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Flight Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pitch (-90 : 90)";
            // 
            // nYawCmd
            // 
            this.nYawCmd.Location = new System.Drawing.Point(176, 257);
            this.nYawCmd.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nYawCmd.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nYawCmd.Name = "nYawCmd";
            this.nYawCmd.Size = new System.Drawing.Size(120, 20);
            this.nYawCmd.TabIndex = 6;
            // 
            // nRollCmd
            // 
            this.nRollCmd.Location = new System.Drawing.Point(176, 305);
            this.nRollCmd.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nRollCmd.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nRollCmd.Name = "nRollCmd";
            this.nRollCmd.Size = new System.Drawing.Size(120, 20);
            this.nRollCmd.TabIndex = 8;
            // 
            // nThrottleCmd
            // 
            this.nThrottleCmd.Location = new System.Drawing.Point(176, 352);
            this.nThrottleCmd.Name = "nThrottleCmd";
            this.nThrottleCmd.Size = new System.Drawing.Size(120, 20);
            this.nThrottleCmd.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Yaw (-90 : 90)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Roll (-90 : 90)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Throttle (0 : 100)";
            // 
            // backgroundWorkerPID
            // 
            this.backgroundWorkerPID.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorkerPID.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorkerPID.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // pProgress
            // 
            this.pProgress.Location = new System.Drawing.Point(373, 25);
            this.pProgress.Name = "pProgress";
            this.pProgress.Size = new System.Drawing.Size(305, 23);
            this.pProgress.TabIndex = 14;
            // 
            // lProgress
            // 
            this.lProgress.AutoSize = true;
            this.lProgress.Location = new System.Drawing.Point(522, 31);
            this.lProgress.Name = "lProgress";
            this.lProgress.Size = new System.Drawing.Size(35, 13);
            this.lProgress.TabIndex = 15;
            this.lProgress.Text = "label6";
            // 
            // tTimeBase
            // 
            this.tTimeBase.Location = new System.Drawing.Point(14, 12);
            this.tTimeBase.Name = "tTimeBase";
            this.tTimeBase.Size = new System.Drawing.Size(100, 20);
            this.tTimeBase.TabIndex = 16;
            this.tTimeBase.Text = ".02";
            // 
            // tDelay
            // 
            this.tDelay.Location = new System.Drawing.Point(14, 38);
            this.tDelay.Name = "tDelay";
            this.tDelay.Size = new System.Drawing.Size(100, 20);
            this.tDelay.TabIndex = 17;
            this.tDelay.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Time Base (sec)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Delay (sec)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Controller Mode";
            // 
            // cControllerMode
            // 
            this.cControllerMode.FormattingEnabled = true;
            this.cControllerMode.Items.AddRange(new object[] {
            "Primary Controller/Secondary Controller",
            "Secondary Controller"});
            this.cControllerMode.Location = new System.Drawing.Point(24, 164);
            this.cControllerMode.Name = "cControllerMode";
            this.cControllerMode.Size = new System.Drawing.Size(236, 21);
            this.cControllerMode.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Auto Mode";
            // 
            // cAutoMode
            // 
            this.cAutoMode.FormattingEnabled = true;
            this.cAutoMode.Items.AddRange(new object[] {
            "Direct",
            "Semi",
            "Auto"});
            this.cAutoMode.Location = new System.Drawing.Point(24, 121);
            this.cAutoMode.Name = "cAutoMode";
            this.cAutoMode.Size = new System.Drawing.Size(121, 21);
            this.cAutoMode.TabIndex = 22;
            // 
            // tPrimaryCommand
            // 
            this.tPrimaryCommand.Location = new System.Drawing.Point(373, 115);
            this.tPrimaryCommand.Name = "tPrimaryCommand";
            this.tPrimaryCommand.Size = new System.Drawing.Size(305, 20);
            this.tPrimaryCommand.TabIndex = 24;
            // 
            // tSecondaryCommand
            // 
            this.tSecondaryCommand.Location = new System.Drawing.Point(373, 161);
            this.tSecondaryCommand.Name = "tSecondaryCommand";
            this.tSecondaryCommand.Size = new System.Drawing.Size(305, 20);
            this.tSecondaryCommand.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(370, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Command -> Primary Controller";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(370, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Command -> Secondary Controller";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(495, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Pylon 1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(396, 254);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Pylon 2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(124, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Base Voltage";
            // 
            // tBaseVoltage
            // 
            this.tBaseVoltage.Location = new System.Drawing.Point(14, 64);
            this.tBaseVoltage.Name = "tBaseVoltage";
            this.tBaseVoltage.Size = new System.Drawing.Size(100, 20);
            this.tBaseVoltage.TabIndex = 32;
            this.tBaseVoltage.Text = "11.1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(495, 308);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Pylon 3";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(594, 259);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Pylon 4";
            // 
            // nPylon1Value
            // 
            this.nPylon1Value.DecimalPlaces = 2;
            this.nPylon1Value.Location = new System.Drawing.Point(457, 221);
            this.nPylon1Value.Name = "nPylon1Value";
            this.nPylon1Value.Size = new System.Drawing.Size(63, 20);
            this.nPylon1Value.TabIndex = 38;
            // 
            // nPylon2Value
            // 
            this.nPylon2Value.DecimalPlaces = 2;
            this.nPylon2Value.Location = new System.Drawing.Point(359, 270);
            this.nPylon2Value.Name = "nPylon2Value";
            this.nPylon2Value.Size = new System.Drawing.Size(62, 20);
            this.nPylon2Value.TabIndex = 39;
            // 
            // nPylon3Value
            // 
            this.nPylon3Value.DecimalPlaces = 2;
            this.nPylon3Value.Location = new System.Drawing.Point(457, 324);
            this.nPylon3Value.Name = "nPylon3Value";
            this.nPylon3Value.Size = new System.Drawing.Size(63, 20);
            this.nPylon3Value.TabIndex = 41;
            // 
            // nPylon4Value
            // 
            this.nPylon4Value.DecimalPlaces = 2;
            this.nPylon4Value.Location = new System.Drawing.Point(562, 275);
            this.nPylon4Value.Name = "nPylon4Value";
            this.nPylon4Value.Size = new System.Drawing.Size(58, 20);
            this.nPylon4Value.TabIndex = 40;
            // 
            // nPylon1PWM
            // 
            this.nPylon1PWM.Location = new System.Drawing.Point(516, 221);
            this.nPylon1PWM.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nPylon1PWM.Name = "nPylon1PWM";
            this.nPylon1PWM.Size = new System.Drawing.Size(63, 20);
            this.nPylon1PWM.TabIndex = 42;
            // 
            // nPylon2PWM
            // 
            this.nPylon2PWM.Location = new System.Drawing.Point(420, 270);
            this.nPylon2PWM.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nPylon2PWM.Name = "nPylon2PWM";
            this.nPylon2PWM.Size = new System.Drawing.Size(63, 20);
            this.nPylon2PWM.TabIndex = 43;
            // 
            // nPylon3PWM
            // 
            this.nPylon3PWM.Location = new System.Drawing.Point(516, 324);
            this.nPylon3PWM.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nPylon3PWM.Name = "nPylon3PWM";
            this.nPylon3PWM.Size = new System.Drawing.Size(63, 20);
            this.nPylon3PWM.TabIndex = 44;
            // 
            // nPylon4PWM
            // 
            this.nPylon4PWM.Location = new System.Drawing.Point(615, 275);
            this.nPylon4PWM.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nPylon4PWM.Name = "nPylon4PWM";
            this.nPylon4PWM.Size = new System.Drawing.Size(63, 20);
            this.nPylon4PWM.TabIndex = 45;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSetup);
            this.tabControl1.Controls.Add(this.tabResults);
            this.tabControl1.Location = new System.Drawing.Point(792, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(296, 351);
            this.tabControl1.TabIndex = 46;
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.label21);
            this.tabSetup.Controls.Add(this.label20);
            this.tabSetup.Controls.Add(this.tkD);
            this.tabSetup.Controls.Add(this.label19);
            this.tabSetup.Controls.Add(this.tkI);
            this.tabSetup.Controls.Add(this.label18);
            this.tabSetup.Controls.Add(this.tkP);
            this.tabSetup.Controls.Add(this.label17);
            this.tabSetup.Controls.Add(this.tAccuracyPercent);
            this.tabSetup.Controls.Add(this.label14);
            this.tabSetup.Controls.Add(this.tTimeBase);
            this.tabSetup.Controls.Add(this.tDelay);
            this.tabSetup.Controls.Add(this.label6);
            this.tabSetup.Controls.Add(this.label7);
            this.tabSetup.Controls.Add(this.tBaseVoltage);
            this.tabSetup.Controls.Add(this.panel1);
            this.tabSetup.Location = new System.Drawing.Point(4, 22);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(288, 325);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.tResults);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(288, 325);
            this.tabResults.TabIndex = 1;
            this.tabResults.Text = "Results";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // tResults
            // 
            this.tResults.Location = new System.Drawing.Point(19, 196);
            this.tResults.Multiline = true;
            this.tResults.Name = "tResults";
            this.tResults.Size = new System.Drawing.Size(248, 123);
            this.tResults.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(124, 97);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "Accuracy Percent";
            // 
            // tAccuracyPercent
            // 
            this.tAccuracyPercent.Location = new System.Drawing.Point(14, 90);
            this.tAccuracyPercent.Name = "tAccuracyPercent";
            this.tAccuracyPercent.Size = new System.Drawing.Size(100, 20);
            this.tAccuracyPercent.TabIndex = 34;
            this.tAccuracyPercent.Text = "1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(124, 175);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "kP";
            // 
            // tkP
            // 
            this.tkP.Location = new System.Drawing.Point(14, 168);
            this.tkP.Name = "tkP";
            this.tkP.Size = new System.Drawing.Size(100, 20);
            this.tkP.TabIndex = 36;
            this.tkP.Text = "1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(124, 201);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(16, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "kI";
            // 
            // tkI
            // 
            this.tkI.Location = new System.Drawing.Point(14, 194);
            this.tkI.Name = "tkI";
            this.tkI.Size = new System.Drawing.Size(100, 20);
            this.tkI.TabIndex = 38;
            this.tkI.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(124, 227);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 41;
            this.label20.Text = "kD";
            // 
            // tkD
            // 
            this.tkD.Location = new System.Drawing.Point(14, 220);
            this.tkD.Name = "tkD";
            this.tkD.Size = new System.Drawing.Size(100, 20);
            this.tkD.TabIndex = 40;
            this.tkD.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(7, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 107);
            this.panel1.TabIndex = 42;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 142);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 13);
            this.label21.TabIndex = 43;
            this.label21.Text = "PID Constants";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 388);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.nPylon4PWM);
            this.Controls.Add(this.nPylon3PWM);
            this.Controls.Add(this.nPylon2PWM);
            this.Controls.Add(this.nPylon1PWM);
            this.Controls.Add(this.nPylon3Value);
            this.Controls.Add(this.nPylon4Value);
            this.Controls.Add(this.nPylon2Value);
            this.Controls.Add(this.nPylon1Value);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tSecondaryCommand);
            this.Controls.Add(this.tPrimaryCommand);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cAutoMode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cControllerMode);
            this.Controls.Add(this.lProgress);
            this.Controls.Add(this.pProgress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nThrottleCmd);
            this.Controls.Add(this.nRollCmd);
            this.Controls.Add(this.nYawCmd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nPitchCmd);
            this.Controls.Add(this.cFlightMode);
            this.Controls.Add(this.bSTOP);
            this.Controls.Add(this.bRUN);
            this.Name = "MainForm";
            this.Text = "MainForm";
            
            ((System.ComponentModel.ISupportInitialize)(this.nPitchCmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nYawCmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRollCmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThrottleCmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon1Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon2Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon3Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon4Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon1PWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon2PWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon3PWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPylon4PWM)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tabSetup.PerformLayout();
            this.tabResults.ResumeLayout(false);
            this.tabResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bRUN;
        private System.Windows.Forms.Button bSTOP;
        private System.Windows.Forms.ComboBox cFlightMode;
        private System.Windows.Forms.NumericUpDown nPitchCmd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nYawCmd;
        private System.Windows.Forms.NumericUpDown nRollCmd;
        private System.Windows.Forms.NumericUpDown nThrottleCmd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPID;
        private System.Windows.Forms.ProgressBar pProgress;
        private System.Windows.Forms.Label lProgress;
        private System.Windows.Forms.TextBox tTimeBase;
        private System.Windows.Forms.TextBox tDelay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cControllerMode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cAutoMode;
        private System.Windows.Forms.TextBox tPrimaryCommand;
        private System.Windows.Forms.TextBox tSecondaryCommand;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tBaseVoltage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nPylon1Value;
        private System.Windows.Forms.NumericUpDown nPylon2Value;
        private System.Windows.Forms.NumericUpDown nPylon3Value;
        private System.Windows.Forms.NumericUpDown nPylon4Value;
        private System.Windows.Forms.NumericUpDown nPylon1PWM;
        private System.Windows.Forms.NumericUpDown nPylon2PWM;
        private System.Windows.Forms.NumericUpDown nPylon3PWM;
        private System.Windows.Forms.NumericUpDown nPylon4PWM;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.TextBox tResults;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tkD;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tkI;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tkP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tAccuracyPercent;
        private System.Windows.Forms.Panel panel1;
    }
}

