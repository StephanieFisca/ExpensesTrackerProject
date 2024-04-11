using ExpensesTracker.RepositoryPattern.Interfaces;
using Moq;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.UnitTests
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
}
