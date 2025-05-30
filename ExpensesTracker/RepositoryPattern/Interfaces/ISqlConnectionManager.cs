using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.RepositoryPattern.Interfaces
{
    public interface ISqlConnectionManager
    {
        ConnectionState State { get; }
        SqlConnection Instance { get; }
        SqlConnection GetConnection();
        void OpenConnection();
        void CloseConnection();

    }
}
