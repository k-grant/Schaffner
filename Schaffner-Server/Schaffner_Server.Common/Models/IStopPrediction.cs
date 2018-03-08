using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.Models
{
    public interface IStopPrediction
    {
        IStop Stop { get; }

        IEnumerable<IArrivalPrediction> Predictions { get; }

    }
}
