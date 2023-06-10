using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHPCsharp_baglanti
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formcontroller controller = new formcontroller();
            controller.StartForm(connectionservice.IsConnected()).Show();
            Application.Run();
        }
    }
}
