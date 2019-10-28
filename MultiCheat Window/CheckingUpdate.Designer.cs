namespace MultiCheat_Window
{
    public partial class CheckingUpdate
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
            this.lab_Caption = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_Caption
            // 
            this.lab_Caption.BackColor = System.Drawing.Color.White;
            this.lab_Caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lab_Caption.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_Caption.ForeColor = System.Drawing.Color.Black;
            this.lab_Caption.Location = new System.Drawing.Point(0, 0);
            this.lab_Caption.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lab_Caption.Name = "lab_Caption";
            this.lab_Caption.Size = new System.Drawing.Size(381, 46);
            this.lab_Caption.TabIndex = 2;
            this.lab_Caption.Text = "Проверка обновлений";
            this.lab_Caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Пожалуйста, подождите...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CheckingUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(381, 84);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab_Caption);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::MultiCheat_Window.Properties.Resources.icon;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CheckingUpdate";
            this.Text = "MultiCheat - Проверка обновлений";
            this.Shown += new System.EventHandler(this.CheckingUpdate_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lab_Caption;
        private System.Windows.Forms.Label label1;
    }
}