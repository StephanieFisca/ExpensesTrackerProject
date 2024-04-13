using ExpensesTracker.Factory.Interface;
using ExpensesTracker.Factory;
using ExpensesTracker.Repositories;
using ExpensesTracker.RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpensesTracker
{
    public partial class MainMenu : Form
    {
        private readonly IUserRepository _userRepository;

        public MainMenu(IUserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
            DayLbl.Text = "Day: " + DateTime.Today.Day.ToString();
            MonthLbl.Text = "Month: " + DateTime.Today.Month.ToString();
            YearLbl.Text = "Year: " + DateTime.Today.Year.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AbstractRepositoryFactory factory = new RepositoryFactory(_userRepository);
            IExpenseRepository expenseRepository = factory.CreateExpenseRepository();
            Expenses expenses = new Expenses(expenseRepository);
            expenses.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AbstractRepositoryFactory factory = new RepositoryFactory(_userRepository);
            IExpenseRepository expenseRepository = factory.CreateExpenseRepository();
            ViewExpenses viewExpenses = new ViewExpenses(expenseRepository);
            viewExpenses.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login login = new Login(_userRepository);
            login.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AbstractRepositoryFactory factory = new RepositoryFactory(_userRepository);
            IExpenseRepository expenseRepository = factory.CreateExpenseRepository();
            Reports reports = new Reports(expenseRepository);
            reports.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
