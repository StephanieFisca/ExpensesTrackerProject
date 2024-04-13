using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesTracker.RepositoryPattern.Interfaces;

namespace ExpensesTracker.Factory.Interface
{
    //Define an abstract class for the repository factory
    public abstract class AbstractRepositoryFactory
    {
        public abstract IExpenseRepository CreateExpenseRepository();
        public abstract IAdminAccessRepository CreateAdminAccessRepository();
        public abstract IUserRepository CreateUserRepository();
    }

}
