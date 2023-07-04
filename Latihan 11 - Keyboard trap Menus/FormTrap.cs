using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_11___Keyboard_trap_Menus
{
    public partial class FormTrap : Form
    {
        public FormTrap()
        {
            InitializeComponent();
        }

        private void FormTrap_Load(object sender, EventArgs e)
        {
            FormUtama fu = Program.fu;
            fu.tssStatus.Text = "anda mengaktifkan Form Trap";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FormTrap_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
