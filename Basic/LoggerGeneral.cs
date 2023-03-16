using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public class LoggerGeneral : ILoggerGeneral
    {
        public int LoggerPriority { get; set; }
        public string LoggerType { get; set; }

        public bool LogBalanceAfterWithdrawal(int balanceAfter)
        {
            if (balanceAfter >= 0)
            {
                Console.WriteLine("Operación exitosa");
                return true;
            }

            Console.WriteLine("Error en la operación");
            return false;
        }

        public bool LogDatabase(string messege)
        {
            Console.WriteLine(messege);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool MessageReturnReference(ref Person person)
        {
            return true;
        }

        public bool MessageReturnString(string message, out string outputText)
        {
            outputText = "Hola" + message;

            return true;
        }

        public string MessageString(string message)
        {
            Console.WriteLine(message);

            return message.ToLower();
        }
    }
}
