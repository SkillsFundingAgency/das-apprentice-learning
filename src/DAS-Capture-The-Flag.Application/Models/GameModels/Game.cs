using System;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    public class Game
    {
        public Guid Id { get; set; }
        public GameData Data { get; set; }
        public Players Players { get; set; }
        public bool PlayersConnected { get; set; } = false;

        public Game()
        {
            Id = Guid.NewGuid();
            Data = new GameData();
            Players = new Players() { PlayerOne = new Player(), PlayerTwo = new Player() };
        }
    }
}
