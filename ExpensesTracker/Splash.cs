using ExpensesTracker.Factory;
using ExpensesTracker.Factory.Interface;
using ExpensesTracker.Repositories;
using ExpensesTracker.RepositoryPattern.Interfaces;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ExpensesTracker
{
    public partial class Splash : Form
    {
        private const int TimerInterval = 100; // Timer interval in milliseconds
        private const int ProgressBarStep = 1; // Progress bar step value
        public ProgressBar MyProgressBar { get; }

        private readonly AbstractRepositoryFactory _repositoryFactory;

        public Splash(AbstractRepositoryFactory repositoryFactory)
        {
            InitializeComponent();
            _repositoryFactory = repositoryFactory;
            MyProgressBar = MyProgress;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = TimerInterval;
            timer.Tick += Timer1_Tick;
            timer.Start();
        }

        public void Timer1_Tick(object sender, EventArgs e)
        {
            if (MyProgress.Value < MyProgress.Maximum)
            {
                MyProgress.Value += ProgressBarStep;
                PercentageLbl.Text = MyProgress.Value + "%";
            }

            if (MyProgress.Value >= 100)
            {
                ((Timer)sender).Stop();
                ShowLoginForm();
            }
        }

        private void ShowLoginForm()
        {
            SqlConnection sqlConnection = SqlConnectionManager.Instance;
            IUserRepository userRepository = _repositoryFactory.CreateUserRepository();
            Login login = new Login(userRepository);
            login.Show();
            this.Hide();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            InitializeTimer();
        }
    }
}
