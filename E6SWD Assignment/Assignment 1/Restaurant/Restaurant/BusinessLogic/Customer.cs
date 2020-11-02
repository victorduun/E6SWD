using Restaurant.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BusinessLogic
{
    /* Not part of pattern */
    public enum Dish
    {
        Chicken,
        Soup,
    }

    public class Customer
    {
        public Dish GetDish()
        {
            var key = Console.ReadKey();
            switch (key.KeyChar.ToString().ToLower())
            {
                case "c":
                    return Dish.Chicken;
                case "s":
                    return Dish.Soup;
                default:
                    return Dish.Chicken;
            }
        }
    }
}
