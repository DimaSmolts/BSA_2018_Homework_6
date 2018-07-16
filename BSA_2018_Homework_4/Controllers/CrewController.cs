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
    //[Produces("application/json")]
    [Route("api/Crew")]
    public class CrewController : Controller
    {
		private ICrewService crewService;

		public CrewController(ICrewService crewService)
		{
			this.crewService = crewService;
		}

        // GET: api/Crew
        [HttpGet]
        public IEnumerable<CrewDTO> Get()
        {
			IEnumerable<CrewDTO> temp = crewService.GetCrewCollection();

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}

        // GET: api/Crew/5
        [HttpGet("{id}")]
        public CrewDTO Get(int id)
        {
            CrewDTO temp = crewService.GetCrewById(id);

			if (temp != null)			
				Response.StatusCode = 200;			
			else			
				Response.StatusCode = 404;

			return temp; 
			
        }
        
        // POST: api/Crew
        [HttpPost]
        public void Post([FromBody]CrewDTO crew)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				crewService.CreateCrew(crew);
			}
			else
			{
				Response.StatusCode = 400;
			}		
        }
        
        // PUT: api/Crew/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CrewDTO crew)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				crewService.UpdateCrew(id, crew);
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
			crewService.DeleteCrewById(id);
        }
    }
}
