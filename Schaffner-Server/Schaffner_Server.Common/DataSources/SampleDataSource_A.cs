using Schaffner_Server.Common.Interfaces;
using Schaffner_Server.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.DataSources
{
    public class SampleDataSource_A : IBusSystemDataSource
    {
        private readonly string[] stops = new string[] { "Lexington",
                                                                "Balamb",
                                                                "Xanarcand",
                                                                "Esther",
                                                                "Pomona",
                                                                "Hyrule",
                                                                "Esther",
                                                                "45th St." ,
                                                                "97th St." ,
                                                                "Downtown" };

        private readonly string[] routes = new string[] { "Express Route Davis", "Hilltop", "Queens Express"}; 

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
