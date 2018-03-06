using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.Models
{
    public class ArrivalPrediction : IArrivalPrediction
    {
        private IRoute _route;
        private int _minutes;

        public ArrivalPrediction(IRoute route, int minutes)
        {
            _route = route;
            _minutes = minutes;
        }

        public IRoute Route
        {
            get
            {
                return _route;
            }
        }

        public int Minutes
        {
            get
            {
                return _minutes;
            }
        }
    }
}
