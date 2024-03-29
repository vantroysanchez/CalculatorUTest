﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public interface ILoggerGeneral
    {
        public int LoggerPriority { get; set; }
        public string LoggerType { get; set; }

        void Message(string message);
        bool LogDatabase(string messege);
        bool LogBalanceAfterWithdrawal(int balanceAfter);
        string MessageString(string message);
        bool MessageReturnString(string message, out string outputText);
        bool MessageReturnReference(ref Person person);
    }
}
