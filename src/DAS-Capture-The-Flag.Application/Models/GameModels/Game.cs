using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    public class Game
    {
        public Guid Id { get; set; }
        public GameSetup Setup { get; set; }
        public GameData Data { get; set; }

        public Game()
        {
            Id = Guid.NewGuid();
            Setup = new GameSetup();
            Data = new GameData();
        }
    }
}
