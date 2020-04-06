using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
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
            PlayersTurn = 0;
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

        public Game AddPlayerToGame(Game game, Guid playerId)
        {
            game.Setup.Players.FirstOrDefault(p => p.Id == Guid.Empty).Id = playerId;


            var player = game.Setup.Players;
            game.Setup.PlayersConnected = player[0].Id != Guid.Empty && player[1].Id != Guid.Empty;

            return game;
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
