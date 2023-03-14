using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    [TestFixture]
    public class BankAccountNUnitTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void DepositWithFake()
        {
            BankAccount bankAccount = new BankAccount(new LoggerGeneralFake());
            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.BalanceAccount, Is.EqualTo(100));
        }

        [Test]
        public void Deposit()
        {
            //1. Arrange
            var loggerFake = new Mock<ILoggerGeneral>();
            BankAccount bankAccount = new BankAccount(loggerFake.Object);

            //2. Act
            var result = bankAccount.Deposit(100);

            //3. Assert
            Assert.IsTrue(result);
            Assert.That(bankAccount.BalanceAccount, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void WithdrawalWithMayorBalance(int balance, int withdrawal)
        {
            //1. Arrange
            var loggerFake = new Mock<ILoggerGeneral>();

            loggerFake.Setup(x => x.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerFake.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(w => w>0))).Returns(true);

            BankAccount bankAccount = new BankAccount(loggerFake.Object);

            //2. Act
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdrawal(withdrawal);

            //3. Assert
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200, 400)]
        public void WithdrawalWithMinorBalance(int balance, int withdrawal)
        {
            //1. Arrange
            var loggerFake = new Mock<ILoggerGeneral>();
            
            loggerFake.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(w => w < 0))).Returns(false);

            BankAccount bankAccount = new BankAccount(loggerFake.Object);

            //2. Act
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdrawal(withdrawal);

            //3. Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void BankAccountLoggerGeneral()
        {
            var loggerGeneralFake = new Mock<ILoggerGeneral>();

            string TextString = "hola mundo";

            loggerGeneralFake.Setup(x=>x.MessageString(It.IsAny<string>())).Returns<string>( str => str.ToLower() );

            var result = loggerGeneralFake.Object.MessageString("Hola Mundo");

            Assert.That(result, Is.EqualTo(TextString));
        }

        [Test]
        public void BankAccountLoggerGeneralLogOutput()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();

            string text = "hola";

            loggerGeneral.Setup(x => x.MessageReturnString(It.IsAny<string>(), out text)).Returns(true);

            string outParameter = "";

            var result = loggerGeneral.Object.MessageReturnString("Vantroy", out outParameter);

            Assert.IsTrue(result);
        }
    }
}
