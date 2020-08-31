using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    public interface IGame
    {
        void AcceptPlayer(IPlayer player);
        IPlayer AnnounceWinner();
        void StartGame();
        
    }
}
