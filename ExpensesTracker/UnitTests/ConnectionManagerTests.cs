using NUnit.Framework;
using Moq;
using System.Data;
using ExpensesTracker.RepositoryPattern.Interfaces;

namespace ExpensesTracker.Tests
{
    [TestFixture]
    public class SqlConnectionManagerTests
    {
        private Mock<ISqlConnectionManager> _mockManager;

        [SetUp]
        public void Setup()
        {
            _mockManager = new Mock<ISqlConnectionManager>();
        }

        [Test]
        public void OpenConnection_ShouldChangeStateToOpen_WhenInitiallyClosed()
        {
            _mockManager.Setup(m => m.State).Returns(ConnectionState.Closed);
            _mockManager.Setup(m => m.OpenConnection())
                        .Callback(() => _mockManager.Setup(m => m.State).Returns(ConnectionState.Open));

            _mockManager.Object.OpenConnection();

            Assert.That(_mockManager.Object.State, Is.EqualTo(ConnectionState.Open));
        }

        [Test]
        public void OpenConnection_ShouldStayOpen_WhenAlreadyOpen()
        {
            _mockManager.Setup(m => m.State).Returns(ConnectionState.Open);

            _mockManager.Object.OpenConnection();

            Assert.That(_mockManager.Object.State, Is.EqualTo(ConnectionState.Open));
        }

        [Test]
        public void CloseConnection_ShouldChangeStateToClosed_WhenOpen()
        {
            _mockManager.Setup(m => m.State).Returns(ConnectionState.Open);
            _mockManager.Setup(m => m.CloseConnection())
                        .Callback(() => _mockManager.Setup(m => m.State).Returns(ConnectionState.Closed));

            _mockManager.Object.CloseConnection();

            Assert.That(_mockManager.Object.State, Is.EqualTo(ConnectionState.Closed));
        }

        [Test]
        public void CloseConnection_ShouldStayClosed_WhenAlreadyClosed()
        {
            _mockManager.Setup(m => m.State).Returns(ConnectionState.Closed);

            _mockManager.Object.CloseConnection();

            Assert.That(_mockManager.Object.State, Is.EqualTo(ConnectionState.Closed));
        }
    }
}
