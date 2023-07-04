using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan11_SplitContainer
{
	static class Program
	{
		public static FormUtama formUtama;
		public static FormFoto[] ffs;
		public static int ffIndex = 0;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			ffs = new FormFoto[10];
			formUtama = new FormUtama();
			Application.Run(formUtama);
		}
	}
}
