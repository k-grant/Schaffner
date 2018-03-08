using Schaffner_Server.Common.Models;
using System;
using System.Collections.Generic;

namespace Schaffner_Server.Repositories
{
    public interface IBusSystemRepository
    {
        IEnumerable<IStop> GetStops(int? busPlanId = null);

        IStop GetStop(int stopId);

        IRoute GetRoute(int routeId);

        IEnumerable<IRoute> GetRoutes(int? busPlanId = null);

    }
}
