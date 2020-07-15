using DAS_Capture_The_Flag.Application.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame
{
    public class JoinOrCreateGameResponse
    {
        public Game Game { get; set; }

        public JoinOrCreateGameResponse(Game game)
        {
            Game = game;
        }
    }
}
