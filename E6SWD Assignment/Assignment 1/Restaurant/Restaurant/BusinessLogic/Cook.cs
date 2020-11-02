using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Commands;

namespace Restaurant.BusinessLogic
{
    /* Receiver */

    public class Cook
    {
        public void CookChicken()
        {
            Console.WriteLine("Chicken ready");
        }

        public void CookSoup()
        {
            Console.WriteLine("Soup ready");
        }
    }
}
