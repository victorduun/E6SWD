using System;

namespace LightsCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            Reciever reciever = new Reciever();
            doThisCmd doThisCmd = new doThisCmd(reciever);
            doThatCmd doThatCmd = new doThatCmd(reciever);
            doThisAndThatCmd doThisAndThatCmd = new doThisAndThatCmd(reciever);

            
            invoker.SenderCommand(doThisCmd);
            invoker.ExecuteCommand();
            invoker.SenderCommand(doThatCmd);
            invoker.ExecuteCommand();
            invoker.SenderCommand(doThisAndThatCmd);
            invoker.ExecuteCommand();
        }
    }
}
