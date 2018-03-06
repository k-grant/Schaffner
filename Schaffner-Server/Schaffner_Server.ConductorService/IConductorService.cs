using Schaffner_Server.Common.Models;
using System.Collections.Generic;

namespace Schaffner_Server.ConductorService
{
    public interface IConductorService
    {
        IEnumerable<IArrivalPrediction> CheckForDelays(IStop stop, IEnumerable<IRoute> routes);
    }
}
