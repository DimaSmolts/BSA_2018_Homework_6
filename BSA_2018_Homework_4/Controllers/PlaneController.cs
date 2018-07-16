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
    [Route("api/Plane")]
    public class PlaneController : Controller
    {
		private IPlaneService planeService;

		public PlaneController(IPlaneService planeService)
		{
			this.planeService = planeService;
		}

        // GET: api/Plane
        [HttpGet]
        public IEnumerable<PlaneDTO> Get()
        {
			IEnumerable<PlaneDTO> temp = planeService.GetPlaneCollection();

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}

        // GET: api/Plane/5
        [HttpGet("{id}")]
        public PlaneDTO Get(int id)
        {
			PlaneDTO temp = planeService.GetPlaneById(id);

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}
        
        // POST: api/Plane
        [HttpPost]
        public void Post([FromBody]PlaneDTO plane)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				planeService.CreatePlane(plane);
			}
			else
			{
				Response.StatusCode = 400;
			}			
        }
        
        // PUT: api/Plane/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PlaneDTO plane)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				planeService.UpdatePlane(id, plane);
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
			planeService.DeletePlaneById(id);
        }
    }
}
