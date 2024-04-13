using ExpensesTracker.Factory.Interface;
using ExpensesTracker.Repositories;
using ExpensesTracker.RepositoryPattern.Interfaces;
using System.Data.SqlClient;

namespace ExpensesTracker.Factory
{
    public class RepositoryFactory : AbstractRepositoryFactory
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IUserRepository _userRepository;

        public RepositoryFactory(IUserRepository userRepository)
        {
            // Access the SqlConnection instance from SqlConnectionManager
            _sqlConnection = SqlConnectionManager.Instance;
            _userRepository = userRepository;
        }

        public override IExpenseRepository CreateExpenseRepository()
        {
            return new ExpenseRepository(_userRepository);
        }

        public override IUserRepository CreateUserRepository()
        {
            return new UserRepository();
        }

        public override IAdminAccessRepository CreateAdminAccessRepository()
        {
            return new AdminAccessRepository();
        }
    }
}
