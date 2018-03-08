using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schaffner_Server.Common.Models;
using Schaffner_Server.ConductorService;
using Schaffner_Server.Repositories;

namespace Schaffner_Server.TransportationTimeTableService
{
    public class TransportationTimeTableService : ITransportationTimeTableService
    {
        private IConductorService _conductorService;
        private IBusSystemRepository _busSystemRepo;

        private List<int>[,] _timeTable;

        public TransportationTimeTableService(IBusSystemRepository busSystemRepo, IConductorService conductorService)
        {
            _conductorService = conductorService;
            _busSystemRepo = busSystemRepo;

            InitTimeTable();         
        }

        private void InitTimeTable()
        {

            IEnumerable<IRoute> routes = _busSystemRepo.GetRoutes().OrderBy(r => r.Id);
            IEnumerable<IStop> stops = _busSystemRepo.GetStops().OrderBy(s => s.Id);

            _timeTable = new List<int>[stops.Count(), routes.Count()];
            for(int i = 0; i< stops.Count(); i++)
            {
                var stop = stops.ElementAt(i);
                for(int j = 0; j < routes.Count(); j++)
                {
                    var route = routes.ElementAt(j);
                    int routeAndStopOffset = (j * 2) + (i * 2);
                    _timeTable[stop.Id-1, route.Id-1] = new List<int>() { 0  + routeAndStopOffset,
                                                                          15 + routeAndStopOffset,
                                                                          30 + routeAndStopOffset,
                                                                          45 + routeAndStopOffset
                                                                        };
                }
            }
        }

        public IEnumerable<IStop> GetAllStopsInfo(int? busPlanId = null)
        {
            return _busSystemRepo.GetStops(busPlanId);
        }

        public IStop GetStopInfo(int stopId)
        {
            return _busSystemRepo.GetStop(stopId);
        }

        public IEnumerable<IArrivalPrediction> GetStopPredictions(int stopId, int predictionsPerRoute, DateTime requestTime)
        {
            IStop stop = this.GetStopInfo(stopId);
            IEnumerable<IRoute> routes = _busSystemRepo.GetRoutes();

            var predictions = ReturnPredictionsForStopAndRoutes(stop, routes, requestTime, predictionsPerRoute);

            return predictions;
        }

        private IEnumerable<IArrivalPrediction> ReturnPredictionsForStopAndRoutes(IStop stop, IEnumerable<IRoute> routes, DateTime requestTime, int predictionsPerRoute)
        {
            var predictions = new List<IArrivalPrediction>();
            
            foreach (IRoute route in routes)
            {
                var etas = new List<int>();

                foreach (int arrivalTime in _timeTable[stop.Id - 1, route.Id - 1])
                {
                    int timeOffset = arrivalTime;
                    if (timeOffset <= requestTime.Minute)
                    {
                        timeOffset += 60;
                    }

                    etas.Add(timeOffset - requestTime.Minute);
                }

                var currRoutPred = new ArrivalPrediction(route, etas.OrderBy(s => s).Take(predictionsPerRoute));

                predictions.Add(currRoutPred);
            }

            return predictions;
        }

        public IEnumerable<IStopPrediction> GetAllStopPredictions(int predictionsPerRoute, DateTime requestTime)
        {
            IEnumerable<IStop> stops = this.GetAllStopsInfo();
            IEnumerable<IRoute> routes = this._busSystemRepo.GetRoutes();
            IList<IStopPrediction> stopPredictions = new List<IStopPrediction>();

            foreach (var stop in stops)
            {
                IEnumerable<IArrivalPrediction> arrivalPredictions = ReturnPredictionsForStopAndRoutes(stop, routes, requestTime, predictionsPerRoute);
                stopPredictions.Add(new StopPrediction(stop, arrivalPredictions));
            }

            return stopPredictions;
        }
    }
}
