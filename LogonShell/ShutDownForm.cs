using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogonShell
{
	public partial class ShutDownForm : Form
	{
		[DllImport("uxtheme.dll", SetLastError = true)]
		static extern int SetWindowTheme(IntPtr window, string app, string theme);

		readonly string[] actionDescriptions = 
		{
			@"Ends your session and shuts down Windows so you can safely turn off power.",
			@"Ends your session, shuts down Windows, and starts Windows again.",
			@"Maintains your session, keeping the computer running on low power with data still in memory."
		};

		public ShutDownForm()
		{
			InitializeComponent();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex != -1)
			{
				labelDescription.Text = actionDescriptions[comboBox1.SelectedIndex];
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ShutDownForm_Load(object sender, EventArgs e)
		{
			comboBox1.SelectedIndex = 0;
			SetWindowTheme(Handle, " ", " ");
		}

		[DllImport("user32.dll", SetLastError = true)]
		static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex == 2)
			{
				Application.SetSuspendState(PowerState.Suspend, true, true);
				return;
			}

			uint uFlags;
			if (comboBox1.SelectedIndex == 0)
				uFlags = 1;
			else
				uFlags = 2;

			ExitWindowsEx(uFlags, 0);
		}
	}
}
