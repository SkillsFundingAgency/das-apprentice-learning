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

            result.Should().BeOfType<ViewResult>();
        }

        [Test]
        public async Task AndTheGameIdIsInavalid_ThenTheUseIsRedirectedToAnErrorPage()
        {
            Mediator.Send(Arg.Any<JoinOrCreateGameCommand>()).Returns(new JoinOrCreateGameResponse(null));

            var result = await sut.Index(PlayerId_1);

            result.Should().BeOfType<RedirectToActionResult>();
            result.As<RedirectToActionResult>().ControllerName.Should().Be("Error");
            result.As<RedirectToActionResult>().ActionName.Should().Be("Index");
        }
        
    }
}
