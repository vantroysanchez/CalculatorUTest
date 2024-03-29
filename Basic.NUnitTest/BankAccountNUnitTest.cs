﻿using Moq;
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

        [Test]
        public void BankAccountLoggerGeneralReference()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();

            Person person = new();
            Person personNotUsed = new();

            loggerGeneral.Setup(x => x.MessageReturnReference(ref person)).Returns(true);

            Assert.IsTrue(loggerGeneral.Object.MessageReturnReference(ref person));
            Assert.IsFalse(loggerGeneral.Object.MessageReturnReference(ref personNotUsed));
        }

        [Test]
        public void BankAccountLoggerGeneralLogMocking()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();
            loggerGeneral.SetupAllProperties();

            loggerGeneral.Setup(x => x.LoggerType).Returns("Warning");
            loggerGeneral.Setup(x => x.LoggerPriority).Returns(10);

            loggerGeneral.Object.LoggerPriority = 100;

            Assert.That(loggerGeneral.Object.LoggerType, Is.EqualTo("Warning"));
            Assert.That(loggerGeneral.Object.LoggerPriority, Is.EqualTo(10));

            //Callbacks

            string text = "Vantroy ";
            loggerGeneral.Setup(x => x.LogDatabase(It.IsAny<string>()))
                                .Returns(true)
                                .Callback<string>(param => text += param);

            loggerGeneral.Object.LogDatabase("Sanchez");

            Assert.That(text, Is.EqualTo("Vantroy Sanchez"));
        }

        [Test]       
        public void BankAccountLoggerGeneralVerifyExecution()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            BankAccount bankAccount = new (loggerGeneralMock.Object);

            bankAccount.Deposit(100);
            
            Assert.That(bankAccount.BalanceAccount, Is.EqualTo(100));

            //Verificar las veces que el mock está llamando al metodo message
            loggerGeneralMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(3));
            loggerGeneralMock.Verify(x => x.Message("Gracias por utilizar nuestros servicios"), Times.AtLeastOnce);
            loggerGeneralMock.VerifySet(x => x.LoggerPriority = 100, Times.Once);
            loggerGeneralMock.VerifyGet(x => x.LoggerPriority, Times.Once);
        }
    }
}
