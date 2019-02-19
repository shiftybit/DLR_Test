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

namespace DLR_Test
{
	public static class AppState
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
			
			powershell = PowerShell.Create();
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
}
