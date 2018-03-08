using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Schaffner_Server.Common.Interfaces;
using Schaffner_Server.ConductorService;
using Schaffner_Server.Controllers;
using Schaffner_Server.Repositories;
using Schaffner_Server.TransportationTimeTableService;
using System;
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

            IActionResult result = sc.GetAllStopPredictions();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void SchaffnerService_CallErrors_ReturnsErrorResult()
        {

            var timeTable =Substitute.For<ITransportationTimeTableService>();
            timeTable.When(x => x.GetAllStopPredictions(Arg.Any<int>(),Arg.Any<DateTime>()))
                .Do(x => { throw new Exception(); });

            StopsController sc = new StopsController(timeTable);

            IActionResult result = sc.GetAllStopPredictions();

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void SchaffnerService_GetPredictionForStopCallErrors_ReturnsErrorResult()
        {
            Fixture f = new Fixture();
            var timeTable = Substitute.For<ITransportationTimeTableService>();
            timeTable.When(x => x.GetStopPredictions(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<DateTime>()))
                .Do(x => { throw new Exception(); });

            StopsController sc = new StopsController(timeTable);

            IActionResult result = sc.Get(f.Create<int>());

            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public void SchaffnerService_GetAllStopPredictionsCallErrors_WithKnownError_ReturnsErrorResult_WithExpectedMessage()
        {
            Fixture f = new Fixture();
            string message = f.Create<string>();

            var timeTable = Substitute.For<ITransportationTimeTableService>();
            timeTable.When(x => x.GetAllStopPredictions(Arg.Any<int>(), Arg.Any<DateTime>()))
                .Do(x => { throw new InvalidOperationException(message); });

            StopsController sc = new StopsController(timeTable);

            IActionResult result = sc.GetAllStopPredictions();

            var result2 = result as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(result2.Value, message);
        }

        [Fact]
        public void SchaffnerService_GetPredictionForStopCallErrors_WithKnownError_ReturnsErrorResult_WithExpectedMessage()
        {
            Fixture f = new Fixture();
            string message = f.Create<string>();

            var timeTable = Substitute.For<ITransportationTimeTableService>();
            timeTable.When(x => x.GetStopPredictions(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<DateTime>()))
                .Do(x => { throw new InvalidOperationException(message); });

            StopsController sc = new StopsController(timeTable);

            IActionResult result = sc.Get(f.Create<int>());

            var result2 = result as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(result2.Value, message);
        }
    }
}
