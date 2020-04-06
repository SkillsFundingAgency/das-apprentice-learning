using DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Web.UnitTests.Controllers.Lobby
{
    [TestFixture]
    public class WhenRequestingTheLobbyIndexPage : LobbyTestBase
    {
        private LobbyController sut;

        [SetUp]
        public void Arrange()
        {
            sut = new LobbyController(Mediator);
        }

        [Test]
        public async Task ThenTheCorrectViewIsReturned()
        {
            Mediator.Send(Arg.Any<JoinOrCreateGameCommand>()).Returns(new JoinOrCreateGameResponse(new Game()));
            
            var result = await sut.Index(PlayerId_1);

            result.As<ViewResult>().ViewName.Should().Be("~/Views/Lobby/Index.cshtml");
        }
        
    }
}
