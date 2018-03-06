using Schaffner_Server.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schaffner_Server.Repositories
{
    public class BusSystemRepository : IBusSystemRepository
    {
        private readonly IEnumerable<IStop> _stops;

        public BusSystemRepository()
        {
            _stops = new IStop[]
            {
                new Stop(1, "South Bound L - Lexington"),
                new Stop(2, "South Bound L - Balamb"),
                new Stop(3, "South Bound L - Xanarcand"),
                new Stop(4, "South Bound L - Esther"),
                new Stop(5, "South Bound L - Pomona"),
                new Stop(6, "North Bound L - Pomona"),
                new Stop(7, "North Bound L - Esther"),
                new Stop(8, "North Bound L - Xanarcand"),
                new Stop(9, "North Bound L - Balamb"),
                new Stop(10, "North Bound L - Lexington")
            };
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
