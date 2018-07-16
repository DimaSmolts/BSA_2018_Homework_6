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
    [Route("api/PlaneType")]
    public class PlaneTypeController : Controller
    {
		private IPlaneTypeService planeTypeService;

		public PlaneTypeController(IPlaneTypeService planeTypeService)
		{
			this.planeTypeService = planeTypeService;
		}

        // GET: api/PlaneType
        [HttpGet]
        public IEnumerable<PlaneTypeDTO> Get()
        {
            IEnumerable<PlaneTypeDTO> temp = planeTypeService.GetPlaneTypeCollection();

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}

        // GET: api/PlaneType/5
        [HttpGet("{id}")]
        public PlaneTypeDTO Get(int id)
        {
            PlaneTypeDTO temp = planeTypeService.GetPlaneTypeById(id);

			if (temp != null)
				Response.StatusCode = 200;
			else
				Response.StatusCode = 404;

			return temp;
		}
        
        // POST: api/PlaneType
        [HttpPost]
        public void Post([FromBody]PlaneTypeDTO planeType)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				planeTypeService.CreatePlaneType(planeType);
			}
			else
			{
				Response.StatusCode = 400;
			}			
        }
        
        // PUT: api/PlaneType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PlaneTypeDTO planeType)
        {
			if (ModelState.IsValid)
			{
				Response.StatusCode = 200;
				planeTypeService.UpdatePlaneType(id, planeType);
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
			planeTypeService.DeletePlaneType(id);
        }
    }
}
