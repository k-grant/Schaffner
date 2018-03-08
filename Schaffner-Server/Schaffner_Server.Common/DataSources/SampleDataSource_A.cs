using Schaffner_Server.Common.Interfaces;
using Schaffner_Server.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.DataSources
{
    public class SampleDataSource_A : IBusSystemDataSource
    {
        private readonly string[] stops = new string[] { "South Bound L - Lexington",
                                                                "South Bound L - Balamb",
                                                                "South Bound L - Xanarcand",
                                                                "South Bound L - Esther",
                                                                "South Bound L - Pomona",
                                                                "North Bound L - Pomona",
                                                                "North Bound L - Esther",
                                                                "North Bound L - Xanarcand" ,
                                                                "North Bound L - Balamb" ,
                                                                "North Bound L - Lexington" };

        private readonly string[] routes = new string[] { "RightOn15 Route", "2MinAfter Route", "4MinPast Route", "6MinPast Route" }; 

        public IEnumerable<IStop> Stops
        {
            get
            {
                List<IStop> listOfStops = new List<IStop>();
                for(int i = 1; i<= stops.Length; i++)
                {
                    listOfStops.Add(new Stop(i, stops[i - 1]));
                }

                return listOfStops;
            }
        }

        public IEnumerable<IRoute> Routes
        {
            get
            {
                List<IRoute> listOfRoutes = new List<IRoute>();
                for (int i = 1; i <= routes.Length; i++)
                {
                    listOfRoutes.Add(new Route(i, routes[i - 1]));
                }

                return listOfRoutes;
            }
        }
    }
}
