using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise1.Player
{
    class Weakplayer : IPlayer
    {
        public Weakplayer(string name)
        {
            Name = name;
        }
        private List<Card> Hand { get; set; } = new List<Card>();

        public string Name { get; set; }

        public void DealCard(Card card)
        {
            if(Hand.Count >= 3)
            {
                Random rand = new Random();
                Hand.RemoveAt(rand.Next(0,3));
            }
            Hand.Add(card);
        }

        public int HandValue()
        {

            int sum = 0;
            foreach (Card card in Hand)
            {
                sum += card.Value;
            }
            return sum;
        }

        public List<Card> ShowHand()
        {
            return Hand;
        }
    }
}
