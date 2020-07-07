using DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using FluentAssertions;

namespace DAS_Capture_The_Flag.Application.UnitTests.Handlers.JoinOrCreateGame
{
    [TestFixture]
    public class When_RequestingToStartANewGame : HandlersTestBase
    {
        [Test]  
        public async Task And_NoGamesExist_Then_ANewGameIsCreated()
        {
            Repository.Games = CreateTestEmptyLobby();

            var handler = new JoinOrCreateGameHandler(Repository);

            await handler.Handle(new JoinOrCreateGameCommand(Player_1), CancellationToken.None);

            Repository.Games.Count.Should().Be(1);
        }

        [Test]
        public async Task And_AGamesExistWithASpace_Then_ANewGameIsNotCreated()
        {
            Repository.Games = CreateTestLobbyWithOneGameAndOnePlayerWaitingForAnOpponent();

            var handler = new JoinOrCreateGameHandler(Repository);

            await handler.Handle(new JoinOrCreateGameCommand(Player_1), CancellationToken.None);

            Repository.Games.Count.Should().Be(1);
        }

        [Test]
        public async Task And_APlayerIsAlreadyInTheLobby_Then_APlayersIdIsAdded()
        {
            Repository.Games = CreateTestLobbyWithOneGameAndOnePlayerWaitingForAnOpponent();

            var handler = new JoinOrCreateGameHandler(Repository);

            await handler.Handle(new JoinOrCreateGameCommand(Player_2), CancellationToken.None);

            Repository.Games[0].Players.PlayerTwo.Id.Should().Be(Player_2.Id);

        }

        [Test]
        public async Task AndThePlayerIsJoiningAnExistingGame_ThenPlayersConnectedPropertySetToTrue()
        {
            Repository.Games = CreateTestLobbyWithOneGameAndOnePlayerWaitingForAnOpponent();

            var handler = new JoinOrCreateGameHandler(Repository);

            await handler.Handle(new JoinOrCreateGameCommand(Player_1), CancellationToken.None);

            Repository.Games[0].PlayersConnected.Should().Be(true);
        }
    }
}
