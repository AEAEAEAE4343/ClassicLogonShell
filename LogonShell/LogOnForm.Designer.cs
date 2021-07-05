
namespace LogonShell
{
	partial class LogOnForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogOnForm));
			this.pictureBoxBanner = new System.Windows.Forms.PictureBox();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonOptions = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.labelUsername = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.axMsRdpClient9NotSafeForScripting1 = new AxMSTSCLib.AxMsRdpClient9NotSafeForScripting();
			this.timerDisconnect = new System.Windows.Forms.Timer(this.components);
			this.timerLogin = new System.Windows.Forms.Timer(this.components);
			this.buttonShutdown = new System.Windows.Forms.Button();
			this.buttonDummy = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient9NotSafeForScripting1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxBanner
			// 
			this.pictureBoxBanner.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBanner.Image")));
			this.pictureBoxBanner.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxBanner.Name = "pictureBoxBanner";
			this.pictureBoxBanner.Size = new System.Drawing.Size(411, 93);
			this.pictureBoxBanner.TabIndex = 0;
			this.pictureBoxBanner.TabStop = false;
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(84, 108);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(243, 20);
			this.textBoxUsername.TabIndex = 1;
			this.textBoxUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(84, 135);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(243, 20);
			this.textBoxPassword.TabIndex = 2;
			this.textBoxPassword.UseSystemPasswordChar = true;
			this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// buttonOptions
			// 
			this.buttonOptions.Location = new System.Drawing.Point(326, 171);
			this.buttonOptions.Name = "buttonOptions";
			this.buttonOptions.Size = new System.Drawing.Size(75, 23);
			this.buttonOptions.TabIndex = 5;
			this.buttonOptions.Text = "Options > >";
			this.buttonOptions.UseVisualStyleBackColor = true;
			this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Location = new System.Drawing.Point(245, 171);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(164, 171);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// labelUsername
			// 
			this.labelUsername.AutoSize = true;
			this.labelUsername.Location = new System.Drawing.Point(12, 111);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(61, 13);
			this.labelUsername.TabIndex = 6;
			this.labelUsername.Text = "User name:";
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(12, 138);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(56, 13);
			this.labelPassword.TabIndex = 7;
			this.labelPassword.Text = "Password:";
			// 
			// axMsRdpClient9NotSafeForScripting1
			// 
			this.axMsRdpClient9NotSafeForScripting1.Enabled = true;
			this.axMsRdpClient9NotSafeForScripting1.Location = new System.Drawing.Point(12, 216);
			this.axMsRdpClient9NotSafeForScripting1.Name = "axMsRdpClient9NotSafeForScripting1";
			this.axMsRdpClient9NotSafeForScripting1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMsRdpClient9NotSafeForScripting1.OcxState")));
			this.axMsRdpClient9NotSafeForScripting1.Size = new System.Drawing.Size(389, 306);
			this.axMsRdpClient9NotSafeForScripting1.TabIndex = 8;
			this.axMsRdpClient9NotSafeForScripting1.OnLoginComplete += new System.EventHandler(this.axMsRdpClient9NotSafeForScripting1_OnLoginComplete);
			this.axMsRdpClient9NotSafeForScripting1.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(this.axMsRdpClient9NotSafeForScripting1_OnDisconnected);
			// 
			// timerDisconnect
			// 
			this.timerDisconnect.Interval = 3000;
			this.timerDisconnect.Tick += new System.EventHandler(this.timerDisconnect_Tick);
			// 
			// timerLogin
			// 
			this.timerLogin.Interval = 250;
			this.timerLogin.Tick += new System.EventHandler(this.timerLogin_Tick);
			// 
			// buttonShutdown
			// 
			this.buttonShutdown.Location = new System.Drawing.Point(245, 171);
			this.buttonShutdown.Name = "buttonShutdown";
			this.buttonShutdown.Size = new System.Drawing.Size(75, 23);
			this.buttonShutdown.TabIndex = 9;
			this.buttonShutdown.Text = "Shutdown...";
			this.buttonShutdown.UseVisualStyleBackColor = true;
			this.buttonShutdown.Visible = false;
			this.buttonShutdown.Click += new System.EventHandler(this.buttonShutdown_Click);
			// 
			// buttonDummy
			// 
			this.buttonDummy.Enabled = false;
			this.buttonDummy.Location = new System.Drawing.Point(83, 171);
			this.buttonDummy.Name = "buttonDummy";
			this.buttonDummy.Size = new System.Drawing.Size(75, 23);
			this.buttonDummy.TabIndex = 10;
			this.buttonDummy.Text = "Dummy";
			this.buttonDummy.UseVisualStyleBackColor = true;
			this.buttonDummy.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label1.Location = new System.Drawing.Point(0, 192);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "v1.1.0 (C) Leet";
			// 
			// LogOnForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(409, 205);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonDummy);
			this.Controls.Add(this.buttonShutdown);
			this.Controls.Add(this.axMsRdpClient9NotSafeForScripting1);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labelUsername);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOptions);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxUsername);
			this.Controls.Add(this.pictureBoxBanner);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LogOnForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Log On to Windows";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient9NotSafeForScripting1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxBanner;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button buttonOptions;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelUsername;
		private System.Windows.Forms.Label labelPassword;
		private AxMSTSCLib.AxMsRdpClient9NotSafeForScripting axMsRdpClient9NotSafeForScripting1;
		private System.Windows.Forms.Timer timerDisconnect;
		private System.Windows.Forms.Timer timerLogin;
		private System.Windows.Forms.Button buttonShutdown;
		private System.Windows.Forms.Button buttonDummy;
		private System.Windows.Forms.Label label1;
	}
}

