using System;
using System.Collections.Generic;
using DAS_Capture_The_Flag.Hubs;
using DAS_Capture_The_Flag.Models.Game;
using FluentAssertions;
using NUnit.Framework;

namespace DAS_Capture_The_Flag.Web.UnitTests.HubTests.SetupHubTests
{
    [TestFixture]
    public class WhenAPlayerSearchesForAGame : SetupHubTestsBase
    {

        private SetupHub sut;

        [SetUp]
        public void Arrange()
        {
           
            sut = new SetupHub(GameRepository);
        }

        [Test]
        public void AndTheLobbyIsEmpty_ThenANewGameIsCreated()
        {
            GameRepository.Games = CreateEmptyLobby();

            var result = sut.OnConnectedAsync();

            GameRepository.Games.Count.Should().Be(1);
        }

        [Test]
        public void AndTheLobbyContainsOnePlayer_ThenANewGameIsntCreated()
        {
            GameRepository.Games = CreateLobbyOneGameOnePlayer();

            var result = sut.OnConnectedAsync();

            GameRepository.Games.Count.Should().Be(1);
        }

        [Test]
        public void AndTheLobbyContainsOneGame_ThenANewGameIsCreated()
        {
            GameRepository.Games = CreateLobbyOneGameTwoPlayers();

            var result = sut.OnConnectedAsync();

            GameRepository.Games.Count.Should().Be(2);
        }

        private List<Game> CreateEmptyLobby()
        {
            return new List<Game>();
        }

        private List<Game> CreateLobbyOneGameOnePlayer()
        {
            return new List<Game>()
            {
                new Game()
                {
                    Setup = new GameSetup()
                    {
                        Players = new List<Player>()
                        { 
                            new Player() { ConnectionId = Guid.NewGuid().ToString()} 
                        }
                    }
                }
            };
        }
        private List<Game> CreateLobbyOneGameTwoPlayers()
        {
            return new List<Game>()
            {
                new Game()
                {
                    Setup = new GameSetup()
                    {
                        PlayersConnected = true,
                        Players = new List<Player>()
                        {
                            new Player() { ConnectionId = Guid.NewGuid().ToString()},
                            new Player() { ConnectionId = Guid.NewGuid().ToString()}
                        }
                    }
                }
            };
        }
    }
}
