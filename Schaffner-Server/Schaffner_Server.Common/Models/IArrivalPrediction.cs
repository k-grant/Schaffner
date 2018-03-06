using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.Models
{
    public interface IArrivalPrediction
    {
        IRoute Route { get; }

        int Minutes { get; }
    }
}
