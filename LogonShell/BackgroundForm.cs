using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogonShell
{
	public partial class BackgroundForm : Form
	{
		LogOnForm f1;

		public BackgroundForm()
		{
			InitializeComponent();
			Rectangle screen = Screen.PrimaryScreen.Bounds;
			Size = screen.Size;
			f1 = new LogOnForm();
			Shown += BackgroundForm_Shown;
		}

		private void BackgroundForm_Shown(object sender, EventArgs e)
		{
			f1.Show();
		}

		private void BackgroundForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				e.Cancel = true;
		}

		private void BackgroundForm_Activated(object sender, EventArgs e)
		{
			f1.Activate();
		}
	}
}
