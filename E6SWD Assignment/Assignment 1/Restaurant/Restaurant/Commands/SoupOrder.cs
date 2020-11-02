using Restaurant.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Commands
{
    /* Concrete Command */
    public class SoupOrder : IOrder
    {
        private readonly Cook _cook;
        public SoupOrder(Cook cook)
        {
            _cook = cook;
        }
        public void Execute()
        {
            _cook.CookSoup();
        }
    }
}
