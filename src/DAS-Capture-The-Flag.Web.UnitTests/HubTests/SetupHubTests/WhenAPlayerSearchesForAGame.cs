using System;
using System.Collections.Generic;
using System.Text;
using DAS_Capture_The_Flag;
using DAS_Capture_The_Flag.Hubs;
using NUnit.Framework;

namespace DAS_Capture_The_Flag.Web.UnitTests.HubTests.SetupHubTests
{
    [TestFixture]
    public class WhenAPlayerSearchesForAGame : SetupHubTestsBase
    {

        private SetupHub sut;

        [SetUp]
        public void Arrange()
        {
           
            sut = new SetupHub(GameRepository);
        }

        [Test]
        public void TheyCanConnect()
        {

            var result = sut.OnConnectedAsync();
        }
    }
}
