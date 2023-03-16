using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public class LoggerGeneralFake : ILoggerGeneral
    {
        public int LoggerPriority { get; set; }
        public string LoggerType { get; set; }

        public bool LogBalanceAfterWithdrawal(int balanceAfter)
        {
            return false;
        }
        public bool LogDatabase(string messege)
        {
            return false;
        }

        public void Message(string message)
        {
            
        }

        public bool MessageReturnReference(ref Person person)
        {
            return true;
        }

        public bool MessageReturnString(string message, out string outputText)
        {
            outputText = string.Empty;
            return true;
        }

        public string MessageString(string message)
        {
            return message;
        }
    }
}
