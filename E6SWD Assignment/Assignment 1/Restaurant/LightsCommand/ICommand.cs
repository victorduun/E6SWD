using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LightsCommand
{
    public interface ICommand
    {
        public void execute();
    }
}
