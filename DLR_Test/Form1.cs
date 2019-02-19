using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
namespace DLR_Test
{
	public partial class Form1 : Form
	{
		private static PowerShell powershell;
		
		public void WriteText(string text)
		{
			textBox1.Text += text + "\r\n";
			textBox1.SelectionStart = textBox1.Text.Length;
			textBox1.ScrollToCaret();

		}
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			WriteText("Text Box Initialized");
			AppState.Mine = "YO";
			var me = new AppState();
			InitialSessionState state = InitialSessionState.CreateDefault();
			SessionStateVariableEntry Entry1 = new SessionStateVariableEntry("MyVar",me,"description" );
			state.Variables.Add(Entry1);
			powershell = PowerShell.Create(state);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var script = textBox2.Text.ToString();
			powershell.AddScript(script);
			WriteText("PS> " + script);
			foreach (dynamic item in powershell.Invoke().ToList())
			{
				WriteText(item.ToString());
			}
			
		}
	}
	public class AppState
	{
		private static string mine;
		public static string Mine
		{
			get
			{
				return mine;
			}
			set
			{
				mine = value;
			}
		}

	}
}
