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
        public async Task WhenRequestingAGame_ThenTheGameThatThePlayerIsInIsReturned()
        {
            Repository.Games = CreateTwoTestGames();

            var handler = new GetGameHandler(Repository);

            var result = await handler.Handle(new GetGameRequest(CorrectGameId), CancellationToken.None);

            result.Players.PlayerOne.Id.Should().Be(Player_1.Id);
        }

        private List<Game> CreateTwoTestGames()
        {
            return new List<Game> { 
                new Game { Id = IncorrectGameId, Players = { PlayerOne = new Player(), PlayerTwo = new Player { Id = Player_2.Id} } } ,
                new Game { Id = CorrectGameId,  Players = { PlayerOne = new Player() { Id = Player_1.Id }, PlayerTwo = new Player() } } 
            };
        }
    }
}
