using ExpensesTracker.RepositoryPattern.Interfaces;
using Moq;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesTracker.Factory.Interface;

namespace ExpensesTracker.UnitTests
{
    [TestFixture]
    public class SplashTests
    {
        [Test]
        public void Timer_Tick_Increments_ProgressBar()
        {
            var factoryMock = new Mock<AbstractRepositoryFactory>();
            factoryMock.Setup(f => f.CreateUserRepository())
                       .Returns(new Mock<IUserRepository>().Object);

            var splash = new Splash(factoryMock.Object);
            ProgressBar progressBar = splash.MyProgressBar;
            int initialValue = progressBar.Value;

            splash.Timer1_Tick(new System.Windows.Forms.Timer(), EventArgs.Empty);

            Assert.That(progressBar.Value, Is.EqualTo(initialValue + 1));
        }
        [Test]
        public void Timer_Tick_Event_Completes_ProgressBar_And_Shows_Login_Form()
        {
            var factoryMock = new Mock<AbstractRepositoryFactory>();
            factoryMock.Setup(f => f.CreateUserRepository())
                       .Returns(new Mock<IUserRepository>().Object);

            var splashForm = new Splash(factoryMock.Object);

            // Setăm progresul aproape de final pentru a forța închiderea formularului
            splashForm.MyProgressBar.Value = 99;

            // Simulăm un tick al timerului care finalizează progresul
            splashForm.Timer1_Tick(new System.Windows.Forms.Timer(), EventArgs.Empty);

            // Verificăm că formularul Splash a fost ascuns
            Assert.That(splashForm.Visible, Is.False);
        }
    }
}
