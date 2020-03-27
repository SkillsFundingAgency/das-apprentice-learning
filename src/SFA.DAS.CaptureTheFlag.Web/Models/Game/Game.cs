using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Models.Game
{
    public class Game
    {
        public string Id { get; set; }
        public GameSetup Setup { get; set; }
        public GameData Data { get; set; }

        public Game()
        {
            Id = Guid.NewGuid().ToString();
            Setup = new GameSetup();
            Data = new GameData();
        }
    }
}
