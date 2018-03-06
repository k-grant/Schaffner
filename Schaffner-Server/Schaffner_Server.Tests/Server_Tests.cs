using NSubstitute;
using Schaffner_Server.ConductorService;
using Schaffner_Server.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Schaffner_Server.Tests
{
    public class Server_Tests
    {
        [Fact]
        public void SchaffnerService_HappyPath()
        {
            var cndctr = Substitute.For<IConductorService>();

            StopsController sc = new StopsController(cndctr);
        }
    }
}
