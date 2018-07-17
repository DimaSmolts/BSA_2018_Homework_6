using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BSA_2018_Homework_4.DAL;
using BSA_2018_Homework_4.DAL.Repositories;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.BL.Services;
using BSA_2018_Homework_4.DTOs;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using BSA_2018_Homework_4.Controllers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BSA_2018_Homework_4;

namespace Tests.FunctionalTests
{
	[TestFixture]
    public class RealUserImitationTest
    {
		public RealUserImitationTest()
		{
			Mapper.Reset();
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Plane, PlaneDTO>()
				.ForMember(p => p.Type, dto => dto.Ignore());
				cfg.CreateMap<PlaneDTO, Plane>()
				.ForMember(dto => dto.Type, p => p.Ignore());

				cfg.CreateMap<Flight, FlightDTO>()
				.ForMember(f => f.FlightNum, dto => dto.MapFrom(src => src.FlightId));
				cfg.CreateMap<FlightDTO, Flight>()
				.ForMember(dto => dto.FlightId, f => f.MapFrom(src => src.FlightNum));

				cfg.CreateMap<Ticket, TicketDTO>()
				.ForMember(ti => ti.FlightNum, dto => dto.Ignore());
				cfg.CreateMap<TicketDTO, Ticket>()
				.ForMember(dto => dto.FlightNum, ti => ti.Ignore());

				cfg.CreateMap<Crew, CrewDTO>()
				.ForMember(c => c.PilotId, dto => dto.MapFrom(src => src.PilotId))
				.ForMember(c => c.StewardessIds, dto => dto.MapFrom(src => src.StewardessIds));
				cfg.CreateMap<CrewDTO, Crew>()
				.ForMember(dto => dto.StewardessIds, c => c.MapFrom(src => src.StewardessIds))
				.ForMember(dto => dto.PilotId, c => c.MapFrom(src => src.PilotId));

				cfg.CreateMap<Pilot, PilotDTO>();
				cfg.CreateMap<PilotDTO, Pilot>();

				cfg.CreateMap<Stewardess, StewardessDTO>();
				cfg.CreateMap<StewardessDTO, Stewardess>();

				cfg.CreateMap<TakeOff, TakeOffDTO>()
				.ForMember(dto => dto.PlaneId, to => to.MapFrom(src => src.PlaneId.Id))
				.ForMember(dto => dto.CrewId, to => to.MapFrom(src => src.CrewId.Id))
				.ForMember(dto => dto.FlightNum, to => to.MapFrom(src => src.FlightNum.FlightId));
				cfg.CreateMap<TakeOffDTO, TakeOff>()
				.ForMember(to => to.CrewId, dto => dto.Ignore())
				.ForMember(to => to.PlaneId, dto => dto.Ignore())
				.ForMember(to => to.FlightNum, dto => dto.Ignore());

				cfg.CreateMap<PlaneType, PlaneTypeDTO>();
				cfg.CreateMap<PlaneTypeDTO, PlaneType>();
			});
		}

		MyContext mc;
		PilotController pilotController;
		FlightController flightController;

		[SetUp]
		public void TestSetUp()
		{

			var connection = @"Server=DESKTOP-DMYTRO\SQLEXPRESS;Initial Catalog=Academy;Trusted_Connection=True;ConnectRetryCount=0";
			DbContextOptionsBuilder<MyContext> t = new DbContextOptionsBuilder<MyContext>();
			t.UseSqlServer(connection);
			mc = new MyContext(t.Options);

			CrewRepository crewRepository = new CrewRepository(mc);
			PilotRepository pilotRepository = new PilotRepository(mc);
			StewardessRepository stewardessRepository = new StewardessRepository(mc);
			FlightRepository flightRepository = new FlightRepository(mc);
			TicketRepository ticketRepository = new TicketRepository(mc);
			TakeOffRepository takeOffRepository = new TakeOffRepository(mc);
			PlaneRepository planeRepository = new PlaneRepository(mc);
			PlaneTypeRepository planeTypeRepository = new PlaneTypeRepository(mc);

			UnitOfWork unitOfWork = new UnitOfWork(crewRepository, flightRepository, pilotRepository,
													planeRepository, planeTypeRepository, stewardessRepository,
													takeOffRepository, ticketRepository, mc);

			CrewService crewService = new CrewService(unitOfWork);
			FlightService flightService = new FlightService(unitOfWork); 
			StewardessService stewardessService = new StewardessService(unitOfWork); 
			PilotService pilotService = new PilotService(unitOfWork); 
			TicketService ticketService = new TicketService(unitOfWork);
			TakeOffService takeOffService = new TakeOffService(unitOfWork);
			PlaneService planeService = new PlaneService(unitOfWork);
			PlaneTypeService planeTypeService = new PlaneTypeService(unitOfWork);

			

			pilotController = new PilotController(pilotService);
			flightController = new FlightController(flightService);
		}


		[TestCase]
		public void FirstUserCheck()
		{
			//
			var result = pilotController.Get(1);
			var okObj = result as OkObjectResult;
			var model = okObj.Value as PilotDTO;

			//
			Assert.AreEqual(model.Id, 1);
			Assert.AreEqual(model.Name, "Skyler");
			Assert.AreEqual(model.Surname, "Bunker");
		}

		[TestCase]
		public void FlightCount()
		{
			var result = flightController.Get();
			var okObj = result as OkObjectResult;
			var model = okObj.Value as List<FlightDTO>;


			Assert.AreNotEqual(0, model.Count);
		}

		[TestCase]
		public void BadPilotPost()
		{
			PilotDTO pilotDTO = null;


			var result = pilotController.Post(pilotDTO);
			var BadObj = result as BadRequestResult;			


			Assert.AreEqual(BadObj.StatusCode, 400);
		}


		[TestCase]
		public void GoodPilotPost()
		{
			PilotDTO pilotDTO = new PilotDTO()
			{
				Name = "pilotFromTest",
				Surname = "pilotFromTest",
				Birth = new DateTime(1234, 12, 31),
				Experience = new TimeSpan(0, 1, 2)
			};


			var result = pilotController.Post(pilotDTO);
			var okObject = result as OkObjectResult;

			Pilot pilotInDB = mc.Pilot.FirstOrDefault(p => p.Name == "pilotFromTest");


			Assert.AreEqual(okObject.StatusCode, 200);
			Assert.AreEqual(pilotDTO.Name, pilotInDB.Name);
			Assert.AreEqual(pilotDTO.Surname, pilotInDB.Surname);
			Assert.AreEqual(pilotDTO.Birth, pilotInDB.Birth);
			Assert.AreEqual(pilotDTO.Experience, pilotInDB.Experience);
		}

		[TestCase]
		public void GoodPilottoDelete()
		{
			Pilot pilotInDB = mc.Pilot.First(p => p.Name == "pilotFromTest");

			pilotController.Delete(pilotInDB.Id);

			Pilot search = mc.Pilot.FirstOrDefault(p => p.Name == "pilotFromTest");

			Assert.IsNull(search);			
		}

	}
}
