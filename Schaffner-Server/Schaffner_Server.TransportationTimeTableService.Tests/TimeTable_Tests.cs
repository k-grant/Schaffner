using AutoFixture;
using NSubstitute;
using Schaffner_Server.Common.Interfaces;
using Schaffner_Server.Common.Models;
using Schaffner_Server.ConductorService;
using Schaffner_Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Schaffner_Server.TransportationTimeTableService.Tests
{
    public class TimeTable_Tests
    {
        [Fact]
        public void SchaffnerService_HappyPath()
        {
            var cndctr = Substitute.For<IConductorService>();
            var repo = Substitute.For<IBusSystemRepository>();

            ITransportationTimeTableService sc = new TransportationTimeTableService(repo,cndctr);
        }

        [Fact]
        public void SchaffnerService_Builds_TimesTable_HappyPath()
        {
            var cndctr = Substitute.For<IConductorService>();

            var fix = new Fixture();
            IList<Route> routes = new List<Route>() { new Route(1, "testRoute1"), new Route(2, "testRoute2"), new Route(3, "testRoute3") };
            IList<Stop> stops = new List<Stop>() { new Stop(1, "testStop1"), new Stop(2, "testStop2"), new Stop(3, "testStop3") };

            IBusSystemDataSource dataSource = Substitute.For<IBusSystemDataSource>();
            dataSource.Routes.Returns(routes);
            dataSource.Stops.Returns(stops);

            var repo = new BusSystemRepository(dataSource);

            ITransportationTimeTableService sc = new TransportationTimeTableService(repo, cndctr);
        }

        [Fact]
        public void SchaffnerService_Stop1_GetPredictions_ReturnsAppropriatePredictions()
        {
            var cndctr = Substitute.For<IConductorService>();

            var fix = new Fixture();
            IList<Route> routes = new List<Route>() { new Route(1, "testRoute1"), new Route(2, "testRoute2"), new Route(3, "testRoute3") };
            IList<Stop> stops = new List<Stop>() { new Stop(1, "testStop1"), new Stop(2, "testStop2"), new Stop(3, "testStop3") };

            IBusSystemDataSource dataSource = Substitute.For<IBusSystemDataSource>();
            dataSource.Routes.Returns(routes);
            dataSource.Stops.Returns(stops);

            var repo = new BusSystemRepository(dataSource);

            ITransportationTimeTableService sc = new TransportationTimeTableService(repo, cndctr);

            IEnumerable<IArrivalPrediction> preds = sc.GetStopPredictions(1, 2, DateTime.Now);

            Assert.Equal(3, preds.Count());
            Assert.True(preds.ElementAt(0).Route.Id == 1);
        }

        [Fact]
        public void SchaffnerService_Stop1_GetAllPredictions_ReturnsAppropriatePredictions()
        {
            var cndctr = Substitute.For<IConductorService>();

            var fix = new Fixture();
            IList<Route> routes = new List<Route>() { new Route(1, "testRoute1"), new Route(2, "testRoute2"), new Route(3, "testRoute3") };
            IList<Stop> stops = new List<Stop>() { new Stop(1, "testStop1"), new Stop(2, "testStop2"), new Stop(3, "testStop3") };

            IBusSystemDataSource dataSource = Substitute.For<IBusSystemDataSource>();
            dataSource.Routes.Returns(routes);
            dataSource.Stops.Returns(stops);

            var repo = new BusSystemRepository(dataSource);

            ITransportationTimeTableService sc = new TransportationTimeTableService(repo, cndctr);

            IEnumerable<IStopPrediction> preds = sc.GetAllStopPredictions(2, DateTime.Now);

            Assert.Equal(3, preds.Count());
        }
    }
}
