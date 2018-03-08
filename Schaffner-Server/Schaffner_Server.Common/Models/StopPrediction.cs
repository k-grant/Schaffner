using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.Models
{
    public class StopPrediction : IStopPrediction
    {
        private IStop _stop;
        private IEnumerable<IArrivalPrediction> _predictions;

        public StopPrediction(IStop stop, IEnumerable<IArrivalPrediction> predictions)
        {
            _stop = stop;
            _predictions = predictions;
        }

        public IStop Stop
        {
            get
            {
                return _stop;
            }
        }


        public IEnumerable<IArrivalPrediction> Predictions {
            get
            {
                return _predictions;
            }
        }
    }
}
