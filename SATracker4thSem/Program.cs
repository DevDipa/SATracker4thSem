using System;
using System.Windows.Forms;

namespace SATracker4thSem
{
    internal static class Program
    {
        [STAThread]

        //Entry point of the application
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
