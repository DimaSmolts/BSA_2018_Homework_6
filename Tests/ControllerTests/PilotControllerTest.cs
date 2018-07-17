using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BSA_2018_Homework_4.Controllers;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DTOs;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using BSA_2018_Homework_4.DAL;
using BSA_2018_Homework_4.DAL.Models;

using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Tests
{
	[TestFixture]
    public class PilotControllerTest
    {
		[TestCase]
		public void CheckPilotListTest()
		{
			// Arrange
			var serviceMock = new Mock<IPilotService>();
			serviceMock.Setup(a => a.GetPilotCollection()).Returns(new List<PilotDTO>() { new PilotDTO(),new PilotDTO()});
			PilotController controller = new PilotController(serviceMock.Object);

			// Act			
			var result = controller.Get();

			// Assert
			var okObjresult = result as OkObjectResult;
			var model = okObjresult.Value as List<PilotDTO>;

			Assert.IsNotNull(model);
			Assert.AreEqual(model.Count, 2);

		}

		[TestCase]
		public void CheckPilotId()
		{
			// Arrange
			List<PilotDTO> list = new List<PilotDTO>()
			{
				new PilotDTO()
				{
					Id = 1
				},
				new PilotDTO()
				{
					Id = 2
				},
				new PilotDTO()
				{
					Id = 3,
					Name = "Dima"
				},
				new PilotDTO()
				{
					Id = 4
				}
			};
			int index = 3;
			var serviceMock = new Mock<IPilotService>();
			serviceMock.Setup(a => a.GetPilotById(index)).Returns(list.Find( e => e.Id == index));
			PilotController controller = new PilotController(serviceMock.Object);

			// Act
			var result = controller.Get(index);

			// Assert

			var okObj = result as OkObjectResult;
			var model = okObj.Value as PilotDTO;
			Assert.AreEqual("Dima",model.Name);
			Assert.AreEqual(index, model.Id);
		}

		[TestCase]
		public void PostPilotTest()
		{
			// Arrange
			var serviceMock = new Mock<IPilotService>();			
			PilotController controller = new PilotController(serviceMock.Object);

			// Act
			var result = controller.Post(null) as BadRequestResult;

			// Assert
			Assert.AreEqual(400, result.StatusCode);
	
		}		
	}
}
