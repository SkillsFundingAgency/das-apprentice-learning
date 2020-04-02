using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DAS_Capture_The_Flag.Models.Game
{
    public class GameSetup
    {
        public List<Player> Players { get; set; }
        public bool PlayersConnected { get; set; }
        public int PlayersTurn { get; set; }

        public GameSetup()
        {
            Players = new List<Player>() { new Player(), new Player() };
            
            PlayersConnected = false;
            PlayersTurn = 1;
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

        public Game SetPlayerConnectionId(Game game, string connectionId)
        {
            if (game.Setup.Players[0].ConnectionId == null)
            {
                game.Setup.Players[0].ConnectionId = connectionId;
            }
            else
            {
                game.Setup.Players[1].ConnectionId = connectionId;
            }

            return game;
        }

        public Game SetPlayersConnected(Game game)
        {
            var player = game.Setup.Players;

            game.Setup.PlayersConnected = player[0].ConnectionId != null && player[1].ConnectionId != null;

            return game;
        }

    }
}
