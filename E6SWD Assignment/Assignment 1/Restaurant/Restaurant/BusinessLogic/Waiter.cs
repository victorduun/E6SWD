using Restaurant.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.BusinessLogic
{
    /* Invoker */
    public class Waiter
    {

        private readonly List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void StartOrder()
        {
            _orders.First().Execute();
            _orders.RemoveAt(0);
        }


    }
}
