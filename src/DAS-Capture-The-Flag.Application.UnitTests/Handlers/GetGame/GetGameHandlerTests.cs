using DAS_Capture_The_Flag.Application.Handlers.GetGame;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Application.UnitTests.Handlers.GetGame
{
    [TestFixture]
    public class GetGameHandlerTests : HandlersTestBase
    {

        [Test]
        public async Task WhenRequestingAGame_ThenTheCorrectGameIsReturned()
        {
            Repository.Games = CreateTwoGames();

            var handler = new GetGameHandler(Repository);

            var result = await handler.Handle(new GetGameRequest(CorrectGameId), CancellationToken.None);

            result.Setup.Players[0].Id.Should().Be(PlayerId_1);

        }

        private List<Game> CreateTwoGames()
        {
            return new List<Game> { 
                new Game { Id = IncorrectGameId, Setup = new GameSetup { Players = new List<Player> { new Player { Id = PlayerId_2} } } },
                new Game { Id = CorrectGameId, Setup = new GameSetup { Players = new List<Player> { new Player { Id = PlayerId_1 } } } }
            };
        }
    }
}
