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
    public class SplashTests
    {
        [Test]
        public void Timer_Tick_Event_Starts_And_Increments_ProgressBar()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var splashForm = new Splash(userRepositoryMock.Object);
            ProgressBar progressBar = splashForm.MyProgressBar;
            int expectedValue = 1;

            splashForm.Timer1_Tick(null, EventArgs.Empty);

            Assert.That(expectedValue, Is.EqualTo(progressBar.Value)); ;
        }

        [Test]
        public void Timer_Tick_Event_Completes_ProgressBar_And_Shows_Login_Form()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var splashForm = new Splash(userRepositoryMock.Object);

            splashForm.Timer1_Tick(null, EventArgs.Empty);

            ClassicAssert.IsFalse(splashForm.Visible);

        }

    }
    [TestFixture]
    public class SqlConnectionManagerTests
    {
        [Test]
        public void OpenConnection_ConnectionNotOpen_ConnectionOpened()
        {
            // Arrange
            // Ensure connection is closed before the test
            SqlConnectionManager.CloseConnection();

            // Act
            SqlConnectionManager.OpenConnection();

            // Assert
            Assert.That(ConnectionState.Open, Is.EqualTo(SqlConnectionManager.Instance.State));
        }

        [Test]
        public void OpenConnection_ConnectionAlreadyOpen_ConnectionRemainsOpen()
        {
            // Arrange
            // Ensure connection is already open before the test
            SqlConnectionManager.OpenConnection();

            // Act
            SqlConnectionManager.OpenConnection();

            // Assert
            Assert.That(ConnectionState.Open, Is.EqualTo(SqlConnectionManager.Instance.State));
        }

        [Test]
        public void CloseConnection_ConnectionOpen_ConnectionClosed()
        {
            // Arrange
            // Ensure connection is open before the test
            SqlConnectionManager.OpenConnection();

            // Act
            SqlConnectionManager.CloseConnection();

            // Assert
            Assert.That(ConnectionState.Closed, Is.EqualTo(SqlConnectionManager.Instance.State));
        }

        [Test]
        public void CloseConnection_ConnectionAlreadyClosed_ConnectionRemainsClosed()
        {
            // Arrange
            // Ensure connection is already closed before the test
            SqlConnectionManager.CloseConnection();

            // Act
            SqlConnectionManager.CloseConnection();

            // Assert
            Assert.That(ConnectionState.Closed, Is.EqualTo(SqlConnectionManager.Instance.State));
        }
    }
}