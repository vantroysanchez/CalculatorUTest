using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public class BankAccount
    {
        private readonly ILoggerGeneral _loggerGeneral;
        public int Balance { get; set; }

        public BankAccount(ILoggerGeneral loggerGeneral)
        {
            _loggerGeneral = loggerGeneral;
            Balance = 0;
        }

        public bool Deposit(int amount)
        {
            _loggerGeneral.Message("Ha realizado un deposito de: " + amount.ToString());
            _loggerGeneral.Message("Transacción finalizada");
            _loggerGeneral.Message("Gracias por utilizar nuestros servicios");

            _loggerGeneral.LoggerPriority = 100;

            var priority = _loggerGeneral.LoggerPriority;

            Balance += amount;
            return true;
        }

        public bool Withdrawal(int amount)
        {
            if (amount <= Balance)
            {
                _loggerGeneral.LogDatabase("Monto de retiro: " + amount.ToString());
                Balance -= amount;

                return _loggerGeneral.LogBalanceAfterWithdrawal(amount);
            }

            return _loggerGeneral.LogBalanceAfterWithdrawal(Balance - amount);
        }

        public int BalanceAccount()
        {
            return Balance;
        }
    }
}
