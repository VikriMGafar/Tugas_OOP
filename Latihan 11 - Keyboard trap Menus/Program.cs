using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_11___Keyboard_trap_Menus
{
    
    internal static class Program
    {
        public static FormUtama fu;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fu = new FormUtama();
            Application.Run(fu);
        }
    }
}
