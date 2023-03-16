using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Basic
{
    
    public class BankAccountXUnitTest
    { 

        [Fact]
        public void DepositWithFake()
        {
            BankAccount bankAccount = new BankAccount(new LoggerGeneralFake());
            var result = bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100, bankAccount.BalanceAccount());
        }

        [Fact]
        public void Deposit()
        {
            //1. Arrange
            var loggerFake = new Mock<ILoggerGeneral>();
            BankAccount bankAccount = new BankAccount(loggerFake.Object);

            //2. Act
            var result = bankAccount.Deposit(100);

            //3. Assert
            Assert.True(result);
            Assert.Equal(100, bankAccount.BalanceAccount());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
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
            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 400)]
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
            Assert.False(result);
        }

        [Fact]
        public void BankAccountLoggerGeneral()
        {
            var loggerGeneralFake = new Mock<ILoggerGeneral>();

            string TextString = "hola mundo";

            loggerGeneralFake.Setup(x=>x.MessageString(It.IsAny<string>())).Returns<string>( str => str.ToLower() );

            var result = loggerGeneralFake.Object.MessageString("Hola Mundo");

            Assert.Equal(TextString, result);
        }

        [Fact]
        public void BankAccountLoggerGeneralLogOutput()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();

            string text = "hola";

            loggerGeneral.Setup(x => x.MessageReturnString(It.IsAny<string>(), out text)).Returns(true);

            string outParameter = "";

            var result = loggerGeneral.Object.MessageReturnString("Vantroy", out outParameter);

            Assert.True(result);
        }

        [Fact]
        public void BankAccountLoggerGeneralReference()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();

            Person person = new();
            Person personNotUsed = new();

            loggerGeneral.Setup(x => x.MessageReturnReference(ref person)).Returns(true);

            Assert.True(loggerGeneral.Object.MessageReturnReference(ref person));
            Assert.False(loggerGeneral.Object.MessageReturnReference(ref personNotUsed));
        }

        [Fact]
        public void BankAccountLoggerGeneralLogMocking()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();
            loggerGeneral.SetupAllProperties();

            loggerGeneral.Setup(x => x.LoggerType).Returns("Warning");
            loggerGeneral.Setup(x => x.LoggerPriority).Returns(10);

            loggerGeneral.Object.LoggerPriority = 100;

            Assert.Equal("Warning", loggerGeneral.Object.LoggerType);
            Assert.Equal(10, loggerGeneral.Object.LoggerPriority);

            //Callbacks

            string text = "Vantroy ";
            loggerGeneral.Setup(x => x.LogDatabase(It.IsAny<string>()))
                                .Returns(true)
                                .Callback<string>(param => text += param);

            loggerGeneral.Object.LogDatabase("Sanchez");

            Assert.Equal("Vantroy Sanchez", text);
        }

        [Fact]       
        public void BankAccountLoggerGeneralVerifyExecution()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            BankAccount bankAccount = new (loggerGeneralMock.Object);

            bankAccount.Deposit(100);
            
            Assert.Equal(100, bankAccount.BalanceAccount());

            //Verificar las veces que el mock está llamando al metodo message
            loggerGeneralMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(3));
            loggerGeneralMock.Verify(x => x.Message("Gracias por utilizar nuestros servicios"), Times.AtLeastOnce);
            loggerGeneralMock.VerifySet(x => x.LoggerPriority = 100, Times.Once);
            loggerGeneralMock.VerifyGet(x => x.LoggerPriority, Times.Once);
        }
    }
}
