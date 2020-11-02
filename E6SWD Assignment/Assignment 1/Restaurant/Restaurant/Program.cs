using Restaurant.BusinessLogic;
using Restaurant.Commands;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Restaurant
{
    /* Client */
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Cook cook = new Cook();
            Waiter waiter = new Waiter();

            Console.WriteLine("Welcome to the restaurant. Press 's' to order soup, and 'c' to order chicken.");
            IOrder order;
            switch (customer.GetDish())
            {
                case Dish.Chicken:
                    order = new ChickenOrder(cook);
                    break;
                case Dish.Soup:
                    order = new SoupOrder(cook);
                    break;
                default:
                    throw new Exception();
            }

            waiter.TakeOrder(order);

            waiter.StartOrder();
        }
    }
}
