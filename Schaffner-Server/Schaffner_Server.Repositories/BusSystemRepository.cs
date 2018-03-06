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

        public BusSystemRepository(IBusSystemDataSource dataSource)
        {
            _stops = dataSource.Stops;
        }

        public IStop GetStop(int stopId)
        {
            try
            {
                IStop stop = _stops.SingleOrDefault(s => s.Id == stopId);

                if (stop == null)
                    throw new InvalidOperationException($"No stops found with id matching Id : {stopId}");

                return stop;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<IStop> GetStops(int busPlanId)
        {
            return _stops;
        }
    }
}
