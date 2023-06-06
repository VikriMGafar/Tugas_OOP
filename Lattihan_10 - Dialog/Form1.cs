﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lattihan_10___Dialog
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void btnFolder_Click(object sender, EventArgs e)
		{
			DialogResult dr = FolderDialog.ShowDialog();
			if (dr == DialogResult.OK)
			{
				//MessageBox.Show(dr.ToString());
				MessageBox.Show(FolderDialog.SelectedPath);

			}
			else
			{
				MessageBox.Show("Anda membatalkan untuk memilih folder.","Pembatalan",
					MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			}
		}
	}
}
