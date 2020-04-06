using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
            Repository = Substitute.For<IGameRepository>();


        }

        public List<Game> CreateEmptyLobby()
        {
            return new List<Game>();
        }

        public List<Game> CreateLobbyOneGameOnePlayer()
        {
            return new List<Game>()
            {
                new Game()
                {
                    Setup = new GameSetup()
                    {
                        Players = new List<Player>()
                        {
                            new Player() {  Id = PlayerId_1},
                            new Player()
                        }
                    }
                }
            };
        }
        public List<Game> CreateLobbyOneGameTwoPlayers_BothNotReady()
        {
            return new List<Game>()
            {
                new Game()
                {
                    Id = GameId,
                    Setup = new GameSetup()
                    {
                        PlayersConnected = true,
                        Players = new List<Player>()
                        {
                            new Player() { Id = PlayerId_1, Ready = false },
                            new Player() { Id = PlayerId_2, Ready = false }
                        }
                    }
                }
            };
        }
    }
}
