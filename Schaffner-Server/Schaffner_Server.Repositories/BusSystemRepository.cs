using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Schaffner_Server.Common.Models;

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
            return _stops.Single(stop => stop.Id == stopId);
        }

        public IEnumerable<IStop> GetStops(int busPlanId)
        {
            return _stops;
        }
    }
}
