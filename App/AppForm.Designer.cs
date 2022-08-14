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
            this.LabelFPS = new System.Windows.Forms.Label();
            this.LabelFOV = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.TrackBarFPS = new System.Windows.Forms.TrackBar();
            this.LabelFPSValue = new System.Windows.Forms.Label();
            this.TrackBarFOV = new System.Windows.Forms.TrackBar();
            this.LabelFOVValue = new System.Windows.Forms.Label();
            this.LabelStatusValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarFOV)).BeginInit();
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
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(12, 124);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(214, 28);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            // 
            // TrackBarFPS
            // 
            this.TrackBarFPS.Location = new System.Drawing.Point(50, 41);
            this.TrackBarFPS.Maximum = 300;
            this.TrackBarFPS.Minimum = 75;
            this.TrackBarFPS.Name = "TrackBarFPS";
            this.TrackBarFPS.Size = new System.Drawing.Size(151, 45);
            this.TrackBarFPS.TabIndex = 3;
            this.TrackBarFPS.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrackBarFPS.Value = 75;
            // 
            // LabelFPSValue
            // 
            this.LabelFPSValue.AutoSize = true;
            this.LabelFPSValue.Location = new System.Drawing.Point(207, 43);
            this.LabelFPSValue.Name = "LabelFPSValue";
            this.LabelFPSValue.Size = new System.Drawing.Size(19, 15);
            this.LabelFPSValue.TabIndex = 4;
            this.LabelFPSValue.Text = "75";
            // 
            // TrackBarFOV
            // 
            this.TrackBarFOV.BackColor = System.Drawing.SystemColors.Control;
            this.TrackBarFOV.Location = new System.Drawing.Point(50, 80);
            this.TrackBarFOV.Maximum = 100;
            this.TrackBarFOV.Minimum = 60;
            this.TrackBarFOV.Name = "TrackBarFOV";
            this.TrackBarFOV.Size = new System.Drawing.Size(151, 45);
            this.TrackBarFOV.TabIndex = 5;
            this.TrackBarFOV.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrackBarFOV.Value = 75;
            // 
            // LabelFOVValue
            // 
            this.LabelFOVValue.AutoSize = true;
            this.LabelFOVValue.Location = new System.Drawing.Point(207, 80);
            this.LabelFOVValue.Name = "LabelFOVValue";
            this.LabelFOVValue.Size = new System.Drawing.Size(19, 15);
            this.LabelFOVValue.TabIndex = 6;
            this.LabelFOVValue.Text = "75";
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
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(243, 161);
            this.Controls.Add(this.LabelStatusValue);
            this.Controls.Add(this.LabelFOVValue);
            this.Controls.Add(this.TrackBarFOV);
            this.Controls.Add(this.LabelFPSValue);
            this.Controls.Add(this.TrackBarFPS);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.LabelFOV);
            this.Controls.Add(this.LabelFPS);
            this.MaximumSize = new System.Drawing.Size(259, 200);
            this.MinimumSize = new System.Drawing.Size(259, 200);
            this.Name = "AppForm";
            this.Text = "FPS Unlocker";
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarFOV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LabelFPS;
        private Label LabelFOV;
        private Button ButtonSave;
        private TrackBar TrackBarFPS;
        private Label LabelFPSValue;
        private TrackBar TrackBarFOV;
        private Label LabelFOVValue;
        private Label LabelStatusValue;
    }
}