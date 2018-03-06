using Schaffner_Server.Common.Models;
using System;
using System.Collections.Generic;

namespace Schaffner_Server.ConductorService
{
    public interface IConductorService
    {
        IEnumerable<IStop> GetAllStops(int busPlanId);
        IStop GetStop(int stopId);
    }
}
