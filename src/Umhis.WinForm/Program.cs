using System;
using System.Windows.Forms;
using Umhis.Forms;

namespace Umhis
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

            using (var backForm = new BackgroundForm())
            {
                backForm.Show();

                using (var login = new LogInDialog())
                {
                    if (login.ShowDialog(backForm) != DialogResult.OK) return;
                }
            }

            //Application.Run(new Form1());
            Application.Run(new MainForm());
        }
    }
}
