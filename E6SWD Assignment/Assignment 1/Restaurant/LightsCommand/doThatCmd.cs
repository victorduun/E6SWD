using System;
using System.Collections.Generic;
using System.Text;

namespace LightsCommand
{
    public class doThatCmd : ICommand
    {
        private Reciever _reciever;
        public doThatCmd(Reciever reciever)
        {
            _reciever = reciever;
        }
        public void execute()
        {
            _reciever.doThat();
        }
    }
}
