using Microsoft.AspNetCore.Mvc;
using Schaffner_Server.Common.Models;
using Schaffner_Server.ConductorService;
using Schaffner_Server.TransportationTimeTableService;
using System;
using System.Collections.Generic;

namespace Schaffner_Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Stops")]
    public class StopsController : Controller
    {
        private ITransportationTimeTableService _timeTableService;

        public StopsController(ITransportationTimeTableService timeTableService)
        {
            _timeTableService = timeTableService;
        }

        // GET: api/Stop/[stopId] - Get Individual Stop by stopId with predictions filled in
        [HttpGet]
        [Route("{stopId:int}")]
        public IActionResult Get(int stopId)
        {
            try
            {
                IEnumerable<IArrivalPrediction> stop = _timeTableService.GetStopPredictions(stopId, 2, DateTime.Now);
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
                IEnumerable<IStop> stops = _timeTableService.GetAllStopsInfo();

                return Ok(stops);
            }
            catch (Exception)
            {
                return BadRequest($"Server encountered an error returning all stops info.");
            }
        }

        // GET: api/Stop/[stopId] - Get Individual Stop by stopId
        [HttpGet]
        [Route("info/{stopId:int}")]
        public IActionResult GetInfo(int stopId)
        {
            try
            {
                IStop stop = _timeTableService.GetStopInfo(stopId);
                return Ok(stop);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"{ex.Message}");
            }
            catch (Exception)
            {
                return BadRequest($"Server encountered an error returning stop info with Id:{stopId}");
            }
        }
    }
}
