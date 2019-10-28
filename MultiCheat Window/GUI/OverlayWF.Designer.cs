namespace MultiCheat_Window.GUI
{
    partial class OverlayWF
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
            this.components = new System.ComponentModel.Container();
            this.panel_Title = new System.Windows.Forms.Panel();
            this.button_Info = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.lab_title = new System.Windows.Forms.Label();
            this.label_ChuckDelay = new System.Windows.Forms.Label();
            this.label_DelayBetweenChucks = new System.Windows.Forms.Label();
            this.label_DelayBeforeShoot = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_enableTrigger = new System.Windows.Forms.CheckBox();
            this.track_delayBeforeShoot = new System.Windows.Forms.TrackBar();
            this.track_ChuckDelay = new System.Windows.Forms.TrackBar();
            this.track_delayBetweenChucks = new System.Windows.Forms.TrackBar();
            this.checkBox_NoRecoilSave = new System.Windows.Forms.CheckBox();
            this.checkBox_NoRecoil = new System.Windows.Forms.CheckBox();
            this.checkBox2_WallHackESP = new System.Windows.Forms.CheckBox();
            this.checkBox_WallHack = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_AimSpeed = new System.Windows.Forms.Label();
            this.trackBar_AimSpeed = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label_AimRadius = new System.Windows.Forms.Label();
            this.trackBar_AimRadius = new System.Windows.Forms.TrackBar();
            this.checkBox_Aim = new System.Windows.Forms.CheckBox();
            this.checkBox_RadarHack = new System.Windows.Forms.CheckBox();
            this.checkBox_BunnyHop = new System.Windows.Forms.CheckBox();
            this.checkBox_NoFlash = new System.Windows.Forms.CheckBox();
            this.timer_CSGORunning = new System.Windows.Forms.Timer(this.components);
            this.panel_Cheats = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.notifyIcon_Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_delayBeforeShoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_ChuckDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_delayBetweenChucks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AimSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AimRadius)).BeginInit();
            this.panel_Cheats.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Title
            // 
            this.panel_Title.BackColor = System.Drawing.Color.Gold;
            this.panel_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Title.Controls.Add(this.button_Info);
            this.panel_Title.Controls.Add(this.button_Exit);
            this.panel_Title.Controls.Add(this.lab_title);
            this.panel_Title.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel_Title.Location = new System.Drawing.Point(18, 18);
            this.panel_Title.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(526, 35);
            this.panel_Title.TabIndex = 2;
            // 
            // button_Info
            // 
            this.button_Info.BackColor = System.Drawing.Color.Transparent;
            this.button_Info.BackgroundImage = global::MultiCheat_Window.Properties.Resources.info1;
            this.button_Info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Info.FlatAppearance.BorderSize = 0;
            this.button_Info.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Olive;
            this.button_Info.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button_Info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Info.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Info.Location = new System.Drawing.Point(465, 4);
            this.button_Info.Margin = new System.Windows.Forms.Padding(4);
            this.button_Info.Name = "button_Info";
            this.button_Info.Size = new System.Drawing.Size(24, 24);
            this.button_Info.TabIndex = 20;
            this.button_Info.UseVisualStyleBackColor = false;
            this.button_Info.Visible = false;
            this.button_Info.Click += new System.EventHandler(this.button_Info_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.Color.Transparent;
            this.button_Exit.BackgroundImage = global::MultiCheat_Window.Properties.Resources.close;
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Exit.FlatAppearance.BorderSize = 0;
            this.button_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Olive;
            this.button_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Exit.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Exit.Location = new System.Drawing.Point(496, 4);
            this.button_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(24, 24);
            this.button_Exit.TabIndex = 19;
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // lab_title
            // 
            this.lab_title.BackColor = System.Drawing.Color.Transparent;
            this.lab_title.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_title.Location = new System.Drawing.Point(4, 3);
            this.lab_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_title.Name = "lab_title";
            this.lab_title.Size = new System.Drawing.Size(453, 24);
            this.lab_title.TabIndex = 5;
            this.lab_title.Text = "MultiCheat by Alex6406";
            this.lab_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lab_title_MouseDown);
            this.lab_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lab_title_MouseMove);
            this.lab_title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lab_title_MouseUp);
            // 
            // label_ChuckDelay
            // 
            this.label_ChuckDelay.AutoSize = true;
            this.label_ChuckDelay.Location = new System.Drawing.Point(217, 125);
            this.label_ChuckDelay.Name = "label_ChuckDelay";
            this.label_ChuckDelay.Size = new System.Drawing.Size(30, 15);
            this.label_ChuckDelay.TabIndex = 33;
            this.label_ChuckDelay.Text = "1 мс";
            // 
            // label_DelayBetweenChucks
            // 
            this.label_DelayBetweenChucks.AutoSize = true;
            this.label_DelayBetweenChucks.Location = new System.Drawing.Point(460, 73);
            this.label_DelayBetweenChucks.Name = "label_DelayBetweenChucks";
            this.label_DelayBetweenChucks.Size = new System.Drawing.Size(31, 15);
            this.label_DelayBetweenChucks.TabIndex = 32;
            this.label_DelayBetweenChucks.Text = "0 мс";
            // 
            // label_DelayBeforeShoot
            // 
            this.label_DelayBeforeShoot.AutoSize = true;
            this.label_DelayBeforeShoot.Location = new System.Drawing.Point(217, 73);
            this.label_DelayBeforeShoot.Name = "label_DelayBeforeShoot";
            this.label_DelayBeforeShoot.Size = new System.Drawing.Size(31, 15);
            this.label_DelayBeforeShoot.TabIndex = 31;
            this.label_DelayBeforeShoot.Text = "0 мс";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "Время зажима:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Задержка между зажимами:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "Задержка перед выстрелом:";
            // 
            // checkBox_enableTrigger
            // 
            this.checkBox_enableTrigger.AutoSize = true;
            this.checkBox_enableTrigger.Location = new System.Drawing.Point(20, 22);
            this.checkBox_enableTrigger.Name = "checkBox_enableTrigger";
            this.checkBox_enableTrigger.Size = new System.Drawing.Size(92, 19);
            this.checkBox_enableTrigger.TabIndex = 27;
            this.checkBox_enableTrigger.Text = "Триггер бот";
            this.checkBox_enableTrigger.UseVisualStyleBackColor = true;
            this.checkBox_enableTrigger.CheckedChanged += new System.EventHandler(this.checkBox_enableTrigger_CheckedChanged);
            // 
            // track_delayBeforeShoot
            // 
            this.track_delayBeforeShoot.Location = new System.Drawing.Point(20, 73);
            this.track_delayBeforeShoot.Maximum = 500;
            this.track_delayBeforeShoot.Name = "track_delayBeforeShoot";
            this.track_delayBeforeShoot.Size = new System.Drawing.Size(191, 45);
            this.track_delayBeforeShoot.TabIndex = 20;
            this.track_delayBeforeShoot.TickFrequency = 25;
            this.track_delayBeforeShoot.Scroll += new System.EventHandler(this.track_delayBeforeShoot_Scroll);
            // 
            // track_ChuckDelay
            // 
            this.track_ChuckDelay.Location = new System.Drawing.Point(20, 125);
            this.track_ChuckDelay.Maximum = 1000;
            this.track_ChuckDelay.Minimum = 1;
            this.track_ChuckDelay.Name = "track_ChuckDelay";
            this.track_ChuckDelay.Size = new System.Drawing.Size(191, 45);
            this.track_ChuckDelay.TabIndex = 22;
            this.track_ChuckDelay.TickFrequency = 50;
            this.track_ChuckDelay.Value = 1;
            this.track_ChuckDelay.Scroll += new System.EventHandler(this.track_ChuckDelay_Scroll);
            // 
            // track_delayBetweenChucks
            // 
            this.track_delayBetweenChucks.Location = new System.Drawing.Point(263, 73);
            this.track_delayBetweenChucks.Maximum = 1000;
            this.track_delayBetweenChucks.Name = "track_delayBetweenChucks";
            this.track_delayBetweenChucks.Size = new System.Drawing.Size(191, 45);
            this.track_delayBetweenChucks.TabIndex = 21;
            this.track_delayBetweenChucks.TickFrequency = 50;
            this.track_delayBetweenChucks.Scroll += new System.EventHandler(this.track_delayBetweenChucks_Scroll);
            // 
            // checkBox_NoRecoilSave
            // 
            this.checkBox_NoRecoilSave.AutoSize = true;
            this.checkBox_NoRecoilSave.Location = new System.Drawing.Point(141, 22);
            this.checkBox_NoRecoilSave.Name = "checkBox_NoRecoilSave";
            this.checkBox_NoRecoilSave.Size = new System.Drawing.Size(183, 19);
            this.checkBox_NoRecoilSave.TabIndex = 30;
            this.checkBox_NoRecoilSave.Text = "Показывать точку с отдачей";
            this.checkBox_NoRecoilSave.UseVisualStyleBackColor = true;
            this.checkBox_NoRecoilSave.CheckedChanged += new System.EventHandler(this.checkBox_NoRecoilSave_CheckedChanged);
            // 
            // checkBox_NoRecoil
            // 
            this.checkBox_NoRecoil.AutoSize = true;
            this.checkBox_NoRecoil.Location = new System.Drawing.Point(19, 22);
            this.checkBox_NoRecoil.Name = "checkBox_NoRecoil";
            this.checkBox_NoRecoil.Size = new System.Drawing.Size(95, 19);
            this.checkBox_NoRecoil.TabIndex = 28;
            this.checkBox_NoRecoil.Text = "Анти отдача";
            this.checkBox_NoRecoil.UseVisualStyleBackColor = true;
            this.checkBox_NoRecoil.CheckedChanged += new System.EventHandler(this.checkBox_NoRecoil_CheckedChanged);
            // 
            // checkBox2_WallHackESP
            // 
            this.checkBox2_WallHackESP.AutoSize = true;
            this.checkBox2_WallHackESP.Location = new System.Drawing.Point(141, 22);
            this.checkBox2_WallHackESP.Name = "checkBox2_WallHackESP";
            this.checkBox2_WallHackESP.Size = new System.Drawing.Size(85, 19);
            this.checkBox2_WallHackESP.TabIndex = 32;
            this.checkBox2_WallHackESP.Text = "ВХ (точки)";
            this.checkBox2_WallHackESP.UseVisualStyleBackColor = true;
            this.checkBox2_WallHackESP.CheckedChanged += new System.EventHandler(this.checkBox2_WallHackESP_CheckedChanged);
            // 
            // checkBox_WallHack
            // 
            this.checkBox_WallHack.AutoSize = true;
            this.checkBox_WallHack.Location = new System.Drawing.Point(19, 22);
            this.checkBox_WallHack.Name = "checkBox_WallHack";
            this.checkBox_WallHack.Size = new System.Drawing.Size(79, 19);
            this.checkBox_WallHack.TabIndex = 31;
            this.checkBox_WallHack.Text = "ВХ (glow)";
            this.checkBox_WallHack.UseVisualStyleBackColor = true;
            this.checkBox_WallHack.CheckedChanged += new System.EventHandler(this.checkBox_WallHack_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Плавность наведения:";
            // 
            // label_AimSpeed
            // 
            this.label_AimSpeed.AutoSize = true;
            this.label_AimSpeed.Location = new System.Drawing.Point(472, 77);
            this.label_AimSpeed.Name = "label_AimSpeed";
            this.label_AimSpeed.Size = new System.Drawing.Size(13, 15);
            this.label_AimSpeed.TabIndex = 37;
            this.label_AimSpeed.Text = "5";
            // 
            // trackBar_AimSpeed
            // 
            this.trackBar_AimSpeed.Location = new System.Drawing.Point(274, 79);
            this.trackBar_AimSpeed.Maximum = 1000;
            this.trackBar_AimSpeed.Minimum = 100;
            this.trackBar_AimSpeed.Name = "trackBar_AimSpeed";
            this.trackBar_AimSpeed.Size = new System.Drawing.Size(192, 45);
            this.trackBar_AimSpeed.TabIndex = 36;
            this.trackBar_AimSpeed.TickFrequency = 25;
            this.trackBar_AimSpeed.Value = 500;
            this.trackBar_AimSpeed.Scroll += new System.EventHandler(this.trackBar_AimSpeed_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 15);
            this.label5.TabIndex = 35;
            this.label5.Text = "Радиус срабатывания:";
            // 
            // label_AimRadius
            // 
            this.label_AimRadius.AutoSize = true;
            this.label_AimRadius.Location = new System.Drawing.Point(217, 77);
            this.label_AimRadius.Name = "label_AimRadius";
            this.label_AimRadius.Size = new System.Drawing.Size(43, 15);
            this.label_AimRadius.TabIndex = 34;
            this.label_AimRadius.Text = "100 px";
            // 
            // trackBar_AimRadius
            // 
            this.trackBar_AimRadius.Location = new System.Drawing.Point(19, 79);
            this.trackBar_AimRadius.Maximum = 1200;
            this.trackBar_AimRadius.Minimum = 10;
            this.trackBar_AimRadius.Name = "trackBar_AimRadius";
            this.trackBar_AimRadius.Size = new System.Drawing.Size(192, 45);
            this.trackBar_AimRadius.TabIndex = 33;
            this.trackBar_AimRadius.TickFrequency = 25;
            this.trackBar_AimRadius.Value = 100;
            this.trackBar_AimRadius.Scroll += new System.EventHandler(this.trackBar_AimRadius_Scroll);
            // 
            // checkBox_Aim
            // 
            this.checkBox_Aim.AutoSize = true;
            this.checkBox_Aim.Location = new System.Drawing.Point(19, 22);
            this.checkBox_Aim.Name = "checkBox_Aim";
            this.checkBox_Aim.Size = new System.Drawing.Size(49, 19);
            this.checkBox_Aim.TabIndex = 32;
            this.checkBox_Aim.Text = "Аим";
            this.checkBox_Aim.UseVisualStyleBackColor = true;
            this.checkBox_Aim.CheckedChanged += new System.EventHandler(this.checkBox_Aim_CheckedChanged);
            // 
            // checkBox_RadarHack
            // 
            this.checkBox_RadarHack.AutoSize = true;
            this.checkBox_RadarHack.Location = new System.Drawing.Point(240, 22);
            this.checkBox_RadarHack.Name = "checkBox_RadarHack";
            this.checkBox_RadarHack.Size = new System.Drawing.Size(81, 19);
            this.checkBox_RadarHack.TabIndex = 31;
            this.checkBox_RadarHack.Text = "Радар хак";
            this.checkBox_RadarHack.UseVisualStyleBackColor = true;
            this.checkBox_RadarHack.CheckedChanged += new System.EventHandler(this.checkBox_RadarHack_CheckedChanged);
            // 
            // checkBox_BunnyHop
            // 
            this.checkBox_BunnyHop.AutoSize = true;
            this.checkBox_BunnyHop.Location = new System.Drawing.Point(126, 22);
            this.checkBox_BunnyHop.Name = "checkBox_BunnyHop";
            this.checkBox_BunnyHop.Size = new System.Drawing.Size(85, 19);
            this.checkBox_BunnyHop.TabIndex = 30;
            this.checkBox_BunnyHop.Text = "Банни-хоп";
            this.checkBox_BunnyHop.UseVisualStyleBackColor = true;
            this.checkBox_BunnyHop.CheckedChanged += new System.EventHandler(this.checkBox_BunnyHop_CheckedChanged);
            // 
            // checkBox_NoFlash
            // 
            this.checkBox_NoFlash.AutoSize = true;
            this.checkBox_NoFlash.Location = new System.Drawing.Point(10, 22);
            this.checkBox_NoFlash.Name = "checkBox_NoFlash";
            this.checkBox_NoFlash.Size = new System.Drawing.Size(88, 19);
            this.checkBox_NoFlash.TabIndex = 29;
            this.checkBox_NoFlash.Text = "Анти флеш";
            this.checkBox_NoFlash.UseVisualStyleBackColor = true;
            this.checkBox_NoFlash.CheckedChanged += new System.EventHandler(this.checkBox_NoFlash_CheckedChanged);
            // 
            // timer_CSGORunning
            // 
            this.timer_CSGORunning.Enabled = true;
            this.timer_CSGORunning.Tick += new System.EventHandler(this.timer_CSGORunning_Tick);
            // 
            // panel_Cheats
            // 
            this.panel_Cheats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_Cheats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Cheats.Controls.Add(this.linkLabel1);
            this.panel_Cheats.Controls.Add(this.label7);
            this.panel_Cheats.Controls.Add(this.groupBox5);
            this.panel_Cheats.Controls.Add(this.groupBox4);
            this.panel_Cheats.Controls.Add(this.groupBox3);
            this.panel_Cheats.Controls.Add(this.groupBox2);
            this.panel_Cheats.Controls.Add(this.groupBox1);
            this.panel_Cheats.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel_Cheats.ForeColor = System.Drawing.Color.Gold;
            this.panel_Cheats.Location = new System.Drawing.Point(18, 55);
            this.panel_Cheats.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Cheats.Name = "panel_Cheats";
            this.panel_Cheats.Size = new System.Drawing.Size(526, 553);
            this.panel_Cheats.TabIndex = 6;
            this.panel_Cheats.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(4, 525);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(511, 19);
            this.linkLabel1.TabIndex = 22;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Группа ВК";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(131, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(270, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Игра должна работать на полный экран в окне";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox_RadarHack);
            this.groupBox5.Controls.Add(this.checkBox_NoFlash);
            this.groupBox5.Controls.Add(this.checkBox_BunnyHop);
            this.groupBox5.Location = new System.Drawing.Point(8, 462);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(507, 60);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Другое";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.checkBox_Aim);
            this.groupBox4.Controls.Add(this.label_AimSpeed);
            this.groupBox4.Controls.Add(this.trackBar_AimRadius);
            this.groupBox4.Controls.Add(this.trackBar_AimSpeed);
            this.groupBox4.Controls.Add(this.label_AimRadius);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(8, 327);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(507, 129);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Аим";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(241, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(248, 15);
            this.label6.TabIndex = 39;
            this.label6.Text = "(для работы Аима скройте меню настроек)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox2_WallHackESP);
            this.groupBox3.Controls.Add(this.checkBox_WallHack);
            this.groupBox3.Location = new System.Drawing.Point(8, 268);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 53);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ВХ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_NoRecoilSave);
            this.groupBox2.Controls.Add(this.checkBox_NoRecoil);
            this.groupBox2.Location = new System.Drawing.Point(8, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отдача";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_ChuckDelay);
            this.groupBox1.Controls.Add(this.checkBox_enableTrigger);
            this.groupBox1.Controls.Add(this.label_DelayBetweenChucks);
            this.groupBox1.Controls.Add(this.track_delayBetweenChucks);
            this.groupBox1.Controls.Add(this.label_DelayBeforeShoot);
            this.groupBox1.Controls.Add(this.track_ChuckDelay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.track_delayBeforeShoot);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Триггер бот";
            // 
            // notifyIcon_Tray
            // 
            this.notifyIcon_Tray.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon_Tray.Icon = global::MultiCheat_Window.Properties.Resources.icon;
            this.notifyIcon_Tray.Text = "MultiCheat";
            this.notifyIcon_Tray.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(109, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItem1.Text = "Выход";
            // 
            // OverlayWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(1583, 997);
            this.Controls.Add(this.panel_Cheats);
            this.Controls.Add(this.panel_Title);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OverlayWF";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "OverlayWF";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Purple;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track_delayBeforeShoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_ChuckDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_delayBetweenChucks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AimSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AimRadius)).EndInit();
            this.panel_Cheats.ResumeLayout(false);
            this.panel_Cheats.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.Label lab_title;
        private System.Windows.Forms.Button button_Info;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TrackBar track_delayBeforeShoot;
        private System.Windows.Forms.TrackBar track_ChuckDelay;
        private System.Windows.Forms.TrackBar track_delayBetweenChucks;
        private System.Windows.Forms.CheckBox checkBox_enableTrigger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_DelayBeforeShoot;
        private System.Windows.Forms.Label label_ChuckDelay;
        private System.Windows.Forms.Label label_DelayBetweenChucks;
        private System.Windows.Forms.Timer timer_CSGORunning;
        private System.Windows.Forms.Panel panel_Cheats;
        private System.Windows.Forms.CheckBox checkBox_NoRecoil;
        private System.Windows.Forms.CheckBox checkBox_NoRecoilSave;
        private System.Windows.Forms.CheckBox checkBox_WallHack;
        private System.Windows.Forms.CheckBox checkBox2_WallHackESP;
        private System.Windows.Forms.CheckBox checkBox_NoFlash;
        private System.Windows.Forms.CheckBox checkBox_BunnyHop;
        private System.Windows.Forms.CheckBox checkBox_RadarHack;
        private System.Windows.Forms.CheckBox checkBox_Aim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_AimRadius;
        private System.Windows.Forms.TrackBar trackBar_AimRadius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_AimSpeed;
        private System.Windows.Forms.TrackBar trackBar_AimSpeed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NotifyIcon notifyIcon_Tray;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}