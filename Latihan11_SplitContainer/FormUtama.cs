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
	public partial class FormUtama : Form
	{
		public FormUtama()
		{
			InitializeComponent();
		}

		private void tampilkanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormFoto ff = new FormFoto();
			ff.Show();
			ff.MdiParent = this;
		}

		private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormDaftar fd = new FormDaftar();
			fd.MdiParent = this;
			fd.Top = 0;
			fd.Left = 0;
			fd.Height = this.Height - 95;
			fd.Width = 200;
			fd.Show();
		}
	}
}
