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

namespace Tests.CreateUpdateTests.TakeOffTest
{
    class TakeOffCreateUpdate
    {
		IUnitOfWork unitOfWork;
		FakeTakeOffRepository fakeTakeOffRepository;

		public TakeOffCreateUpdate()
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
		public void TakeOffSetup()
		{
			var ticketMock = new Mock<ITicketRepository>();
			var planeMock = new Mock<IPlaneRepository>();
			var planeTypeMock = new Mock<IPlaneTypeRepository>();
			var flightMock = new Mock<IFlightRepository>();
			var crewMock = new Mock<ICrewRepository>();
			var pilotMock = new Mock<IPilotRepository>();
			var stewMock = new Mock<IStewardessRepository>();

			//Mock< DbContextOptionsBuilder<MyContext>> t = new Mock< DbContextOptionsBuilder<MyContext>>();
			DbContextOptionsBuilder<MyContext> t = new DbContextOptionsBuilder<MyContext>();
			var connection = @"Server=DESKTOP-DMYTRO\SQLEXPRESS;Initial Catalog=Academy;Trusted_Connection=True;ConnectRetryCount=0";
			t.UseSqlServer(connection);
			var cont = new MyContext(t.Options);

			fakeTakeOffRepository = new FakeTakeOffRepository();

			unitOfWork = new UnitOfWork(crewMock.Object, flightMock.Object, pilotMock.Object,
										planeMock.Object, planeTypeMock.Object, stewMock.Object,
										fakeTakeOffRepository, ticketMock.Object, cont);
		}

		[TestCase]
		public void TakeOffCreate()
		{
			TakeOffService takeOffService = new TakeOffService(unitOfWork);

			TakeOffDTO takeOffDTO = new TakeOffDTO()
			{
				Date = new DateTime(1, 2, 3),
				FlightNum = new FlightDTO()
				{
					DeperturePlace = "testing",
					ArrivalPlace = "test",
					DepartureTime = new DateTime(1, 4, 3),
					ArrivalTime = new DateTime(1, 3, 4)
				},
				PlaneId = new PlaneDTO()
				{
					Name = "test",
					Made = new DateTime(1, 2, 3),
					Exploitation = new TimeSpan(0, 1, 2),
					Type = new PlaneTypeDTO()
					{
						Model = "test",
						CarryCapacity = 12,
						Places = 15
					}
				},
				CrewId = new CrewDTO()
				{
					PilotId = new PilotDTO()
					{
						Name = "pilotCreateTest",
						Surname = "pilotCreateTest",
						Birth = new DateTime(1990, 1, 1),
						Experience = new TimeSpan(1, 2, 3)
					},
					StewardessIds = new StewardessDTO[]
					{
						new StewardessDTO()
						{
							Name = "stewCreateTest1",
							Surname = "stewCreateTest1",
							Birth = new DateTime(1990, 1, 1)
						},
						new StewardessDTO()
						{
							Name = "stewCreateTest2",
							Surname = "stewCreateTest2",
							Birth = new DateTime(1990, 1, 1)
						}
					}
				}
			};


			takeOffService.CreateTakeOff(takeOffDTO);
			TakeOff takeOff = fakeTakeOffRepository.Get(1);

			Assert.AreEqual(takeOff.Date, takeOffDTO.Date);
			Assert.AreEqual(takeOff.PlaneId.Name, takeOffDTO.PlaneId.Name);
			Assert.AreEqual(takeOff.CrewId.PilotId.Name, takeOffDTO.CrewId.PilotId.Name);
		}

		[TestCase]
		public void TakeOffUpdate()
		{
			TakeOffService takeOffService = new TakeOffService(unitOfWork);

			TakeOffDTO takeOffDTO = new TakeOffDTO()
			{
				Date = new DateTime(1, 2, 3),
				FlightNum = new FlightDTO()
				{
					DeperturePlace = "testing",
					ArrivalPlace = "test",
					DepartureTime = new DateTime(1, 4, 3),
					ArrivalTime = new DateTime(1, 3, 4)
				},
				PlaneId = new PlaneDTO()
				{
					Name = "test",
					Made = new DateTime(1, 2, 3),
					Exploitation = new TimeSpan(0, 1, 2),
					Type = new PlaneTypeDTO()
					{
						Model = "test",
						CarryCapacity = 12,
						Places = 15
					}
				},
				CrewId = new CrewDTO()
				{
					PilotId = new PilotDTO()
					{
						Name = "pilotCreateTest",
						Surname = "pilotCreateTest",
						Birth = new DateTime(1990, 1, 1),
						Experience = new TimeSpan(1, 2, 3)
					},
					StewardessIds = new StewardessDTO[]
					{
						new StewardessDTO()
						{
							Name = "stewCreateTest1",
							Surname = "stewCreateTest1",
							Birth = new DateTime(1990, 1, 1)
						},
						new StewardessDTO()
						{
							Name = "stewCreateTest2",
							Surname = "stewCreateTest2",
							Birth = new DateTime(1990, 1, 1)
						}
					}
				}
			};


			takeOffService.UpdateTakeOff(1,takeOffDTO);
			TakeOff takeOff = fakeTakeOffRepository.Get(1);

			Assert.AreEqual(takeOff.Date, takeOffDTO.Date);
			Assert.AreEqual(takeOff.PlaneId.Name, takeOffDTO.PlaneId.Name);
			Assert.AreEqual(takeOff.CrewId.PilotId.Name, takeOffDTO.CrewId.PilotId.Name);
		}
	}
}
