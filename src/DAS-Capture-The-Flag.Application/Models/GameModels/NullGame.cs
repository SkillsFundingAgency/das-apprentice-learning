using System;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    public class NullGame : Game
    {
        public NullGame()
        {
            Id = Guid.Empty;
            Data = null;
            Players = null;
            PlayersConnected = false;
        }
    }
}
