using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    public interface IPlayer
    {

        public string Name { get; set; }
        void DealCard(Card card);
        int HandValue();
        List<Card> ShowHand();

    }
}
