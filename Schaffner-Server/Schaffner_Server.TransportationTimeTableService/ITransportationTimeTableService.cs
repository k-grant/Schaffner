using Schaffner_Server.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.TransportationTimeTableService
{
    public interface ITransportationTimeTableService
    {
        IStop GetStopInfo(int stopId);
        IEnumerable<IStop> GetAllStopsInfo(int? busPlanId = null);
        IEnumerable<IArrivalPrediction> GetStopPredictions(int stopId, int predictionsPerRoute, DateTime requestTime);
    }
}
