using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BSA_2018_Homework_4.DAL;
using BSA_2018_Homework_4.DAL.Repositories;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.BL.Services;
using BSA_2018_Homework_4.DTOs;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BSA_2018_Homework_4.Controllers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Tests.CreateUpdateTests.TicketTest
{
	[TestFixture]
    class TicketCreateUpdate
    {
		IUnitOfWork unitOfWork;
		FakeTicketRepository fakeTicketRepository;

		public TicketCreateUpdate()
		{
			Mapper.Reset();
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Plane, PlaneDTO>()
				.ForMember(p => p.Type, dto => dto.MapFrom(src => src.Type));
				cfg.CreateMap<PlaneDTO, Plane>()
				.ForMember(dto => dto.Type, p => p.MapFrom(src => src.Type));

				cfg.CreateMap<Flight, FlightDTO>()
				.ForMember(f => f.FlightNum, dto => dto.MapFrom(src => src.FlightId));
				cfg.CreateMap<FlightDTO, Flight>()
				.ForMember(dto => dto.FlightId, f => f.MapFrom(src => src.FlightNum));

				cfg.CreateMap<Ticket, TicketDTO>()
				.ForMember(t => t.FlightNum, dto => dto.MapFrom(src => src.FlightNum));
				cfg.CreateMap<TicketDTO, Ticket>()
				.ForMember(dto => dto.FlightNum, t => t.MapFrom(src => src.FlightNum));

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
				.ForMember(dto => dto.PlaneId, to => to.MapFrom(src => src.PlaneId))
				.ForMember(dto => dto.CrewId, to => to.MapFrom(src => src.CrewId))
				.ForMember(dto => dto.FlightNum, to => to.MapFrom(src => src.FlightNum));
				cfg.CreateMap<TakeOffDTO, TakeOff>()
				.ForMember(to => to.CrewId, dto => dto.MapFrom(src => src.CrewId))
				.ForMember(to => to.PlaneId, dto => dto.MapFrom(src => src.PlaneId))
				.ForMember(to => to.FlightNum, dto => dto.MapFrom(src => src.FlightNum));


				cfg.CreateMap<PlaneType, PlaneTypeDTO>();
				cfg.CreateMap<PlaneTypeDTO, PlaneType>();
			});
		}



		[SetUp]
		public void TicketSetUp()
		{
			var stewMock = new Mock<IStewardessRepository>();			
			var planeMock = new Mock<IPlaneRepository>();
			var planeTypeMock = new Mock<IPlaneTypeRepository>();
			var takeoffMock = new Mock<ITakeOffRepository>();
			var crewMock = new Mock<ICrewRepository>();
			var pilotMock = new Mock<IPilotRepository>();
			var flightMock = new Mock<IFlightRepository>();

			//Mock< DbContextOptionsBuilder<MyContext>> t = new Mock< DbContextOptionsBuilder<MyContext>>();
			DbContextOptionsBuilder<MyContext> t = new DbContextOptionsBuilder<MyContext>();
			var connection = @"Server=DESKTOP-DMYTRO\SQLEXPRESS;Initial Catalog=Academy;Trusted_Connection=True;ConnectRetryCount=0";
			t.UseSqlServer(connection);
			var cont = new MyContext(t.Options);

			fakeTicketRepository = new FakeTicketRepository();

			unitOfWork = new UnitOfWork(crewMock.Object, flightMock.Object, pilotMock.Object,
										planeMock.Object, planeTypeMock.Object, stewMock.Object,
										takeoffMock.Object, fakeTicketRepository, cont);
		}


		[TestCase]
		public void TicketCreate()
		{
			TicketService ticketService = new TicketService(unitOfWork);

			TicketDTO ticketDTO = new TicketDTO()
			{
				Price = 500,
				FlightNum = new FlightDTO()
				{
					DeperturePlace = "testing",
					ArrivalPlace = "test",
					DepartureTime = new DateTime(1, 4, 3),
					ArrivalTime = new DateTime(1, 3, 4)
				}
			};

			ticketService.CreateTicket(ticketDTO);
			Ticket ticket = fakeTicketRepository.Get(1);


			Assert.AreEqual(ticket.Price, ticketDTO.Price);

			Assert.AreEqual(ticket.FlightNum.DepartureTime, ticketDTO.FlightNum.DepartureTime);
			Assert.AreEqual(ticket.FlightNum.ArrivalTime, ticketDTO.FlightNum.ArrivalTime);
			Assert.AreEqual(ticket.FlightNum.ArrivalPlace, ticketDTO.FlightNum.ArrivalPlace);
			Assert.AreEqual(ticket.FlightNum.DeperturePlace, ticketDTO.FlightNum.DeperturePlace);
		}

		[TestCase]
		public void TicketUpdate()
		{
			TicketService ticketService = new TicketService(unitOfWork);

			TicketDTO ticketDTO = new TicketDTO()
			{
				Price = 500,
				FlightNum = new FlightDTO()
				{
					DeperturePlace = "testing",
					ArrivalPlace = "test",
					DepartureTime = new DateTime(1, 4, 3),
					ArrivalTime = new DateTime(1, 3, 4)
				}
			};

			ticketService.UpdateTicket(1,ticketDTO);
			Ticket ticket = fakeTicketRepository.Get(1);


			Assert.AreEqual(ticket.Price, ticketDTO.Price);

			Assert.AreEqual(ticket.FlightNum.DepartureTime, ticketDTO.FlightNum.DepartureTime);
			Assert.AreEqual(ticket.FlightNum.ArrivalTime, ticketDTO.FlightNum.ArrivalTime);
			Assert.AreEqual(ticket.FlightNum.ArrivalPlace, ticketDTO.FlightNum.ArrivalPlace);
			Assert.AreEqual(ticket.FlightNum.DeperturePlace, ticketDTO.FlightNum.DeperturePlace);
		}

	}
}
