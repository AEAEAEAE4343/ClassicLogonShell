using MSTSCLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogonShell
{
	public partial class LogOnForm : Form
	{
		#region P/Invoke
		public enum WTS_CONNECTSTATE_CLASS
		{
			WTSActive,
			WTSConnected,
			WTSConnectQuery,
			WTSShadow,
			WTSDisconnected,
			WTSIdle,
			WTSListen,
			WTSReset,
			WTSDown,
			WTSInit
		}

		public enum WTS_INFO_CLASS
		{
			WTSInitialProgram,
			WTSApplicationName,
			WTSWorkingDirectory,
			WTSOEMId,
			WTSSessionId,
			WTSUserName,
			WTSWinStationName,
			WTSDomainName,
			WTSConnectState,
			WTSClientBuildNumber,
			WTSClientName,
			WTSClientDirectory,
			WTSClientProductId,
			WTSClientHardwareId,
			WTSClientAddress,
			WTSClientDisplay,
			WTSClientProtocolType,
			WTSIdleTime,
			WTSLogonTime,
			WTSIncomingBytes,
			WTSOutgoingBytes,
			WTSIncomingFrames,
			WTSOutgoingFrames,
			WTSClientInfo,
			WTSSessionInfo,
			WTSSessionInfoEx,
			WTSConfigInfo,
			WTSValidationInfo,
			WTSSessionAddressV4,
			WTSIsRemoteSession
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct WTS_SESSION_INFO
		{
			public Int32 SessionID;

			[MarshalAs(UnmanagedType.LPStr)]
			public String pWinStationName;

			public WTS_CONNECTSTATE_CLASS State;
		}

		[DllImport("wtsapi32.dll", SetLastError = true)]
		static extern IntPtr WTSOpenServer(string pServerName);
		[DllImport("wtsapi32.dll", SetLastError = true)]
		static extern int WTSEnumerateSessions(IntPtr hServer, int Reserved, int Version, ref IntPtr ppSessionInfo, ref int pCount);
		[DllImport("wtsapi32.dll", SetLastError = true)]
	    static extern bool WTSQuerySessionInformationW(IntPtr hServer, int sessionId, WTS_INFO_CLASS wtsInfoClass, out IntPtr ppBuffer, out int pBytesReturned);
		[DllImport("wtsapi32.dll", SetLastError = true)]
		static extern void WTSFreeMemory(IntPtr value);
		[DllImport("wtsapi32.dll", SetLastError = true)]
		static extern int WTSConnectSession(int LogonId, int TargetLogonId, string pPassword, bool bWait);
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern int WTSGetActiveConsoleSessionId();
		[DllImport("uxtheme.dll", SetLastError = true)]
		static extern int SetWindowTheme(IntPtr window, string app, string theme);
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool ExitWindowsEx(uint uFlags, uint dwReason);[DllImport("advapi32.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool LogonUser([MarshalAs(UnmanagedType.LPStr)] string pszUserName, [MarshalAs(UnmanagedType.LPStr)] string pszDomain, [MarshalAs(UnmanagedType.LPStr)] string pszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool PaintDesktop(IntPtr hdc);

		readonly IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
		#endregion

		bool loggedIn = false;
		bool optionsShown = false;
		int retryCount = 0;

		public LogOnForm()
		{
			InitializeComponent();
			Load += Form1_Load;
		}

		#region RDP Events
		private void axMsRdpClient9NotSafeForScripting1_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
		{
			if (loggedIn)
			{
				timerDisconnect.Enabled = true;
			}
			else
			{
				switch(e.discReason)
				{
					case 2055:
						MessageBox.Show("Logon failed");
						break;
					default:
						MessageBox.Show(e.discReason.ToString());
						break;
				}
			}
		}

		private void axMsRdpClient9NotSafeForScripting1_OnLoginComplete(object sender, EventArgs e)
		{
			loggedIn = true;
			timerLogin.Enabled = true;
		}
		#endregion

		#region Timers
		private void timerDisconnect_Tick(object sender, EventArgs e)
		{
			// Check if we haven't already ran 4 times (12 seconds)
			if (retryCount != 3)
			{
				retryCount++;

				// Retrieve all Windows Terminal Services (aka RDP) Sessions active
				List<string> ret = new List<string>();
				IntPtr ppSessionInfo = IntPtr.Zero;
				IntPtr ppBuffer = IntPtr.Zero;

				int count = 0;
				int retval = WTSEnumerateSessions(WTS_CURRENT_SERVER_HANDLE, 0, 1, ref ppSessionInfo, ref count);
				int dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));

				WTS_SESSION_INFO session = new WTS_SESSION_INFO();
				session.SessionID = -1;

				// Loop over all of them and check if any matches the username but is disconencted
				if (retval != 0)
				{
					for (int i = 0; i < count; i++)
					{
						WTS_SESSION_INFO si = (WTS_SESSION_INFO)Marshal.PtrToStructure(ppSessionInfo, typeof(WTS_SESSION_INFO));
						ppSessionInfo += dataSize;

						WTSQuerySessionInformationW(WTS_CURRENT_SERVER_HANDLE, si.SessionID, WTS_INFO_CLASS.WTSUserName, out ppBuffer, out int stringLength);
						string username = Marshal.PtrToStringAuto(ppBuffer);
						//WTSFreeMemory(ppBuffer);

						if (username == textBoxUsername.Text)
							if (si.State == WTS_CONNECTSTATE_CLASS.WTSDisconnected)
								session = si;

						ret.Add(si.SessionID + " " + username + " " + si.State + " " + si.pWinStationName);
					}

					Console.WriteLine(ret.Aggregate((a, b) => $"{a}\n{b}"));
				}
				// If none match the criteria, retry in 3 seconds
				if (session.SessionID == -1)
				{
					return;
				}
				// Otherwise tell WTS to redirect the current session to the new user session and log off from the login account
				else
				{
					int retVal = WTSConnectSession(session.SessionID, WTSGetActiveConsoleSessionId(), textBoxPassword.Text, true);
					if (retVal == 0)
						throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());

					timerDisconnect.Enabled = false;
					ExitWindowsEx(4, 0);
					Close();
					return;
				}
			}
			else
			{
				retryCount = 0;
				timerDisconnect.Enabled = false;
				MessageBox.Show(this, "Exceeded maximum RDP disconnection time (12 seconds)");
			}
		}

		private void timerLogin_Tick(object sender, EventArgs e)
		{
			// Check if we haven't already ran 10 times (2.5 seconds)
			if (retryCount != 9)
			{
				retryCount++;

				// Retrieve all Windows Terminal Services (aka RDP) Sessions active
				List<string> ret = new List<string>();
				IntPtr ppSessionInfo = IntPtr.Zero;
				IntPtr ppBuffer = IntPtr.Zero;

				int count = 0;
				int retval = WTSEnumerateSessions(WTS_CURRENT_SERVER_HANDLE, 0, 1, ref ppSessionInfo, ref count);
				int dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));

				int sessionId = -1;

				// Loop over all of them and check if any matches the username
				if (retval != 0)
				{
					for (int i = 0; i < count; i++)
					{
						WTS_SESSION_INFO si = (WTS_SESSION_INFO)Marshal.PtrToStructure(ppSessionInfo, typeof(WTS_SESSION_INFO));
						ppSessionInfo += dataSize;

						WTSQuerySessionInformationW(WTS_CURRENT_SERVER_HANDLE, si.SessionID, WTS_INFO_CLASS.WTSUserName, out ppBuffer, out int stringLength);
						string username = Marshal.PtrToStringAuto(ppBuffer);
						//WTSFreeMemory(ppBuffer);

						if (username == textBoxUsername.Text)
							sessionId = si.SessionID;

						ret.Add(si.SessionID + " " + username + " " + si.State + " " + si.pWinStationName);
					}

					Console.WriteLine(ret.Aggregate((a, b) => $"{a}\n{b}"));
					//WTSFreeMemory(ppSessionInfo);
				}
				// If none match the criteria, retry in a quarter of a second
				if (sessionId == -1)
				{
					return;
				}
				// Otherwise tell RDP to disconnect so that the session becomes free for a new connection
				else
				{
					timerLogin.Enabled = false;
					System.Threading.Thread.Sleep(1000);
					axMsRdpClient9NotSafeForScripting1.Disconnect();
				}
			}
			else
			{
				retryCount = 0;
				timerLogin.Enabled = false;
				MessageBox.Show(this, "Exceeded maximum RDP login time (2.5 seconds)");
			}
		}
		#endregion

		#region Form Events
		private void Form1_Load(object sender, EventArgs e)
		{
			SetWindowTheme(Handle, " ", " ");
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			Location = new Point(Location.X, 166);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				e.Cancel = true;
		}
		#endregion

		#region Control Events
		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonOK.PerformClick();
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			IntPtr user = new IntPtr();
			bool succes = LogonUser(textBoxUsername.Text, Environment.MachineName, textBoxPassword.Text, 3, 0, ref user);
			if (!succes)
			{
				MessageBox.Show(Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()).Message);
				return;
			}

			axMsRdpClient9NotSafeForScripting1.Size = Screen.PrimaryScreen.Bounds.Size;
			axMsRdpClient9NotSafeForScripting1.Server = "127.0.0.2";
			axMsRdpClient9NotSafeForScripting1.Domain = Environment.MachineName;
			axMsRdpClient9NotSafeForScripting1.UserName = textBoxUsername.Text;
			axMsRdpClient9NotSafeForScripting1.AdvancedSettings9.ClearTextPassword = textBoxPassword.Text;
			axMsRdpClient9NotSafeForScripting1.AdvancedSettings9.EnableCredSspSupport = true;
			IMsRdpClientNonScriptable5 a = (IMsRdpClientNonScriptable5)axMsRdpClient9NotSafeForScripting1.GetOcx();
			a.AllowPromptingForCredentials = false;
			axMsRdpClient9NotSafeForScripting1.Connect();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void buttonOptions_Click(object sender, EventArgs e)
		{
			optionsShown = !optionsShown;
			buttonShutdown.Visible = optionsShown;
			if (optionsShown)
			{
				buttonOptions.Text = "Options < <";
				buttonCancel.Location = buttonOK.Location;
				buttonOK.Location = buttonDummy.Location;
			}
			else
			{
				buttonOptions.Text = "Options > >";
				buttonOK.Location = buttonCancel.Location;
				buttonCancel.Location = buttonShutdown.Location;
			}
		}

		private void buttonShutdown_Click(object sender, EventArgs e)
		{
			new ShutDownForm().ShowDialog();
		}
		#endregion
	}
}
