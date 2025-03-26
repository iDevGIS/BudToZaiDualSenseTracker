using System;
using System.Threading;
using System.Windows.Forms;

namespace BudToZaiDualSenseTracker
{
    internal static class Program
    {
        private static Mutex mutex = new Mutex(true, "{B1A2D3C4-E5F6-7890-1234-56789ABCDEF0}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FBudToZai mainForm = new FBudToZai();

                if (args.Length > 0)
                {
                    if (args[0] == "/toggle")
                    {
                        return;
                    }
                    else if (args[0] == "/exit")
                    {
                        return;
                    }
                }

                Application.Run(mainForm);
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("You Can call function by Click System Tray Menu.");
            }
        }
    }
}
