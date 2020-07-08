using System;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    public class Game
    {
        public Guid Id { get; set; }
        public GameData Data { get; set; }
        public Players Players { get; set; }
        public bool PlayersConnected { get; set; } = false;
        public int PlayersTurn { get; set; } = 1;
        public int PlayerOneScore { get; set; }
        public int PlayerTwoScore { get; set; }
        public Game()
        {
            Id = Guid.NewGuid();
            Data = new GameData();
            Players = new Players() { PlayerOne = new Player() { Number = 1 }, PlayerTwo = new Player() { Number = 2 } };
        }
    }
}
