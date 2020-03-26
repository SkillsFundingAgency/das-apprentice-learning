using DAS_Capture_The_Flag.Models.Game;
using Microsoft.AspNet.SignalR;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace DAS_Capture_The_Flag.Web.UnitTests.HubTests
{
    public class HubsTestBase
    {
        protected IGameRepository GameRepository;

        protected string ConnectionId;
        protected string HubName;
        protected IConnection Connection;
        protected IPrincipal User;

        [SetUp]
        public void Arrange()
        {
            GameRepository = Substitute.For<IGameRepository>();
            User = Substitute.For<IPrincipal>();
            Connection = Substitute.For<IConnection>();

            
        }
    }
}
