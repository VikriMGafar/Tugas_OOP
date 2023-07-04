using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan11_SplitContainer
{
	public partial class FormDaftar : Form
	{
		public FormDaftar()
		{
			InitializeComponent();
		}

		private void btnOpenFolder_Click(object sender, EventArgs e)
		{
			DialogResult dr = folderBrowserDialog1.ShowDialog();
			if (dr == DialogResult.OK)
			{
				string folder = folderBrowserDialog1.SelectedPath + "\\";
				listBox1.Tag = folder;
				MessageBox.Show("Anda Pilih OK");
				string[] fns = Directory.GetFiles(folder, "*.jp*");
				for (int i = 0; i < fns.Length; i++)
					fns[i] = fns[i].Replace(folder, "");
				listBox1.Items.Clear();
				listBox1.Items.AddRange(fns);
			}
		}

		private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string fn = (string)listBox1.SelectedItem;
			
			FormFoto ff = new FormFoto();
			ff.tbxNamaFile.Text = fn;
			
			ff.MdiParent = Program.formUtama;
			fn = listBox1.Tag + fn;
			ff.pictureBox1.Image = Image.FromFile(fn);
			ff.Show();
			if (Program.ffIndex > 1)
			{
				FormFoto fLast = Program.ffs[Program.ffIndex - 1];
				ff.Left = fLast.Left + fLast.Width;
				ff.Top = 0;
			}
		}
	}
}
