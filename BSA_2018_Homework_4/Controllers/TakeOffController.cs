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
    [Route("api/TakeOff")]
    public class TakeOffController : Controller
    {
		private ITakeOffService takeOffService;

		public TakeOffController(ITakeOffService takeOffService)
		{
			this.takeOffService = takeOffService;
		}

        // GET: api/TakeOff
        [HttpGet]
        public IEnumerable<TakeOffDTO> Get()
        {
            IEnumerable<TakeOffDTO> temp = takeOffService.GetTakeOffCollection();

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}

        // GET: api/TakeOff/5
        [HttpGet("{id}")]
        public TakeOffDTO Get(int id)
        {
            TakeOffDTO temp = takeOffService.GetTakeOffById(id);

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}
        
        // POST: api/TakeOff
        [HttpPost]
        public void Post([FromBody]TakeOffDTO takeOff)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				takeOffService.CreateTakeOff(takeOff);
			}
			else
			{
				Response.StatusCode = 400;
			}			
        }
        
        // PUT: api/TakeOff/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TakeOffDTO takeOff)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				takeOffService.UpdateTakeOff(id, takeOff);
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
			takeOffService.DeleteTakeOffById(id);
        }
    }
}
