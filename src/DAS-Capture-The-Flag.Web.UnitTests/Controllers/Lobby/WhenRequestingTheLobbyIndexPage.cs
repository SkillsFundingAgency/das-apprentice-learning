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
        private LobbyController LobbyController;

        [SetUp]
        public void Arrange()
        {
            LobbyController = new LobbyController(Mediator, Logger);
        }

        [Test]
        public async Task ThenTheIndexViewIsReturned()
        {
            Mediator.Send(Arg.Any<JoinOrCreateGameCommand>()).Returns(new JoinOrCreateGameResponse(new Game()));
            
            var result = await LobbyController.Index(PlayerId_1);

            result.Should().BeOfType<ViewResult>();
        }

        [Test]
        public async Task AndTheGameIdIsInavalid_ThenTheUseIsRedirectedToAnErrorPage()
        {
            Mediator.Send(Arg.Any<JoinOrCreateGameCommand>()).Returns(new JoinOrCreateGameResponse(null));

            var result = await LobbyController.Index(PlayerId_1);

            result.Should().BeOfType<RedirectToActionResult>();
            result.As<RedirectToActionResult>().ControllerName.Should().Be("Error");
            result.As<RedirectToActionResult>().ActionName.Should().Be("Index");
        }
        
    }
}
