using PortioningMachine.SystemComponents.Interfaces;
using System;

namespace PortioningMachine.SystemComponents
{

    public class Log : ILog
    {
        public void LogMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }


}
