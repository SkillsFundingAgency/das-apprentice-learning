using DAS_Capture_The_Flag.Models.Game;
using DAS_Capture_The_Flag.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Hubs
{
    public class GameHub : Hub<IGameClient>
    {
        private IGameRepository _repository;

        public GameHub(IGameRepository repository) 
        {
            _repository = repository;
        }
        public override async Task OnConnectedAsync()
        {
            var repo = _repository;
        }

        public async Task UpdatePlayerConnectionId(string id, string playerId, Game game)
        {
            _repository.Games.FirstOrDefault(g => g.Id == id).Setup.Players.FirstOrDefault(p => p.ConnectionId == playerId).ConnectionId = Context.ConnectionId;
            await Groups.AddToGroupAsync(Context.ConnectionId, id);
        }

        public async Task CanvasClickController(int x, int y, string gameId)
        {
            var game = _repository.Games.FirstOrDefault(g => g.Id == gameId);

            var playersTurn = CheckPlayersTurn(game, Context.ConnectionId);

            if (playersTurn == game.Setup.PlayersTurn)
            {
                var selectedSoldier = game.Data.Soldiers.Where(s => s.Selected == true).FirstOrDefault();

                if (selectedSoldier is null)
                {
                    var soldier = game.Data.Soldiers.Where(s => s.xPos == x && s.yPos == y).FirstOrDefault();

                    if (soldier.Player == playersTurn)
                    {
                        soldier.Selected = !soldier.Selected;
                        soldier.PotentialMoves = CalculatePotentialMoves(3, new List<Coordinates>(), new List<Coordinates> { new Coordinates { X = x, Y = y } }, game.Data.ChosenMap);
                    }
                    
                }
                else
                {
                    if (selectedSoldier.Player == playersTurn)
                    {
                        if (selectedSoldier.PotentialMoves.Exists(c => c.X == x && c.Y == y) && !(selectedSoldier.xPos == x && selectedSoldier.yPos == y))
                        {
                            selectedSoldier.xPos = x;
                            selectedSoldier.yPos = y;

                            game.Setup.PlayersTurn = (game.Setup.PlayersTurn == 1) ? 2 : 1;
                        }
                        
                        selectedSoldier.Selected = false;
                        selectedSoldier.PotentialMoves = new List<Coordinates>();
                    }
                }


                var updatedGame = JsonConvert.SerializeObject(new GameViewModel(game, Context.ConnectionId));

                await Clients.Group(gameId).UpdateModel(updatedGame);

            }
            

        }

        private List<Coordinates> CalculatePotentialMoves(int stepsLeft, List<Coordinates> existingCoords, List<Coordinates> thisCoords, int[,] map)
        {
            existingCoords.AddRange(thisCoords);

            if (stepsLeft == 0)
            {
                return existingCoords;
            }

            var newCoords = new List<Coordinates>();

            foreach (var coord in thisCoords)
            {
                var newCoord = new Coordinates { X = coord.X, Y = coord.Y + 1 };

                if (!existingCoords.Exists(c => c.X == newCoord.X && c.Y == newCoord.Y) && !newCoords.Exists(c => c.X == newCoord.X && c.Y == newCoord.Y) )
                {
                    if (newCoord.X >= 0 && newCoord.Y >= 0 && newCoord.X < 10 && newCoord.Y < 10)
                    {
                        if (map[newCoord.Y, newCoord.X] == 0)
                        {
                            newCoords.Add(newCoord);
                        }
                    }
                    
                }
                newCoord = new Coordinates { X = coord.X + 1, Y = coord.Y };
                if (!existingCoords.Exists(c => c.X == newCoord.X && c.Y == newCoord.Y) && !newCoords.Exists(c => c.X == newCoord.X && c.Y == newCoord.Y) )
                {
                    if (newCoord.X >= 0 && newCoord.Y >= 0 && newCoord.X < 10 && newCoord.Y < 10)
                    {
                        if (map[newCoord.Y, newCoord.X] == 0)
                        {
                            newCoords.Add(newCoord);
                        }
                    }
                }
                newCoord = new Coordinates { X = coord.X, Y = coord.Y - 1 };
                if (!existingCoords.Exists(c => c.X == newCoord.X && c.Y == newCoord.Y) && !newCoords.Exists(c => c.X == newCoord.X && c.Y == newCoord.Y))
                {
                    if (newCoord.X >= 0 && newCoord.Y >= 0 && newCoord.X < 10 && newCoord.Y < 10)
                    {
                        if (map[newCoord.Y, newCoord.X] == 0)
                        {
                            newCoords.Add(newCoord);
                        }
                    }
                }
                newCoord = new Coordinates { X = coord.X - 1, Y = coord.Y };
                if (!existingCoords.Exists(c => c.X == newCoord.X && c.Y == newCoord.Y) && !newCoords.Exists(c => c.X == newCoord.X && c.Y == newCoord.Y) )
                {
                    if (newCoord.X >= 0 && newCoord.Y >= 0 && newCoord.X < 10 && newCoord.Y < 10)
                    {
                        if (map[newCoord.Y, newCoord.X] == 0)
                        {
                            newCoords.Add(newCoord);
                        }
                    }
                }

            }

            return CalculatePotentialMoves(stepsLeft - 1, existingCoords, newCoords, map); ;
        }

       

        private int CheckPlayersTurn(Game game, string connectionId)
        {
            return (game.Setup.Players[0].ConnectionId == connectionId) ? 1 : 2;
        }
    }

    public interface IGameClient
    {
        Task UpdatePlayerConnectionId(string id, string playerId);
        Task UpdateModel(string updatedGame);
        Task HighlightPotentialMoves(List<Coordinates> moves);
    }
}
