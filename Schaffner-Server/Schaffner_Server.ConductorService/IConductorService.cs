using Schaffner_Server.Common.Models;
using System.Collections.Generic;

namespace Schaffner_Server.ConductorService
{
    public interface IConductorService
    {
        //this service would handle the volatility of schedule changes, never got this far
        IEnumerable<IArrivalPrediction> CheckForDelays(IStop stop, IEnumerable<IRoute> routes);
    }
}
