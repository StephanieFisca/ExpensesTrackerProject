using ExpensesTracker.Factory.Interface;
using ExpensesTracker.Factory;
using ExpensesTracker.Repositories;
using ExpensesTracker.RepositoryPattern.Interfaces;
using System.Data.SqlClient;

namespace ExpensesTracker
{
    public partial class AddAdmin : Form
    {
        private readonly IAdminAccessRepository _adminAccessRepository;
        private readonly IUserRepository _userRepository;

        public AddAdmin(IAdminAccessRepository adminAccessRepository, IUserRepository userRepository)
        {
            InitializeComponent();
            _adminAccessRepository = adminAccessRepository;
            _userRepository = userRepository;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string username = UNameTxt.Text;
            string password = UPasswordTxt.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password are required.");
                return;
            }

            // Add the new admin to the database
            _adminAccessRepository.AddAdmin(username, password);
            MessageBox.Show("Admin added successfully.");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AbstractRepositoryFactory factory = new RepositoryFactory(_userRepository);
            IUserRepository userRepository = factory.CreateUserRepository();
            Users users = new Users(userRepository);
            users.Show();
            this.Hide();
        }
    }
}
