using System;
using System.Windows.Forms;

namespace UOMAssignmentDiveSpirit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashingScreen()); //This was added to call the SplashScreen
            Application.Run(new LoginForm());
        }
    }
}
