namespace mw2_fps_unlocker
{
    partial class AppForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this.LabelFPS = new System.Windows.Forms.Label();
            this.LabelFOV = new System.Windows.Forms.Label();
            this.LabelFPSValue = new System.Windows.Forms.Label();
            this.LabelFOVValue = new System.Windows.Forms.Label();
            this.LabelStatusValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelFPS
            // 
            this.LabelFPS.AutoSize = true;
            this.LabelFPS.Location = new System.Drawing.Point(12, 43);
            this.LabelFPS.Name = "LabelFPS";
            this.LabelFPS.Size = new System.Drawing.Size(29, 15);
            this.LabelFPS.TabIndex = 0;
            this.LabelFPS.Text = "FPS:";
            // 
            // LabelFOV
            // 
            this.LabelFOV.AutoSize = true;
            this.LabelFOV.Location = new System.Drawing.Point(12, 80);
            this.LabelFOV.Name = "LabelFOV";
            this.LabelFOV.Size = new System.Drawing.Size(32, 15);
            this.LabelFOV.TabIndex = 1;
            this.LabelFOV.Text = "FOV:";
            // 
            // LabelFPSValue
            // 
            this.LabelFPSValue.AutoSize = true;
            this.LabelFPSValue.Location = new System.Drawing.Point(207, 43);
            this.LabelFPSValue.Name = "LabelFPSValue";
            this.LabelFPSValue.Size = new System.Drawing.Size(25, 15);
            this.LabelFPSValue.TabIndex = 4;
            this.LabelFPSValue.Text = "300";
            // 
            // LabelFOVValue
            // 
            this.LabelFOVValue.AutoSize = true;
            this.LabelFOVValue.Location = new System.Drawing.Point(207, 80);
            this.LabelFOVValue.Name = "LabelFOVValue";
            this.LabelFOVValue.Size = new System.Drawing.Size(19, 15);
            this.LabelFOVValue.TabIndex = 6;
            this.LabelFOVValue.Text = "80";
            // 
            // LabelStatusValue
            // 
            this.LabelStatusValue.AutoSize = true;
            this.LabelStatusValue.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LabelStatusValue.Location = new System.Drawing.Point(12, 12);
            this.LabelStatusValue.Name = "LabelStatusValue";
            this.LabelStatusValue.Size = new System.Drawing.Size(76, 15);
            this.LabelStatusValue.TabIndex = 8;
            this.LabelStatusValue.Text = "Not In-Game";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(166, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "by branders";
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(247, 134);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelStatusValue);
            this.Controls.Add(this.LabelFOVValue);
            this.Controls.Add(this.LabelFPSValue);
            this.Controls.Add(this.LabelFOV);
            this.Controls.Add(this.LabelFPS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FPS Unlocker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LabelFPS;
        private Label LabelFOV;
        private Label LabelFPSValue;
        private Label LabelFOVValue;
        private Label LabelStatusValue;
        private Label label1;
    }
}