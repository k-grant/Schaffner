using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.Models
{
    public class ArrivalPrediction : IArrivalPrediction
    {
        private IRoute _route;
        private IEnumerable<int> _minutes;

        public ArrivalPrediction(IRoute route, IEnumerable<int> minutes)
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

        public IEnumerable<int> Minutes
        {
            get
            {
                return _minutes;
            }
        }
    }
}
