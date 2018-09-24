namespace Network_Device_Monitor
{
    partial class FormDisplay
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
            this.heartbeat = new System.Windows.Forms.Timer(this.components);
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.listDevices = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestEmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // heartbeat
            // 
            this.heartbeat.Enabled = true;
            this.heartbeat.Interval = 5000;
            this.heartbeat.Tick += new System.EventHandler(this.heartbeat_Tick);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(101, 10);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(138, 20);
            this.txtIP.TabIndex = 0;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(245, 10);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(23, 20);
            this.btnAddDevice.TabIndex = 1;
            this.btnAddDevice.Text = ">";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 330);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(442, 111);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.Text = "";
            // 
            // listDevices
            // 
            this.listDevices.FormattingEnabled = true;
            this.listDevices.Location = new System.Drawing.Point(12, 38);
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(442, 277);
            this.listDevices.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "New Device IP:";
            // 
            // btnTestEmail
            // 
            this.btnTestEmail.Location = new System.Drawing.Point(379, 7);
            this.btnTestEmail.Name = "btnTestEmail";
            this.btnTestEmail.Size = new System.Drawing.Size(75, 23);
            this.btnTestEmail.TabIndex = 6;
            this.btnTestEmail.Text = "Test Email";
            this.btnTestEmail.UseVisualStyleBackColor = true;
            this.btnTestEmail.Click += new System.EventHandler(this.btnTestEmail_Click);
            // 
            // FormDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 453);
            this.Controls.Add(this.btnTestEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listDevices);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.txtIP);
            this.Name = "FormDisplay";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer heartbeat;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.ListBox listDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTestEmail;
    }
}

