using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;
using System.IO;

namespace Latihan14_MSOffice
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		word.Application WordApp = new word.Application();

		private void Form1_Load(object sender, EventArgs e)
		{
			//string fn = @"C:\Users\ACER\Documents\kuliah\05. OOP\Tugas_OOP\Latihan14_MSOffice\OOP_word.docx",
			//fnGuru = @"C:\Users\ACER\Documents\kuliah\05. OOP\Tugas_OOP\Latihan14_MSOffice\DataGuru.txt";

			//string[] gurus = File.ReadAllLines(fnGuru);

			//WordApp.Visible = true;
			//word.Document doc = WordApp.Documents.Open(fn);
		}

		void replaceBookmark(word.Document doc, string bookMarkName, string sdata)
		{
			object oBookMark = bookMarkName;
			if (sdata.Length > 0) doc.Bookmarks.get_Item(ref oBookMark).Range.Text = sdata ;

		}

		private void btnUpdateWord_Click(object sender, EventArgs e)
		{
			string fn = @"C:\Users\ACER\Documents\kuliah\05. OOP\Tugas_OOP\Latihan14_MSOffice\OOP_word.docx",
				fnGuru = @"C:\Users\ACER\Documents\kuliah\05. OOP\Tugas_OOP\Latihan14_MSOffice\DataGuru.txt";

			string[] gurus = File.ReadAllLines(fnGuru);
			string[] cols = gurus[1].Split('\t');

			WordApp.Visible = true;
			word.Document doc = WordApp.Documents.Open(fn);
			replaceBookmark(doc, "nomor_surat", cols[0]);
		}
	}
}
