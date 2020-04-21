﻿
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Models.GameModels;

namespace DAS_Capture_The_Flag.Application.Repositories.GameRepository
{
    public interface IGameRepository
    {
        public List<Game> Games { get; set; }

        Task<Game> GetGame(Guid gameId);
        Task<Game> JoinOrCreateGame(Guid playerId);
        Task<Game> AddPlayerToGame(Game game, Guid playerId);
        Task<Game> UpdatePlayerReady(Guid gameId, Guid playerId);
    }

}
