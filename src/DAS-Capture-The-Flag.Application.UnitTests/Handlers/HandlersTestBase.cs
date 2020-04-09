using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DAS_Capture_The_Flag.Application.UnitTests.Handlers
{
    [TestFixture]
    public class HandlersTestBase
    {
        protected IGameRepository Repository;

        public Guid PlayerId_1 = Guid.NewGuid();
        public Guid PlayerId_2 = Guid.NewGuid();
        public Guid GameId = Guid.NewGuid();
        public Guid CorrectGameId = Guid.NewGuid();
        public Guid IncorrectGameId = Guid.NewGuid();

        [SetUp]
        public void Arrange()
        {
            Repository = new GameRepository(); 
        }

        public List<Game> CreateTestEmptyLobby()
        {
            return new List<Game>();
        }

        public List<Game> CreateTestLobbyWithOneGameAndOnePlayer()
        {
            return new List<Game>()
            {
                new Game()
                {
                    Players = {
                        PlayerOne = new Player() {  Id = PlayerId_1},
                        PlayerTwo = new Player()
                    }
                }
            };
        }

        public List<Game> CreateTestLobbyWithOneGameTwoPlayers_BothNotReady()
        {
            return new List<Game>()
            {
                new Game()
                {
                    Id = GameId,
                    PlayersConnected = true,
                    Players =
                    {
                        PlayerOne = new Player() { Id = PlayerId_1, Ready = false },
                        PlayerTwo = new Player() { Id = PlayerId_2, Ready = false }
                    }
                    
                }
            };
        }

    }
}
