﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.Controllers
{
    //[Produces("application/json")]
    [Route("api/Pilot")]
    public class PilotController : Controller
    {
		private IPilotService pilotService;

		public PilotController(IPilotService pilotService)
		{
			this.pilotService = pilotService;
		}

        // GET: api/Pilot
        [HttpGet]
        public IEnumerable<PilotDTO> Get()
        {
			IEnumerable<PilotDTO> temp = pilotService.GetPilotCollection();

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
        }

        // GET: api/Pilot/5
        [HttpGet("{id}")]
        public PilotDTO Get(int id)
        {
            PilotDTO temp = pilotService.GetPilotById(id);

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}
        
        // POST: api/Pilot
        [HttpPost]
        public void Post([FromBody]PilotDTO pilot)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				pilotService.CreatePilot(pilot);
			}
			else
			{
				Response.StatusCode = 400;
			}
		}
        
        // PUT: api/Pilot/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PilotDTO pilot)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				pilotService.UpdatePilot(id, pilot);
			}
			else
			{
				Response.StatusCode = 400;
			}		
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			pilotService.DeletePilotById(id);
        }
    }
}
