namespace MultiCheat_Window
{
    partial class UpdateForm
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
            this.lab_Caption = new System.Windows.Forms.Label();
            this.lab_Update = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lab_status = new System.Windows.Forms.Label();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lab_Caption
            // 
            this.lab_Caption.BackColor = System.Drawing.Color.White;
            this.lab_Caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lab_Caption.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_Caption.ForeColor = System.Drawing.Color.Black;
            this.lab_Caption.Location = new System.Drawing.Point(0, 0);
            this.lab_Caption.Name = "lab_Caption";
            this.lab_Caption.Size = new System.Drawing.Size(416, 36);
            this.lab_Caption.TabIndex = 1;
            this.lab_Caption.Text = "Автоматическое обновление чита";
            this.lab_Caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_Update
            // 
            this.lab_Update.Location = new System.Drawing.Point(11, 48);
            this.lab_Update.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_Update.Name = "lab_Update";
            this.lab_Update.Size = new System.Drawing.Size(394, 15);
            this.lab_Update.TabIndex = 2;
            this.lab_Update.Text = "Загрузка обновления. Пожалуйста, подождите...";
            this.lab_Update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 67);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(396, 20);
            this.progressBar.TabIndex = 3;
            // 
            // lab_status
            // 
            this.lab_status.ForeColor = System.Drawing.Color.Black;
            this.lab_status.Location = new System.Drawing.Point(9, 89);
            this.lab_status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_status.Name = "lab_status";
            this.lab_status.Size = new System.Drawing.Size(396, 20);
            this.lab_status.TabIndex = 4;
            this.lab_status.Text = "Загрузка...";
            this.lab_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerStatus
            // 
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(416, 113);
            this.Controls.Add(this.lab_status);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lab_Update);
            this.Controls.Add(this.lab_Caption);
            this.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::MultiCheat_Window.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.Name = "UpdateForm";
            this.Text = "MultiCheat - Обновление";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateForm_FormClosed);
            this.Shown += new System.EventHandler(this.UpdateForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lab_Caption;
        private System.Windows.Forms.Label lab_Update;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lab_status;
        private System.Windows.Forms.Timer timerStatus;
    }
}