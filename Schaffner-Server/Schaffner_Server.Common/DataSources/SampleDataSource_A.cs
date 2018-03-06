using Schaffner_Server.Common.Interfaces;
using Schaffner_Server.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.DataSources
{
    public class SampleDataSource_A : IBusSystemDataSource
    {
        public IEnumerable<IStop> Stops
        {
            get
            {
                return new IStop[]
              {
                    new Stop(1, "South Bound L - Lexington"),
                    new Stop(2, "South Bound L - Balamb"),
                    new Stop(3, "South Bound L - Xanarcand"),
                    new Stop(4, "South Bound L - Esther"),
                    new Stop(5, "South Bound L - Pomona"),
                    new Stop(6, "North Bound L - Pomona"),
                    new Stop(7, "North Bound L - Esther"),
                    new Stop(8, "North Bound L - Xanarcand"),
                    new Stop(9, "North Bound L - Balamb"),
                    new Stop(10, "North Bound L - Lexington")
              };
            }
        }

        public IEnumerable<IRoute> Routes
        {
            get
            {
                return new IRoute[]
              {
                    new Route(1,"RightOn15 Route",0),
                    new Route(2, "2MinAfter Route",0),
                    new Route(3, "4MinPast Route",0)
              };
            }
        }
    }
}
