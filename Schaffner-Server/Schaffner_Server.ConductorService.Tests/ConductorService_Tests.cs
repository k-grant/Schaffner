using NSubstitute;
using Schaffner_Server.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Schaffner_Server.ConductorService.Tests
{
    public class ConductorService_Tests
    {
        [Fact]
        public void ConductorService_HappyPath()
        {
            IBusSystemRepository repo = Substitute.For<IBusSystemRepository>();

            IConductorService condctrServ = new ConductorService(repo);
        }

    }
}
