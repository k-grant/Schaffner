using Schaffner_Server.Common.Models;
using Schaffner_Server.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Schaffner_Server.ConductorService
{
    public class ConductorService : IConductorService
    {
        public IEnumerable<IArrivalPrediction> CheckForDelays(IStop stop, IEnumerable<IRoute> routes)
        {
            throw new System.NotImplementedException();
        }
    }
}
