using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Models.GameModels;

namespace DAS_Capture_The_Flag.Application.Repositories.GameRepository
{
    public class GameRepository : IGameRepository
    {
        public List<Game> Games { get; set; } = new List<Game>();
        
        public List<Game> GetAllGames()
        {
            return Games;
        }

        public async Task<Game> GetGame(Guid gameId)
        {
            return Games.FirstOrDefault(g => g.Id == gameId) ?? new NullGame();
        }

        public async Task<Game> JoinOrCreateGame(Player player)
        {
            var game = Games.FirstOrDefault(g => g.Players.PlayerOne.Id == Guid.Empty || g.Players.PlayerTwo.Id == Guid.Empty) ?? CreateNewGame();
          
            return await AddPlayerToGame(game, player);
        }
      
        public async Task<Game> AddPlayerToGame(Game game, Player player)
        {
            var players = game.Players;
            
            if (players.PlayerOne.Id == Guid.Empty)
            {
                players.PlayerOne = player;
            }
            else
            {
                players.PlayerTwo = player;
            }

            if (players.PlayerOne.Id != Guid.Empty && players.PlayerTwo.Id != Guid.Empty)
            {
                game.PlayersConnected = true;
            }

            return game;
        }

       public async Task<Game> UpdatePlayerReady(Guid gameId, Guid playerId)
        {
            var game = Games.FirstOrDefault(g => g.Id == gameId);

            if (game.Players.PlayerOne.Id == playerId)
            {
                game.Players.PlayerOne.Ready = true;
            } 
            else
            {
                game.Players.PlayerTwo.Ready = true;
            }

            return game;
        }

        private Game CreateNewGame()
        {
            var game = new Game();

            Games.Add(game);

            return game;
        }

    }
}
