using DAS_Capture_The_Flag.Models.Game;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Hubs
{
    public abstract class BaseHub<T> : Hub<T> where T : class
    {

        private IGameRepository _repository;
        List<Game> Games { get; set; }
        public BaseHub(IGameRepository repository)
        {
            _repository = repository;
        }

        public Game AddGame(Game game)
        {
            Games.Add(game);

            return game;
        }

        public void UpdateGame(Game game)
        {
            var Game = Games.Where(g => g.Setup.GameId == game.Setup.GameId).FirstOrDefault();
            Game = game;
        }

        public List<Game> GetAllGames() 
        {
            return Games;
        }

        public Game GetPlayersGame(string playerId)
        {
            return Games.FirstOrDefault(g => g.Setup.HasPlayer(Context.ConnectionId));
        }

        public Game GetGame(string gameId)
        {
            return Games.FirstOrDefault(g => g.Setup.GameId == gameId);
        }

        public Game SetPlayersConnected(Game game)
        {
            var player = game.Setup.Players;

            game.Setup.PlayersConnected = player[0].ConnectionId != null && player[1].ConnectionId != null;

            return game;
        }
    }
    
}
