using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_diary
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Properties.Settings.Default.Login = "Admin";//TODO

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SQL.OpenConnection();
            Holidays.Load();
            Schedule.Load();
            DefaultTasks.Load();
            ThemeManager.Load();

            Main mainForm = new Main();

            Application.Run(mainForm);
        }
    }
}
