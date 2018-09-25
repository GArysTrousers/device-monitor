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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveDevice = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
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
            this.txtIP.Location = new System.Drawing.Point(212, 40);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(132, 20);
            this.txtIP.TabIndex = 0;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(350, 39);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(23, 23);
            this.btnAddDevice.TabIndex = 1;
            this.btnAddDevice.Text = ">";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 377);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(442, 64);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.Text = "";
            // 
            // listDevices
            // 
            this.listDevices.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDevices.FormattingEnabled = true;
            this.listDevices.Location = new System.Drawing.Point(12, 68);
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(442, 264);
            this.listDevices.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "New Device:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "IP Address";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(466, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnEmail,
            this.mbtnLoad,
            this.mbtnSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mbtnEmail
            // 
            this.mbtnEmail.Name = "mbtnEmail";
            this.mbtnEmail.Size = new System.Drawing.Size(180, 22);
            this.mbtnEmail.Text = "Email Settings";
            this.mbtnEmail.Click += new System.EventHandler(this.mbtnEmail_Click);
            // 
            // mbtnLoad
            // 
            this.mbtnLoad.Name = "mbtnLoad";
            this.mbtnLoad.Size = new System.Drawing.Size(180, 22);
            this.mbtnLoad.Text = "Load Settings";
            this.mbtnLoad.Click += new System.EventHandler(this.mbtnLoad_Click);
            // 
            // mbtnSave
            // 
            this.mbtnSave.Name = "mbtnSave";
            this.mbtnSave.Size = new System.Drawing.Size(180, 22);
            this.mbtnSave.Text = "Save Settings";
            this.mbtnSave.Click += new System.EventHandler(this.mbtnSave_Click);
            // 
            // btnRemoveDevice
            // 
            this.btnRemoveDevice.Location = new System.Drawing.Point(12, 338);
            this.btnRemoveDevice.Name = "btnRemoveDevice";
            this.btnRemoveDevice.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveDevice.TabIndex = 12;
            this.btnRemoveDevice.Text = "Remove";
            this.btnRemoveDevice.UseVisualStyleBackColor = true;
            this.btnRemoveDevice.Click += new System.EventHandler(this.btnRemoveDevice_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // FormDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 453);
            this.Controls.Add(this.btnRemoveDevice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listDevices);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormDisplay";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormDisplay_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbtnEmail;
        private System.Windows.Forms.ToolStripMenuItem mbtnLoad;
        private System.Windows.Forms.ToolStripMenuItem mbtnSave;
        private System.Windows.Forms.Button btnRemoveDevice;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

