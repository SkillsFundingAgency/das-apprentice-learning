using DAS_Capture_The_Flag.Application.Handlers.GetGame;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Application.UnitTests.Handlers.GetGame
{
    [TestFixture]
    public class GetGameHandlerTests : HandlersTestBase
    {

        [Test]
        public async Task WhenRequestingAGame_ThenTheGameThatThePlayerIsReturned()
        {
            Repository.Games = CreateTwoGames();

            var handler = new GetGameHandler(Repository);

            var result = await handler.Handle(new GetGameRequest(CorrectGameId), CancellationToken.None);

            result.Players.PlayerOne.Id.Should().Be(PlayerId_1);

        }

        private List<Game> CreateTwoGames()
        {
            return new List<Game> { 
                new Game { Id = IncorrectGameId, Players = { PlayerOne = new Player(), PlayerTwo = new Player { Id = PlayerId_2} } } ,
                new Game { Id = CorrectGameId,  Players = { PlayerOne = new Player() { Id = PlayerId_1 }, PlayerTwo = new Player() } } 
            };
        }
    }
}
