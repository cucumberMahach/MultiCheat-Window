namespace MultiCheat_Window
{
    partial class GeneralForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lab_Caption = new System.Windows.Forms.Label();
            this.lab_csgoRunning = new System.Windows.Forms.Label();
            this.timer_CSGORunning = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_TriggerBot = new System.Windows.Forms.CheckBox();
            this.checkBox_Wallhack = new System.Windows.Forms.CheckBox();
            this.track_daleyBetweenChucks = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_delayBetweenChucks = new System.Windows.Forms.Label();
            this.lab_ChuckDelay = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.track_ChuckDelay = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_delayBeforeShoot = new System.Windows.Forms.Label();
            this.track_delayBeforeShoot = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_NoRecoilSave = new System.Windows.Forms.CheckBox();
            this.checkBox_Esp = new System.Windows.Forms.CheckBox();
            this.checkBox_Aim = new System.Windows.Forms.CheckBox();
            this.checkBox_BunnyHop = new System.Windows.Forms.CheckBox();
            this.checkBox_NoRecoil = new System.Windows.Forms.CheckBox();
            this.checkBox_RadarHack = new System.Windows.Forms.CheckBox();
            this.link_site = new System.Windows.Forms.LinkLabel();
            this.link_messages = new System.Windows.Forms.LinkLabel();
            this.link_freecsgo = new System.Windows.Forms.LinkLabel();
            this.lab_version = new System.Windows.Forms.Label();
            this.checkBox_noFlash = new System.Windows.Forms.CheckBox();
            this.timerColor = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.track_daleyBetweenChucks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_ChuckDelay)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_delayBeforeShoot)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lab_Caption
            // 
            this.lab_Caption.BackColor = System.Drawing.Color.White;
            this.lab_Caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lab_Caption.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_Caption.ForeColor = System.Drawing.Color.Black;
            this.lab_Caption.Location = new System.Drawing.Point(0, 0);
            this.lab_Caption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_Caption.Name = "lab_Caption";
            this.lab_Caption.Size = new System.Drawing.Size(405, 46);
            this.lab_Caption.TabIndex = 0;
            this.lab_Caption.Text = "MultiCheat для CSGO от Alex6406";
            this.lab_Caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_csgoRunning
            // 
            this.lab_csgoRunning.BackColor = System.Drawing.Color.Firebrick;
            this.lab_csgoRunning.Dock = System.Windows.Forms.DockStyle.Top;
            this.lab_csgoRunning.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_csgoRunning.Location = new System.Drawing.Point(0, 46);
            this.lab_csgoRunning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_csgoRunning.Name = "lab_csgoRunning";
            this.lab_csgoRunning.Size = new System.Drawing.Size(405, 32);
            this.lab_csgoRunning.TabIndex = 2;
            this.lab_csgoRunning.Text = "CSGO не запущена";
            this.lab_csgoRunning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_CSGORunning
            // 
            this.timer_CSGORunning.Tick += new System.EventHandler(this.timer_CSGORunning_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 492);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "MultiCheat должен быть запущен от администратора!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_TriggerBot
            // 
            this.checkBox_TriggerBot.AutoSize = true;
            this.checkBox_TriggerBot.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox_TriggerBot.Location = new System.Drawing.Point(12, 12);
            this.checkBox_TriggerBot.Name = "checkBox_TriggerBot";
            this.checkBox_TriggerBot.Size = new System.Drawing.Size(133, 23);
            this.checkBox_TriggerBot.TabIndex = 1;
            this.checkBox_TriggerBot.Text = "Trigger Bot (F9)";
            this.checkBox_TriggerBot.UseVisualStyleBackColor = true;
            this.checkBox_TriggerBot.CheckedChanged += new System.EventHandler(this.checkBox_TriggerBot_CheckedChanged);
            // 
            // checkBox_Wallhack
            // 
            this.checkBox_Wallhack.AutoSize = true;
            this.checkBox_Wallhack.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox_Wallhack.Location = new System.Drawing.Point(9, 3);
            this.checkBox_Wallhack.Name = "checkBox_Wallhack";
            this.checkBox_Wallhack.Size = new System.Drawing.Size(129, 23);
            this.checkBox_Wallhack.TabIndex = 6;
            this.checkBox_Wallhack.Text = "Wall hack (F10)";
            this.checkBox_Wallhack.UseVisualStyleBackColor = true;
            this.checkBox_Wallhack.CheckedChanged += new System.EventHandler(this.checkBox_Wallhack_CheckedChanged);
            // 
            // track_daleyBetweenChucks
            // 
            this.track_daleyBetweenChucks.Location = new System.Drawing.Point(9, 108);
            this.track_daleyBetweenChucks.Maximum = 1000;
            this.track_daleyBetweenChucks.Name = "track_daleyBetweenChucks";
            this.track_daleyBetweenChucks.Size = new System.Drawing.Size(205, 45);
            this.track_daleyBetweenChucks.TabIndex = 3;
            this.track_daleyBetweenChucks.TickFrequency = 50;
            this.track_daleyBetweenChucks.Scroll += new System.EventHandler(this.track_delayBetweenChucks_Scroll);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 44);
            this.label2.TabIndex = 7;
            this.label2.Text = "Задержка между\r\nзажимами";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_delayBetweenChucks
            // 
            this.lab_delayBetweenChucks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lab_delayBetweenChucks.Location = new System.Drawing.Point(9, 178);
            this.lab_delayBetweenChucks.Name = "lab_delayBetweenChucks";
            this.lab_delayBetweenChucks.Size = new System.Drawing.Size(205, 19);
            this.lab_delayBetweenChucks.TabIndex = 8;
            this.lab_delayBetweenChucks.Text = "0 мс";
            this.lab_delayBetweenChucks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_ChuckDelay
            // 
            this.lab_ChuckDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lab_ChuckDelay.Location = new System.Drawing.Point(9, 245);
            this.lab_ChuckDelay.Name = "lab_ChuckDelay";
            this.lab_ChuckDelay.Size = new System.Drawing.Size(205, 19);
            this.lab_ChuckDelay.TabIndex = 15;
            this.lab_ChuckDelay.Text = "1 мс";
            this.lab_ChuckDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Время зажима";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // track_ChuckDelay
            // 
            this.track_ChuckDelay.Location = new System.Drawing.Point(9, 200);
            this.track_ChuckDelay.Maximum = 1000;
            this.track_ChuckDelay.Minimum = 1;
            this.track_ChuckDelay.Name = "track_ChuckDelay";
            this.track_ChuckDelay.Size = new System.Drawing.Size(205, 45);
            this.track_ChuckDelay.TabIndex = 4;
            this.track_ChuckDelay.TickFrequency = 50;
            this.track_ChuckDelay.Value = 1;
            this.track_ChuckDelay.Scroll += new System.EventHandler(this.track_ChuckDelay_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lab_delayBeforeShoot);
            this.panel1.Controls.Add(this.track_delayBeforeShoot);
            this.panel1.Controls.Add(this.checkBox_TriggerBot);
            this.panel1.Controls.Add(this.lab_ChuckDelay);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.track_ChuckDelay);
            this.panel1.Controls.Add(this.lab_delayBetweenChucks);
            this.panel1.Controls.Add(this.track_daleyBetweenChucks);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 414);
            this.panel1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(17, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Настройка макросов";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Задержка перед выстрелом";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_delayBeforeShoot
            // 
            this.lab_delayBeforeShoot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lab_delayBeforeShoot.Location = new System.Drawing.Point(9, 86);
            this.lab_delayBeforeShoot.Name = "lab_delayBeforeShoot";
            this.lab_delayBeforeShoot.Size = new System.Drawing.Size(205, 19);
            this.lab_delayBeforeShoot.TabIndex = 18;
            this.lab_delayBeforeShoot.Text = "0 мс";
            this.lab_delayBeforeShoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // track_delayBeforeShoot
            // 
            this.track_delayBeforeShoot.Location = new System.Drawing.Point(9, 41);
            this.track_delayBeforeShoot.Maximum = 500;
            this.track_delayBeforeShoot.Name = "track_delayBeforeShoot";
            this.track_delayBeforeShoot.Size = new System.Drawing.Size(205, 45);
            this.track_delayBeforeShoot.TabIndex = 2;
            this.track_delayBeforeShoot.TickFrequency = 25;
            this.track_delayBeforeShoot.Scroll += new System.EventHandler(this.track_delayBeforeShoot_Scroll);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox_NoRecoilSave);
            this.panel2.Controls.Add(this.checkBox_Esp);
            this.panel2.Controls.Add(this.checkBox_Aim);
            this.panel2.Controls.Add(this.checkBox_BunnyHop);
            this.panel2.Controls.Add(this.checkBox_NoRecoil);
            this.panel2.Controls.Add(this.checkBox_RadarHack);
            this.panel2.Controls.Add(this.link_site);
            this.panel2.Controls.Add(this.link_messages);
            this.panel2.Controls.Add(this.link_freecsgo);
            this.panel2.Controls.Add(this.lab_version);
            this.panel2.Controls.Add(this.checkBox_noFlash);
            this.panel2.Controls.Add(this.checkBox_Wallhack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(231, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 414);
            this.panel2.TabIndex = 17;
            // 
            // checkBox_NoRecoilSave
            // 
            this.checkBox_NoRecoilSave.AutoSize = true;
            this.checkBox_NoRecoilSave.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox_NoRecoilSave.Location = new System.Drawing.Point(9, 203);
            this.checkBox_NoRecoilSave.Name = "checkBox_NoRecoilSave";
            this.checkBox_NoRecoilSave.Size = new System.Drawing.Size(163, 23);
            this.checkBox_NoRecoilSave.TabIndex = 28;
            this.checkBox_NoRecoilSave.Text = "No Recoil Save (F10)";
            this.checkBox_NoRecoilSave.UseVisualStyleBackColor = true;
            this.checkBox_NoRecoilSave.CheckedChanged += new System.EventHandler(this.checkBox_NoRecoilSave_CheckedChanged);
            // 
            // checkBox_Esp
            // 
            this.checkBox_Esp.AutoSize = true;
            this.checkBox_Esp.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox_Esp.Location = new System.Drawing.Point(9, 174);
            this.checkBox_Esp.Name = "checkBox_Esp";
            this.checkBox_Esp.Size = new System.Drawing.Size(159, 23);
            this.checkBox_Esp.TabIndex = 27;
            this.checkBox_Esp.Text = "Wall hack ESP (F10)";
            this.checkBox_Esp.UseVisualStyleBackColor = true;
            this.checkBox_Esp.CheckedChanged += new System.EventHandler(this.checkBox_Esp_CheckedChanged);
            // 
            // checkBox_Aim
            // 
            this.checkBox_Aim.AutoSize = true;
            this.checkBox_Aim.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox_Aim.Location = new System.Drawing.Point(9, 146);
            this.checkBox_Aim.Name = "checkBox_Aim";
            this.checkBox_Aim.Size = new System.Drawing.Size(91, 23);
            this.checkBox_Aim.TabIndex = 26;
            this.checkBox_Aim.Text = "Aim (F12)";
            this.checkBox_Aim.UseVisualStyleBackColor = true;
            this.checkBox_Aim.CheckedChanged += new System.EventHandler(this.checkBox_Aim_CheckedChanged);
            // 
            // checkBox_BunnyHop
            // 
            this.checkBox_BunnyHop.AutoSize = true;
            this.checkBox_BunnyHop.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox_BunnyHop.Location = new System.Drawing.Point(9, 119);
            this.checkBox_BunnyHop.Name = "checkBox_BunnyHop";
            this.checkBox_BunnyHop.Size = new System.Drawing.Size(138, 23);
            this.checkBox_BunnyHop.TabIndex = 25;
            this.checkBox_BunnyHop.Text = "Bunny Hop (F12)";
            this.checkBox_BunnyHop.UseVisualStyleBackColor = true;
            this.checkBox_BunnyHop.CheckedChanged += new System.EventHandler(this.checkBox_BunnyHop_CheckedChanged);
            // 
            // checkBox_NoRecoil
            // 
            this.checkBox_NoRecoil.AutoSize = true;
            this.checkBox_NoRecoil.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox_NoRecoil.Location = new System.Drawing.Point(9, 90);
            this.checkBox_NoRecoil.Name = "checkBox_NoRecoil";
            this.checkBox_NoRecoil.Size = new System.Drawing.Size(128, 23);
            this.checkBox_NoRecoil.TabIndex = 24;
            this.checkBox_NoRecoil.Text = "No Recoil (F12)";
            this.checkBox_NoRecoil.UseVisualStyleBackColor = true;
            this.checkBox_NoRecoil.CheckedChanged += new System.EventHandler(this.checkBox_NoRecoil_CheckedChanged);
            // 
            // checkBox_RadarHack
            // 
            this.checkBox_RadarHack.AutoSize = true;
            this.checkBox_RadarHack.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox_RadarHack.Location = new System.Drawing.Point(9, 61);
            this.checkBox_RadarHack.Name = "checkBox_RadarHack";
            this.checkBox_RadarHack.Size = new System.Drawing.Size(140, 23);
            this.checkBox_RadarHack.TabIndex = 23;
            this.checkBox_RadarHack.Text = "Radar Hack (F12)";
            this.checkBox_RadarHack.UseVisualStyleBackColor = true;
            this.checkBox_RadarHack.CheckedChanged += new System.EventHandler(this.checkBox_RadarHack_CheckedChanged);
            // 
            // link_site
            // 
            this.link_site.ActiveLinkColor = System.Drawing.Color.Yellow;
            this.link_site.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.link_site.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.link_site.LinkColor = System.Drawing.Color.Yellow;
            this.link_site.Location = new System.Drawing.Point(14, 366);
            this.link_site.Name = "link_site";
            this.link_site.Size = new System.Drawing.Size(148, 38);
            this.link_site.TabIndex = 22;
            this.link_site.TabStop = true;
            this.link_site.Tag = "";
            this.link_site.Text = "Другие приложения\r\nalex6406.ru";
            this.link_site.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link_site.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_site_LinkClicked);
            // 
            // link_messages
            // 
            this.link_messages.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.link_messages.Font = new System.Drawing.Font("Corbel", 9.75F);
            this.link_messages.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.link_messages.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.link_messages.Location = new System.Drawing.Point(14, 256);
            this.link_messages.Name = "link_messages";
            this.link_messages.Size = new System.Drawing.Size(148, 48);
            this.link_messages.TabIndex = 9;
            this.link_messages.TabStop = true;
            this.link_messages.Tag = "";
            this.link_messages.Text = "Не работает? Вопросы?\r\nvk.com/mrkotyathread";
            this.link_messages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link_messages.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // link_freecsgo
            // 
            this.link_freecsgo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.link_freecsgo.LinkColor = System.Drawing.Color.Red;
            this.link_freecsgo.Location = new System.Drawing.Point(14, 200);
            this.link_freecsgo.Name = "link_freecsgo";
            this.link_freecsgo.Size = new System.Drawing.Size(148, 48);
            this.link_freecsgo.TabIndex = 8;
            this.link_freecsgo.TabStop = true;
            this.link_freecsgo.Tag = "";
            this.link_freecsgo.Text = "Скачать бесплатную CSGO";
            this.link_freecsgo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link_freecsgo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lab_version
            // 
            this.lab_version.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_version.ForeColor = System.Drawing.Color.Cyan;
            this.lab_version.Location = new System.Drawing.Point(14, 311);
            this.lab_version.Name = "lab_version";
            this.lab_version.Size = new System.Drawing.Size(148, 43);
            this.lab_version.TabIndex = 21;
            this.lab_version.Text = "Версия 1 от\r\n5 May 2018";
            this.lab_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_noFlash
            // 
            this.checkBox_noFlash.AutoSize = true;
            this.checkBox_noFlash.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox_noFlash.Location = new System.Drawing.Point(9, 32);
            this.checkBox_noFlash.Name = "checkBox_noFlash";
            this.checkBox_noFlash.Size = new System.Drawing.Size(121, 23);
            this.checkBox_noFlash.TabIndex = 7;
            this.checkBox_noFlash.Text = "No Flash (F11)";
            this.checkBox_noFlash.UseVisualStyleBackColor = true;
            this.checkBox_noFlash.CheckedChanged += new System.EventHandler(this.checkBox_noFlash_CheckedChanged);
            // 
            // timerColor
            // 
            this.timerColor.Enabled = true;
            this.timerColor.Interval = 1;
            this.timerColor.Tick += new System.EventHandler(this.timerColor_Tick);
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(405, 519);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab_csgoRunning);
            this.Controls.Add(this.lab_Caption);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::MultiCheat_Window.Properties.Resources.icon;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GeneralForm";
            this.Text = "MultiCheat CSGO";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GeneralForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.track_daleyBetweenChucks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_ChuckDelay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_delayBeforeShoot)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lab_Caption;
        private System.Windows.Forms.Label lab_csgoRunning;
        private System.Windows.Forms.Timer timer_CSGORunning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_TriggerBot;
        private System.Windows.Forms.CheckBox checkBox_Wallhack;
        private System.Windows.Forms.TrackBar track_daleyBetweenChucks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_delayBetweenChucks;
        private System.Windows.Forms.Label lab_ChuckDelay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar track_ChuckDelay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_delayBeforeShoot;
        private System.Windows.Forms.TrackBar track_delayBeforeShoot;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_noFlash;
        private System.Windows.Forms.Label lab_version;
        private System.Windows.Forms.LinkLabel link_freecsgo;
        private System.Windows.Forms.LinkLabel link_messages;
        private System.Windows.Forms.LinkLabel link_site;
        private System.Windows.Forms.Timer timerColor;
        private System.Windows.Forms.CheckBox checkBox_RadarHack;
        private System.Windows.Forms.CheckBox checkBox_NoRecoil;
        private System.Windows.Forms.CheckBox checkBox_BunnyHop;
        private System.Windows.Forms.CheckBox checkBox_Aim;
        private System.Windows.Forms.CheckBox checkBox_Esp;
        private System.Windows.Forms.CheckBox checkBox_NoRecoilSave;
    }
}

