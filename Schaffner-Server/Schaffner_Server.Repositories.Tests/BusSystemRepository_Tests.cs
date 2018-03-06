using NSubstitute;
using Schaffner_Server.Common.Interfaces;
using Schaffner_Server.Common.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Schaffner_Server.Repositories.Tests
{
    public class BusSystemRepository_Tests
    {
        [Fact]
        public void GetStop_ThrowsInvalidOperationException_WhenStopRequestedDoesNotExist()
        {
            IStop stop = new Stop(1,"Test");
            
            IBusSystemDataSource dataSource = Substitute.For<IBusSystemDataSource>();
            dataSource.Stops.Returns(new List<IStop>() { stop });

            var repo = new BusSystemRepository(dataSource);

            Assert.Throws<InvalidOperationException>(() => repo.GetStop(2));
        }
    }
}
