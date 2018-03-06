using NSubstitute;
using Schaffner_Server.ConductorService;
using Schaffner_Server.Controllers;
using Schaffner_Server.TransportationTimeTableService;
using Xunit;

namespace Schaffner_Server.Tests
{
    public class Server_Tests
    {
        [Fact]
        public void SchaffnerService_HappyPath()
        {
            var timeTable = Substitute.For<ITransportationTimeTableService>();

            StopsController sc = new StopsController(timeTable);
        }
    }
}
