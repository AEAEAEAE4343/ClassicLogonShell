
namespace LogonShell
{
	partial class ShutDownForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShutDownForm));
			this.pictureBoxBanner = new System.Windows.Forms.PictureBox();
			this.pictureBoxComputer = new System.Windows.Forms.PictureBox();
			this.labelWdyw = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxComputer)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxBanner
			// 
			this.pictureBoxBanner.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBanner.Image")));
			this.pictureBoxBanner.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxBanner.Name = "pictureBoxBanner";
			this.pictureBoxBanner.Size = new System.Drawing.Size(411, 77);
			this.pictureBoxBanner.TabIndex = 1;
			this.pictureBoxBanner.TabStop = false;
			// 
			// pictureBoxComputer
			// 
			this.pictureBoxComputer.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxComputer.Image")));
			this.pictureBoxComputer.Location = new System.Drawing.Point(19, 87);
			this.pictureBoxComputer.Name = "pictureBoxComputer";
			this.pictureBoxComputer.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxComputer.TabIndex = 2;
			this.pictureBoxComputer.TabStop = false;
			// 
			// labelWdyw
			// 
			this.labelWdyw.AutoSize = true;
			this.labelWdyw.Location = new System.Drawing.Point(63, 89);
			this.labelWdyw.Name = "labelWdyw";
			this.labelWdyw.Size = new System.Drawing.Size(192, 13);
			this.labelWdyw.TabIndex = 3;
			this.labelWdyw.Text = "What do you want the computer to do?";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Shut down",
            "Restart",
            "Stand by"});
			this.comboBox1.Location = new System.Drawing.Point(66, 109);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(260, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// labelDescription
			// 
			this.labelDescription.Location = new System.Drawing.Point(63, 143);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(263, 35);
			this.labelDescription.TabIndex = 5;
			this.labelDescription.Text = "Text that describes the selected shutdown action";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(243, 209);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(324, 209);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 11;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// ShutDownForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(411, 244);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.labelWdyw);
			this.Controls.Add(this.pictureBoxComputer);
			this.Controls.Add(this.pictureBoxBanner);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ShutDownForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Shut Down Windows";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.ShutDownForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxComputer)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxBanner;
		private System.Windows.Forms.PictureBox pictureBoxComputer;
		private System.Windows.Forms.Label labelWdyw;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
	}
}