using System;
using System.Collections.Generic;
using System.Text;
using Schaffner_Server.Common.Models;
using Schaffner_Server.Repositories;

namespace Schaffner_Server.ConductorService
{
    public class ConductorService : IConductorService
    {
        private IBusSystemRepository _busSysRepo;

        public ConductorService(IBusSystemRepository busSystemRepo)
        {
            _busSysRepo = busSystemRepo;
        }
        public IEnumerable<IStop> GetAllStops(int busPlanId)
        {
            return _busSysRepo.GetStops(busPlanId);
        }

        public IStop GetStop(int stopId)
        {
            return _busSysRepo.GetStop(stopId);
        }
    }
}
