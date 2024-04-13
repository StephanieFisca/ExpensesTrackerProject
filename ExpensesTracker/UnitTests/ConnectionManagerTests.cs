using NUnit.Framework;
using Moq;
using ExpensesTracker.Repositories;
using System.Data.SqlClient;
using ExpensesTracker.RepositoryPattern.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using NUnit.Framework.Legacy;

namespace ExpensesTracker.Tests
{
    [TestFixture]
    public class SqlConnectionManagerTests
    {
        [Test]
        public void OpenConnection_ConnectionNotOpen_ConnectionOpened()
        {
            // Ensure connection is closed before the test
            SqlConnectionManager.CloseConnection();

            //Call function
            SqlConnectionManager.OpenConnection();

            // Assert
            Assert.That(ConnectionState.Open, Is.EqualTo(SqlConnectionManager.Instance.State));
        }

        [Test]
        public void OpenConnection_ConnectionAlreadyOpen_ConnectionRemainsOpen()
        {
            // Ensure connection is already open before the test
            SqlConnectionManager.OpenConnection();

            //Call function
            SqlConnectionManager.OpenConnection();

            // Assert
            Assert.That(ConnectionState.Open, Is.EqualTo(SqlConnectionManager.Instance.State));
        }

        [Test]
        public void CloseConnection_ConnectionOpen_ConnectionClosed()
        {
            // Ensure connection is open before the test
            SqlConnectionManager.OpenConnection();

            //Call function
            SqlConnectionManager.CloseConnection();

            // Assert
            Assert.That(ConnectionState.Closed, Is.EqualTo(SqlConnectionManager.Instance.State));
        }

        [Test]
        public void CloseConnection_ConnectionAlreadyClosed_ConnectionRemainsClosed()
        {
            // Ensure connection is already closed before the test
            SqlConnectionManager.CloseConnection();

            //Call function
            SqlConnectionManager.CloseConnection();

            // Assert
            Assert.That(ConnectionState.Closed, Is.EqualTo(SqlConnectionManager.Instance.State));
        }
    }
}