using System;
using System.Collections.Generic;
using System.Text;

namespace LightsCommand
{
    public class Invoker
    {

        private ICommand _slot;

        public void SenderCommand(ICommand command)
        {
            _slot = command;
        }

        public void ExecuteCommand()
        {
            _slot.execute();
        }
    }
}
