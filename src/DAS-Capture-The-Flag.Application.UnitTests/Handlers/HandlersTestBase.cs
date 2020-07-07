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

        public Player Player_1 = new Player(Guid.NewGuid(), new PlayerDetails("Player One"));
        public Player Player_2 = new Player(Guid.NewGuid(), new PlayerDetails("Player Two"));
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

        public List<Game> CreateTestLobbyWithOneGameAndOnePlayerWaitingForAnOpponent()
        {
            return new List<Game>()
            {
                new Game()
                {
                    Players = {
                        PlayerOne = Player_1,
                        PlayerTwo = new Player()
                    }
                }
            };
        }

        public List<Game> CreateTestLobbyWithOneGameTwoPlayers_WhereBothPlayersAreNotReady()
        {
            return new List<Game>()
            {
                new Game()
                {
                    Id = GameId,
                    PlayersConnected = true,
                    Players =
                    {
                        PlayerOne = Player_1,
                        PlayerTwo = Player_2
                    }
                }
            };
        }

    }
}
