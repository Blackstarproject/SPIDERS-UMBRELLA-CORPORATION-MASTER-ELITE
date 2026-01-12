using SPIDERS_UMBRELLA_CORPORATION.UI;
using System;
using System.Windows.Forms;

namespace SPIDERS_UMBRELLA_CORPORATION
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}