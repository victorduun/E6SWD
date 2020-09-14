using PortioningMachine.SystemComponents.Interfaces;
using System;

namespace PortioningMachine.SystemComponents
{

    public class ConsoleLog : ILog
    {
        public void LogMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }


}
