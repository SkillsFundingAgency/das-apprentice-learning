﻿using DAS_Capture_The_Flag.Application.Handlers.UpdatePlayerReady;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Application.UnitTests.Handlers.UpdatePlayerReady
{
    [TestFixture]
    public class WhenAPlayerClicksTheyAreReady : HandlersTestBase
    {
       
        [Test]
        public async Task Then_TheirReadyStatusIsUpdatedToReady()
        {
            
            Repository.Games = CreateTestLobbyWithOneGameTwoPlayers_WhereBothPlayersAreNotReady();

            var handler = new UpdatePlayerReadyHandler(Repository);

            await handler.Handle(new UpdatePlayerReadyCommand(GameId, Player_1.Id), CancellationToken.None);

            Repository.Games.FirstOrDefault(g => g.Id == GameId).Players.PlayerOne.Ready.Should().Be(true);
        }
    
    }
}
