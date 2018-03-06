using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schaffner_Server.Common.Models;
using Schaffner_Server.ConductorService;

namespace Schaffner_Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Stops")]
    public class StopsController : Controller
    {
        private IConductorService _conductorService;

        public StopsController(IConductorService conductorService)
        {
            _conductorService = conductorService;
        }

        // GET: api/Stops - Gets All Stops
        [HttpGet]
        public IEnumerable<IStop> Get()
        {
            IEnumerable<IStop> stops = _conductorService.GetAllStops(1);
            return stops;
        }

        // GET: api/Stop/[stopId] - Get Individual Stop by stopId
        [HttpGet]
        [Route("{stopId:int}")]
        public IStop Get(int stopId)
        {
            IStop stop = _conductorService.GetStop(stopId);
            return stop;
        }            
    }
}
