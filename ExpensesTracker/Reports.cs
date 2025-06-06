﻿using ExpensesTracker.RepositoryPattern.Interfaces;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ExpensesTracker
{
    public partial class Reports : Form
    {
        private readonly IExpenseRepository _expenseRepository;

        public Reports(IExpenseRepository expenseRepository)
        {
            InitializeComponent();
            _expenseRepository = expenseRepository;
            InitializeReportData();
        }

        private void InitializeReportData()
        {
            string username = Login.User ?? string.Empty;
            MaxLbl.Text = _expenseRepository.GetMaxExpense(username) + " lei";
            MinLbl.Text = _expenseRepository.GetMinExpense(username) + " lei";
            TotalLbl.Text = _expenseRepository.GetTotalExpense(username) + " lei";
            HighestLbl.Text = _expenseRepository.GetBestCategory();
            LowestLbl.Text = _expenseRepository.GetWorstCategory();
            AvgLbl.Text = _expenseRepository.GetAverageExpense(username) + " lei";
        }

        private void CatCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTotalExpenseByCategory();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetTotalExpenseByCategory()
        {
            if (CatCB.SelectedItem is string selectedCategory)
            {
                try
                {
                    string username = Login.User ?? string.Empty;
                    string totalExpenseByCategory = Convert.ToString(_expenseRepository.GetTotalExpenseByCategory(username, selectedCategory));
                    TotByCatLbl.Text = totalExpenseByCategory + " lei";
                    TotByCatLbl.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while retrieving total expense for category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                TotByCatLbl.Text = "Nicio categorie selectată";
                TotByCatLbl.Visible = true;
            }
        }


        private void GetBestCategory()
        {
            string bestCategory = _expenseRepository.GetBestCategory();
            HighestLbl.Text = bestCategory;
        }

        private void GetWorstCategory()
        {
            string worstCategory = _expenseRepository.GetWorstCategory();
            LowestLbl.Text = worstCategory;
        }
        private void GetTotalExpense()
        {
            string bestCategory = Convert.ToString(_expenseRepository.GetTotalExpense(Login.User));
            TotalLbl.Text = bestCategory;
        }

        private void GetAverageExpense()
        {
            string averageCategory = Convert.ToString(_expenseRepository.GetAverageExpense(Login.User));
            AvgLbl.Text = averageCategory;
        }
        private void GetMaxExpense()
        {
            string maxCategory = Convert.ToString(_expenseRepository.GetMaxExpense(Login.User));
            AvgLbl.Text = maxCategory;
        }
        private void GetMinExpense()
        {
            string minCategory = Convert.ToString(_expenseRepository.GetMinExpense(Login.User));
            AvgLbl.Text = minCategory;
        }

        private void TotByCatLbl_Click(object sender, EventArgs e)
        {

        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }
    }
}
