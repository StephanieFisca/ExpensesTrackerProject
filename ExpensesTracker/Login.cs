using ExpensesTracker.Factory.Interface;
using ExpensesTracker.Factory;
using ExpensesTracker.Repositories;
using ExpensesTracker.RepositoryPattern.Interfaces;
using System;
using System.Windows.Forms;

namespace ExpensesTracker
{
    public partial class Login : Form
    {
        private readonly IUserRepository _userRepository;
        public static string User;

        public Login(IUserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UNameTxt.Text;
            string password = UPasswordTxt.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password are required.");
                return;
            }

            bool isValidUser = _userRepository.ValidateUserCredentials(username, password);

            if (isValidUser)
            {
                // Use the repository factory to create instances of repositories
                MainMenu mainMenu = new MainMenu(_userRepository);
                Login.User = username;
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username and Password");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Use the repository factory to create instances of repositories
            AbstractRepositoryFactory factory = new RepositoryFactory(_userRepository);
            IAdminAccessRepository adminAccessRepository = factory.CreateAdminAccessRepository();
            AdminLogin adminLogin = new AdminLogin(adminAccessRepository, _userRepository);
            adminLogin.Show();
            this.Hide();
        }
    }
}
