using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise1
{
    public class Deck
    {
        public Deck(int deckSize)
        {
            for(int i = 0; i < deckSize; i++)
            {
                Cards.Add(new Card());
            }
        }


        public List<Card> Cards { get; set; } = new List<Card>();
        public void DealCard(IPlayer player)
        {
            //Todo: Give random card to player from list of cards

            Card firstCard = Cards.First();
            player.DealCard(firstCard);
            Cards.Remove(firstCard);
        }
    }
}
