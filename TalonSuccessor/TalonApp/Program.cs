using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TalonApp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmInit());
        }

        public static void DoSetupSetup()
        {
            Form g_setup = new frmSetup();
            g_setup.ShowDialog();
        }

        public static void DoAboutSetup()
        {
            Form g_about = new frmAbout();
            g_about.ShowDialog();
        }

        public static void DoMonitorSetup()
        {
            Form g_monitor = new frmMonitor();
            g_monitor.ShowDialog();
        }
    }
}