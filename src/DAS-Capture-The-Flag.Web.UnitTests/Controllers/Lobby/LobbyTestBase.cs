using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAS_Capture_The_Flag.Web.UnitTests.Controllers.Lobby
{
    public class LobbyTestBase
    {
        protected IGameRepository Repository;
        protected IMediator Mediator;

        protected Guid PlayerId_1 = Guid.NewGuid();
        protected Guid PlayerId_2 = Guid.NewGuid();
        protected Guid GameId = Guid.NewGuid();

        [SetUp]
        public void Arrange()
        {
            Repository = Substitute.For<IGameRepository>();
            Mediator = Substitute.For<IMediator>();
        }
    }
}
