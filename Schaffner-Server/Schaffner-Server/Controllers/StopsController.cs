using Microsoft.AspNetCore.Mvc;
using Schaffner_Server.Common.Models;
using Schaffner_Server.ConductorService;
using System;
using System.Collections.Generic;

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
        public IActionResult Get()
        {
            try
            {
                IEnumerable<IStop> stops = _conductorService.GetAllStops(1);

                return Ok(stops);
            }
            catch (Exception ex)
            {
                return BadRequest($"Server encountered an error returning all stops.");
            }
        }

        // GET: api/Stop/[stopId] - Get Individual Stop by stopId
        [HttpGet]
        [Route("{stopId:int}")]
        public IActionResult Get(int stopId)
        {
            try
            {
                IStop stop = _conductorService.GetStop(stopId);
                return Ok(stop);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Server encountered an error returning stop with Id:{stopId}");
            }
        }
    }
}
