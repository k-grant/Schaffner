using Schaffner_Server.Common.Interfaces;
using Schaffner_Server.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schaffner_Server.Repositories
{
    public class BusSystemRepository : IBusSystemRepository
    {
        private readonly IEnumerable<IStop> _stops;
        private readonly IEnumerable<IRoute> _routes;


        public BusSystemRepository(IBusSystemDataSource dataSource)
        {
            _stops = dataSource.Stops;
            _routes = dataSource.Routes;
        }

        public IRoute GetRoute(int routeId)
        {
            IRoute route = _routes.SingleOrDefault(s => s.Id == routeId);

            if (route == null)
                throw new InvalidOperationException($"No routes found with id matching Id : {routeId}");

            return route;
        }

        public IEnumerable<IRoute> GetRoutes(int? busPlanId = null)
        {
            IEnumerable<IRoute> routes = _routes;

            return routes;
        }

        public IStop GetStop(int stopId)
        {
            IStop stop = _stops.SingleOrDefault(s => s.Id == stopId);

            if (stop == null)
                throw new InvalidOperationException($"No stops found with id matching Id : {stopId}");

            return stop;
        }

        public IEnumerable<IStop> GetStops(int? busPlanId = null)
        {
            IEnumerable<IStop> stops = _stops;

            return _stops;
        }
    }
}
