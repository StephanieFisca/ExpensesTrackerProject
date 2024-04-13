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
    public partial class AdminExpenses : Form
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUserRepository _userRepository;

        public AdminExpenses(IExpenseRepository expenseRepository, IUserRepository userRepository)
        {
            InitializeComponent();
            _expenseRepository = expenseRepository;
            _userRepository = userRepository;
            ShowExpenses();
        }

        private void ShowExpenses()
        {
            DataTable expenses = _expenseRepository.GetAllExpenses();
            ExpensesDGV.DataSource = expenses;
        }

        private void FilterByCat()
        {
            string selectedCategory = ExpCategoryLbl.SelectedItem?.ToString();
            if (selectedCategory != null)
            {
                DataTable expenses = _expenseRepository.GetExpensesByCategory(selectedCategory);
                ExpensesDGV.DataSource = expenses;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AbstractRepositoryFactory factory = new RepositoryFactory(_userRepository);
            IUserRepository userRepository = factory.CreateUserRepository();
            Users users = new Users(_userRepository);
            users.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ShowExpenses();
        }

        private void ExpCategoryLbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterByCat();
        }
    }
}
