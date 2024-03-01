using HospitalSystemManagement.Model;
using HospitalSystemManagement.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Release Stage
            UserLogic users = new UserLogic();
            if(users.getAllUsers().Count()==0)
            {
               users.AddUser("123","123");
                users.AddUser("admin", "123");
            }
            

              Database.SetInitializer<DataContext>(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
