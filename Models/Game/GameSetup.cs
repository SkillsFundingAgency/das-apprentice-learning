using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DAS_Capture_The_Flag.Models.Game
{
    public class GameSetup
    {
        public string GameId { get; set; }
        public List<Player> Players { get; set; }
        public bool PlayersConnected { get; set; }
        public bool Ready { get; set; }
        public int PlayersTurn { get; set; }

        public GameSetup()
        {
            Players = new List<Player>() { new Player(), new Player() };
            
            PlayersConnected = false;
            PlayersTurn = 0;
            GameId = Guid.NewGuid().ToString(); 
        }

        public bool HasPlayer(string connectionId)
        {
            if (Players[0] != null && Players[0].ConnectionId == connectionId)
            {
                return true;
            }
            if (Players[1] != null && Players[1].ConnectionId == connectionId)
            {
                return true;
            }
            return false;
        }
    }
}
