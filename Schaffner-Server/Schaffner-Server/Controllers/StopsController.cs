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

        // GET: api/Stops - Gets All Stops info with predictions filled in
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<IStop> stops = _conductorService.GetAllStopsPredictions();

                return Ok(stops);
            }
            catch (Exception)
            {
                return BadRequest($"Server encountered an error returning all stops.");
            }
        }

        // GET: api/Stop/[stopId] - Get Individual Stop by stopId with predictions filled in
        [HttpGet]
        [Route("{stopId:int}")]
        public IActionResult Get(int stopId)
        {
            try
            {
                IStop stop = _conductorService.GetStopPredictions(stopId);
                return Ok(stop);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"{ex.Message}");
            }
            catch (Exception)
            {
                return BadRequest($"Server encountered an error returning stop with Id:{stopId}");
            }
        }

        // GET: api/Stops - Gets All Stops info
        [HttpGet]
        [Route("info")]
        public IActionResult GetInfo()
        {
            try
            {
                IEnumerable<IStop> stops = _conductorService.GetAllStops(1);

                return Ok(stops);
            }
            catch (Exception)
            {
                return BadRequest($"Server encountered an error returning all stops.");
            }
        }

        // GET: api/Stop/[stopId] - Get Individual Stop by stopId
        [HttpGet]
        [Route("info/{stopId:int}")]
        public IActionResult GetInfo(int stopId)
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
            catch (Exception)
            {
                return BadRequest($"Server encountered an error returning stop with Id:{stopId}");
            }
        }
    }
}
