﻿using DAS_Capture_The_Flag.Models.Game;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace DAS_Capture_The_Flag.Hubs
{
    public interface ISetupClient
    {
        Task StartGame(string gameId, string playerId);
        Task PlayerReady(bool playerOne, bool playerTwo);
        Task AwaitPlayersReady();
        Task UpdatePlayerReady();
        Task OpponentReady();
        Task OpponentLeftLobby();
    }

    public class SetupHub : BaseHub<ISetupClient> 
    {
        
        public SetupHub(IGameRepository repository) : base(repository)
        {
        }

        public override async Task OnConnectedAsync()
        {
            var game = FindGame();

            if (game == null)
            {
                game = AddGame(new Game());
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, game.Setup.GameId);

            game.Setup.SetPlayerConnectionId(game, Context.ConnectionId);
            game.Setup.SetPlayersConnected(game);

            UpdateGame(game);

            await Clients.Group(game.Setup.GameId).PlayerReady(game.Setup.Players[0].ConnectionId != null, game.Setup.Players[1].ConnectionId != null);

            await base.OnConnectedAsync();

            if (game.Setup.PlayersConnected)
            {
                await Clients.Group(game.Setup.GameId).AwaitPlayersReady();
            }
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Game game = GetAllGames().FirstOrDefault(g => g.Setup.Players[0].ConnectionId == Context.ConnectionId || g.Setup.Players[1].ConnectionId == Context.ConnectionId);

            Player player = game.Setup.Players.Where(x => x.ConnectionId == Context.ConnectionId).FirstOrDefault();
            Player opponent = game.Setup.Players.Where(x => x.ConnectionId != Context.ConnectionId).FirstOrDefault();

            player.ConnectionId = null;
            player.Ready = false;
            player.Name = null;
            game.Setup.PlayersConnected = false;

            await Clients.Client(opponent.ConnectionId).OpponentLeftLobby();
            await Clients.Group(game.Setup.GameId).PlayerReady(game.Setup.Players[0].ConnectionId != null, game.Setup.Players[1].ConnectionId != null);

        }

        private Player GetPlayerFromId(Game game, string connectionId)
        {
            if (game.Setup.Players[0].ConnectionId == connectionId)
            {
                return game.Setup.Players[0];
            }
            else
            {
                return game.Setup.Players[1];
            }
        }

        public async Task UpdatePlayerReady()
        {
            var game = GetPlayersGame(Context.ConnectionId);

            var player = game.Setup.Players.FirstOrDefault(p => p.ConnectionId == Context.ConnectionId); //GetPlayer(game.Setup, Context.ConnectionId);

            player.Ready = true;

            if (GetPlayersReady(game.Setup))
            {
                game.Data = new GameData();
               
                await Clients.Client(game.Setup.Players[0].ConnectionId).StartGame(game.Setup.GameId.ToString(), game.Setup.Players[0].ConnectionId.ToString());
                await Clients.Client(game.Setup.Players[1].ConnectionId).StartGame(game.Setup.GameId.ToString(), game.Setup.Players[1].ConnectionId.ToString());
            }
            else
            {
                var otherPlayer = GetOpponent(game.Setup, Context.ConnectionId);
                await Clients.Client(otherPlayer.ConnectionId).OpponentReady();
            }
        }

  
        private bool GetPlayersReady(GameSetup game)
        {
            if (game.Players[0].Ready && game.Players[1].Ready)
            {
                return true;
            }

            return false;
        }

        private Player GetPlayer(GameSetup game, string id)
        {
            if (game.Players[0].ConnectionId == id)
            {
                return game.Players[0];
            }

            return game.Players[1];
        }

        private Player GetOpponent(GameSetup game, string id)
        {
            if (game.Players[0].ConnectionId != id)
            {
                return game.Players[0];
            }

            return game.Players[1];
        }

        private Game FindGame()
        {
            var games = GetAllGames();

            var game = games.FirstOrDefault(g => !g.Setup.PlayersConnected);
            return game;
        }

        
    }
}