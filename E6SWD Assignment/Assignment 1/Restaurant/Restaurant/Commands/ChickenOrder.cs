using Restaurant.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Commands
{
    /* Concrete Command */
    public class ChickenOrder : IOrder
    {
        private readonly Cook _cook;
        public ChickenOrder(Cook cook)
        {
            _cook = cook;
        }
        public void Execute()
        {
            _cook.CookChicken();
        }
    }
}
