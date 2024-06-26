using ExpensesTracker.Factory.Interface;
using ExpensesTracker.Factory;
using ExpensesTracker.Repositories;
using ExpensesTracker.RepositoryPattern.Interfaces;
using System.Data.SqlClient;

namespace ExpensesTracker
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IUserRepository userRepository = new UserRepository();
            AbstractRepositoryFactory abstractRepositoryFactory = new RepositoryFactory(userRepository);
            Application.Run(new Splash(abstractRepositoryFactory));
        }
    }
}