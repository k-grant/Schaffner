using Schaffner_Server.Common.Models;
using System.Collections.Generic;

namespace Schaffner_Server.ConductorService
{
    public interface IConductorService
    {
        IEnumerable<IStop> GetAllStops(int? busPlanId = null);
        IEnumerable<IStop> GetAllStopsPredictions(int? busPlanId = null);
        IStop GetStop(int stopId);
        IStop GetStopPredictions(int stopId);
    }
}
