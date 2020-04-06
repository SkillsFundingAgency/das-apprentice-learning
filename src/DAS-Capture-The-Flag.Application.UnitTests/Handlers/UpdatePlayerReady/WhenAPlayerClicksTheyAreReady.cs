using DAS_Capture_The_Flag.Application.Handlers.UpdatePlayerReady;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Application.UnitTests.Handlers.UpdatePlayerReady
{
    [TestFixture]
    public class WhenAPlayerClicksTheyAreReady : HandlersTestBase
    {
        [SetUp]
        public void Arrange()
        {

        }

        [Test]
        public async Task Then_TheirConnectedStatusIsUpdated()
        {
            Repository.Games = CreateLobbyOneGameTwoPlayers_BothNotReady();

            var handler = new UpdatePlayerReadyHandler(Repository);

            await handler.Handle(new UpdatePlayerReadyCommand(GameId, PlayerId_1), CancellationToken.None);
        }
    
    }
}
