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
    [Route("api/Stewardess")]
    public class StewardessController : Controller
    {
		private IStewardessService stewardessService;

		public StewardessController(IStewardessService stewardessService)
		{
			this.stewardessService = stewardessService; 
		}

        // GET: api/Stewardess
        [HttpGet]
        public IEnumerable<StewardessDTO> Get()
        {
            IEnumerable<StewardessDTO> temp = stewardessService.GetStewardessCollection();

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}

        // GET: api/Stewardess/5
        [HttpGet("{id}")]
        public StewardessDTO Get(int id)
        {
			StewardessDTO temp = stewardessService.GetStewardessById(id);

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}
        
        // POST: api/Stewardess
        [HttpPost]
        public void Post([FromBody]StewardessDTO stewardess)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				stewardessService.CreateStewardess(stewardess);
			}
			else
			{
				Response.StatusCode = 400;
			}		
        }
        
        // PUT: api/Stewardess/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]StewardessDTO stewardess)
		{
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				stewardessService.UpdateStewardess(id, stewardess);
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
			stewardessService.DeleteStewardessById(id);
        }
    }
}
