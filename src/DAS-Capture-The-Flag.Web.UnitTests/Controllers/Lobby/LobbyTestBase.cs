using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;

namespace DAS_Capture_The_Flag.Web.UnitTests.Controllers.Lobby
{
    public class LobbyTestBase
    {
        protected IGameRepository Repository;
        protected IMediator Mediator;
        protected ILogger Logger;

        protected Guid PlayerId_1 = Guid.NewGuid();
        protected Guid PlayerId_2 = Guid.NewGuid();
        protected Guid GameId = Guid.NewGuid();

        [SetUp]
        public void Arrange()
        {
            Repository = Substitute.For<IGameRepository>();
            Mediator = Substitute.For<IMediator>();
            Logger = Substitute.For<ILogger>();
        }
    }
}
