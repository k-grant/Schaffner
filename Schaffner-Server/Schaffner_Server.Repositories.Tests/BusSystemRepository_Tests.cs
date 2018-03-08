using AutoFixture;
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

        [Fact]
        public void GetStop_HappyPath_WhenStopRequestedDoesExist()
        {
            IStop stop = new Stop(1, "Test");

            IBusSystemDataSource dataSource = Substitute.For<IBusSystemDataSource>();
            dataSource.Stops.Returns(new List<IStop>() { stop });

            var repo = new BusSystemRepository(dataSource);

            Assert.Equal(repo.GetStop(1), stop);
        }


        [Fact]
        public void GetStops_HappyPath_WhenStopsRequestedMatchesDataSource()
        {
            var fix = new Fixture();
            IEnumerable<IStop> stops = fix.Create<List<Stop>>();

            IBusSystemDataSource dataSource = Substitute.For<IBusSystemDataSource>();
            dataSource.Stops.Returns(stops);

            var repo = new BusSystemRepository(dataSource);

            Assert.Equal(repo.GetStops(), stops);
        }


        [Fact]
        public void GetRoute_ThrowsInvalidOperationException_WhenRouteRequestedDoesNotExist()
        {
            IRoute route = new Route(1, "Test");

            IBusSystemDataSource dataSource = Substitute.For<IBusSystemDataSource>();
            dataSource.Routes.Returns(new List<IRoute>() { route });

            var repo = new BusSystemRepository(dataSource);

            Assert.Throws<InvalidOperationException>(() => repo.GetRoute(2));
        }

        [Fact]
        public void GetRoute_HappyPath_WhenStopRequestedDoesExist()
        {
            IRoute route = new Route(1, "Test");

            IBusSystemDataSource dataSource = Substitute.For<IBusSystemDataSource>();
            dataSource.Routes.Returns(new List<IRoute>() { route });

            var repo = new BusSystemRepository(dataSource);

            Assert.Equal(repo.GetRoute(1), route);
        }


        [Fact]
        public void GetRoutes_HappyPath_WhenStopsRequestedMatchesDataSource()
        {
            var fix = new Fixture();
            IEnumerable<IRoute> routes = fix.Create<List<Route>>();

            IBusSystemDataSource dataSource = Substitute.For<IBusSystemDataSource>();
            dataSource.Routes.Returns(routes);

            var repo = new BusSystemRepository(dataSource);

            Assert.Equal(repo.GetRoutes(), routes);
        }
    }
}
