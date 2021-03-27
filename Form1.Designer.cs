
namespace AFTHY {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.videoDevices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RobotSelector = new System.Windows.Forms.ComboBox();
            this.ComPortLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(441, 334);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // videoDevices
            // 
            this.videoDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoDevices.FormattingEnabled = true;
            this.videoDevices.Location = new System.Drawing.Point(188, 356);
            this.videoDevices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.videoDevices.Name = "videoDevices";
            this.videoDevices.Size = new System.Drawing.Size(268, 33);
            this.videoDevices.TabIndex = 2;
            this.videoDevices.SelectedIndexChanged += new System.EventHandler(this.videoDevices_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 366);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Video source";
            // 
            // RobotSelector
            // 
            this.RobotSelector.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotSelector.FormattingEnabled = true;
            this.RobotSelector.Location = new System.Drawing.Point(188, 411);
            this.RobotSelector.Name = "RobotSelector";
            this.RobotSelector.Size = new System.Drawing.Size(268, 31);
            this.RobotSelector.TabIndex = 4;
            this.RobotSelector.SelectedIndexChanged += new System.EventHandler(this.RobotSelector_SelectedIndexChanged_1);
            // 
            // ComPortLabel
            // 
            this.ComPortLabel.AutoSize = true;
            this.ComPortLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPortLabel.Location = new System.Drawing.Point(45, 419);
            this.ComPortLabel.Name = "ComPortLabel";
            this.ComPortLabel.Size = new System.Drawing.Size(98, 23);
            this.ComPortLabel.TabIndex = 5;
            this.ComPortLabel.Text = "Com Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ComPortLabel);
            this.Controls.Add(this.RobotSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.videoDevices);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Idiot Cam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox videoDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RobotSelector;
        private System.Windows.Forms.Label ComPortLabel;
    }
}

