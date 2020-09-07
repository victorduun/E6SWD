using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise1.Game
{
    public class LowestSumGame : IGame
    {
        private List<IPlayer> Players { get; set; } = new List<IPlayer>();
        private Deck Deck { get; set; } = new Deck(50);

        public void AcceptPlayer(IPlayer player)
        {
            Players.Add(player);
        }

        public IPlayer AnnounceWinner()
        {
            var player = Players.OrderBy(p => p.HandValue())
                .First();

            return player;
        }

        public void StartGame()
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (var player in Players)
                {
                    Deck.DealCard(player);
                }
            }

            foreach (var player in Players)
            {
                var playerCards = player.ShowHand();

                Console.WriteLine(player.Name + " Has the following cards:");

                foreach (var card in playerCards)
                {
                    Console.WriteLine("Card number " + card.CardNumber + ". Card suit: " + Enum.GetName(typeof(Color), card.Suit));
                }


            }

            var winner = AnnounceWinner();
            Console.WriteLine("The winner is {0} with {1} points.", winner.Name, winner.HandValue());
        }
    }
}
