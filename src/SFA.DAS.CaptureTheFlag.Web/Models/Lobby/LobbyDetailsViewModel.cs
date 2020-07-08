using System;
using DAS_Capture_The_Flag.Application.Models.GameModels;

namespace DAS_Capture_The_Flag.Web.Models.Lobby
{
    public class LobbyDetailsViewModel
    {
        public Game Game { get; set; }
        public bool PlayersConnected { get; set; }
        public Player Player { get; set; }
        public Player Opponent { get; set; }

        public LobbyDetailsViewModel(Game game, Guid playerId)
        {
            Game = game;
            PlayersConnected = game.PlayersConnected;
            Player = GetPlayer(playerId);
            Opponent = GetOpponent(playerId);
        }

        private Player GetPlayer(Guid playerId)
        {
            return Game.Players.PlayerOne.Id == playerId ? Game.Players.PlayerOne : Game.Players.PlayerTwo;
        }
        private Player GetOpponent(Guid playerId)
        {
            return Game.Players.PlayerOne.Id == playerId ? Game.Players.PlayerTwo : Game.Players.PlayerOne;
        }
    }
}
