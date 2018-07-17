using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.Controllers
{
	[Route("api/Flight")]
	public class FlightController : Controller
    {
		private IFlightService flightService;

		public FlightController(IFlightService flightService)
		{
			this.flightService = flightService;
		}

		// GET: api/Flight
		[HttpGet]
		public IActionResult Get()
		{
			IEnumerable<FlightDTO> temp = flightService.GetFlightCollection();

			if (temp != null)
				return Ok(temp);
			else
				return NotFound();

			//return temp;
		}

		// GET: api/Flight/5
		[HttpGet("{id}")]
		public FlightDTO Get(int id)
		{
			FlightDTO temp = flightService.GetFlightById(id);

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}

		// POST: api/Flight
		[HttpPost]
		public void Post([FromBody]FlightDTO flight)
		{
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				flightService.CreateFlight(flight);
			}
			else
			{
				Response.StatusCode = 400;
			}			
		}

		// PUT: api/Flight/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]FlightDTO flight)
		{
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				flightService.UpdateFlight(id, flight);
			}
			else
			{
				Response.StatusCode = 400;
			}
		}

		// DELETE: api/Flight/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			flightService.DeleteFlightById(id);
		}
	}
}