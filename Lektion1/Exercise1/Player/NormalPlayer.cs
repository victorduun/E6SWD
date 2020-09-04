using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1.Player
{
    public class NormalPlayer : IPlayer
    {
        public NormalPlayer(string name)
        {
            Name = name;
        }
        private List<Card> Hand { get; set; } = new List<Card>();

        public string Name { get; set; }

        public void DealCard(Card card)
        {
            Hand.Add(card);
        }

        public int HandValue()
        {

            int sum = 0;
            foreach(Card card in Hand)
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
