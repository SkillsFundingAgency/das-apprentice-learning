using DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using System.Threading;
using FluentAssertions;

namespace DAS_Capture_The_Flag.Application.UnitTests.Handlers.JoinOrCreateGame
{
    [TestFixture]
    public class When_RequestingToStartANewGame : HandlersTestBase
    {
        [SetUp]
        public void Arrange()
        {
            
        }

        [Test]  
        public async Task And_NoGamesExist_Then_ANewGameIsCreated()
        {
            Repository.Games = CreateEmptyLobby();

            var handler = new JoinOrCreateGameHandler(Repository);

            await handler.Handle(new JoinOrCreateGameCommand(PlayerId_1), CancellationToken.None);

            Repository.Games.Count.Should().Be(1);
        }

        [Test]
        public async Task And_AGamesExistWithASpace_Then_ANewGameIsNotCreated()
        {
            Repository.Games = CreateLobbyOneGameOnePlayer();

            var handler = new JoinOrCreateGameHandler(Repository);

            await handler.Handle(new JoinOrCreateGameCommand(PlayerId_1), CancellationToken.None);

            Repository.Games.Count.Should().Be(1);
        }

        [Test]
        public async Task And_APlayerIsAlreadyInTheLobby_Then_APlayersIdIsAdded()
        {
            Repository.Games = CreateLobbyOneGameOnePlayer();

            var handler = new JoinOrCreateGameHandler(Repository);

            await handler.Handle(new JoinOrCreateGameCommand(PlayerId_1), CancellationToken.None);

            Repository.Games[0].Setup.Players[1].Id.Should().Be(PlayerId_1);

        }

        [Test]
        public async Task AndThePlayerIsJoiningAnExistingGame_ThenPlayersConnectedPropertySetToTrue()
        {
            Repository.Games = CreateLobbyOneGameOnePlayer();

            var handler = new JoinOrCreateGameHandler(Repository);

            await handler.Handle(new JoinOrCreateGameCommand(PlayerId_1), CancellationToken.None);

            Repository.Games[0].Setup.PlayersConnected.Should().Be(true);
        }

       
    }
}
