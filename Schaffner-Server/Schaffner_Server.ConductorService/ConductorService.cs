using Schaffner_Server.Common.Models;
using Schaffner_Server.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Schaffner_Server.ConductorService
{
    public class ConductorService : IConductorService
    {
        private IBusSystemRepository _busSysRepo;

        public ConductorService(IBusSystemRepository busSystemRepo)
        {
            _busSysRepo = busSystemRepo;
        }
        public IEnumerable<IStop> GetAllStops(int? busPlanId = null)
        {
            return _busSysRepo.GetStops(busPlanId);
        }

        public IStop GetStop(int stopId)
        {
            return _busSysRepo.GetStop(stopId);
        }

        public IEnumerable<IStop> GetAllStopsPredictions(int? busPlanId = null)
        {
            IEnumerable<IStop> stops = _busSysRepo.GetStops(busPlanId);
            IEnumerable<IRoute> routes = _busSysRepo.GetRoutes();
            foreach(IStop stop in stops)
            {
                stop.Predictions = GetArrivalPredictions(stop, routes);
            }

            return stops;
        }

        public IStop GetStopPredictions(int stopId)
        {
            IStop stop = _busSysRepo.GetStop(stopId);
            IEnumerable<IRoute> routes = _busSysRepo.GetRoutes();
            List<IArrivalPrediction> predictions = new List<IArrivalPrediction>();

            stop.Predictions = GetArrivalPredictions(stop, routes);

            return stop;
        }

        private IEnumerable<IArrivalPrediction> GetArrivalPredictions(IStop stop, IEnumerable<IRoute> routes)
        {
            List<IArrivalPrediction> predictions = new List<IArrivalPrediction>();

            foreach (IRoute route in routes)
            {
                IEnumerable<int> nextArrivalMinutes = this.ReturnNextArrivalPredictionsTimes(route.Id, stop.Id);
                predictions.AddRange(nextArrivalMinutes.Select(s => new ArrivalPrediction(route, s)));
            }

            return predictions.OrderBy(s=>s.Minutes);
        }

        private IEnumerable<int> ReturnNextArrivalPredictionsTimes(int routeId, int stopId)
        {
            int fakeMathForNow = stopId * 2 + routeId * 2;
            return new List<int>() { stopId*2 + routeId*2, fakeMathForNow + 15 };
        }
    }
}
