using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan11_SplitContainer
{
	public partial class FormFoto : Form
	{
		public FormFoto()
		{
			InitializeComponent();
		}

		private void FormFoto_Load(object sender, EventArgs e)
		{
			if (Program.ffIndex >= 9) return;
			Program.ffs[Program.ffIndex] = this;
			Program.ffIndex++;
		}
	}
}
