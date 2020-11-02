using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Commands
{
    /* Abstract Command */
    public interface IOrder
    {
        public void Execute();
    }
}
