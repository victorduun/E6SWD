using Exercise1.Game;
using Exercise1.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    public static class Program
    {
        public static void Main()
        {
            //Todo: smid et deck ind i game

            IGame game = new LowestSumGame();


            IPlayer player1 = new NormalPlayer("1");
            IPlayer player2 = new Weakplayer("2");
            IPlayer player3 = new NormalPlayer("3");


            game.AcceptPlayer(player1);
            game.AcceptPlayer(player2);
            game.AcceptPlayer(player3);

            game.StartGame();

        }
    }
}
