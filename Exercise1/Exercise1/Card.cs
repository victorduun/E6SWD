using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise1
{
    public class Card
    {
        public Card()
        {
            Random rand = new Random();
            CardNumber = rand.Next(1, 9);
            //Get a random color from enum value
            var colors = (int[])Enum.GetValues(typeof(Color));

            int index = rand.Next(0, colors.Length );

            Suit = (Color)colors[index];
        }    
        public Color Suit { get; private set; }
        public int Value { 
            get
            {
                return CardNumber * (int)Suit;
            } 
        }
        public int CardNumber { get; private set; }
    }

}
