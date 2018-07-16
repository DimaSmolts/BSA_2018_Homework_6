using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using BSA_2018_Homework_4.DAL.Repositories;

namespace BSA_2018_Homework_4.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
		private readonly MyContext context;

		private ICrewRepository crewRepository;
		private IFlightRepository flightRepository;
		private IPilotRepository pilotRepository;
		private IPlaneRepository planeRepository;
		private IPlaneTypeRepository planeTypeRepository;
		private IStewardessRepository stewardessRepository;
		private ITakeOffRepository takeOffRepository;
		private ITicketRepository ticketRepository;

		public UnitOfWork(ICrewRepository crewRepository,
							IFlightRepository flightRepository,
							IPilotRepository pilotRepository,
							IPlaneRepository planeRepository,
							IPlaneTypeRepository planeTypeRepository,
							IStewardessRepository stewardessRepository,
							ITakeOffRepository takeOffRepository,
							ITicketRepository ticketRepository,
							MyContext context)
		{
			this.crewRepository = crewRepository;
			this.flightRepository = flightRepository;
			this.pilotRepository = pilotRepository;
			this.planeRepository = planeRepository;
			this.planeTypeRepository = planeTypeRepository;
			this.stewardessRepository = stewardessRepository;
			this.takeOffRepository = takeOffRepository;
			this.ticketRepository = ticketRepository;

			this.context = context;
		}

		public ICrewRepository CrewRepository
		{
			get
			{
				if (crewRepository == null)
					crewRepository = new CrewRepository(context);
				return crewRepository;
			}
		}
		public IFlightRepository FlightRepository
		{
			get
			{
				if (flightRepository == null)
					flightRepository = new FlightRepository(context);
				return flightRepository;
			}
		}
		public IPilotRepository PilotRepository
		{
			get
			{
				if (pilotRepository == null)
					pilotRepository = new PilotRepository(context);
				return pilotRepository;
			}
		}
		public IPlaneRepository PlaneRepository
		{
			get
			{
				if (planeRepository == null)
					planeRepository = new PlaneRepository(context);
				return planeRepository;
			}
		}
		public IPlaneTypeRepository PlaneTypeRepository
		{
			get
			{
				if (planeTypeRepository == null)
					planeTypeRepository = new PlaneTypeRepository(context);
				return planeTypeRepository;
			}
		}
		public IStewardessRepository StewardessRepository
		{
			get
			{
				if (stewardessRepository == null)
					stewardessRepository = new StewardessRepository(context);
				return stewardessRepository;
			}
		}
		public ITakeOffRepository TakeOffRepository
		{
			get
			{
				if (takeOffRepository == null)
					takeOffRepository = new TakeOffRepository(context);
				return takeOffRepository;
			}
		}
		public ITicketRepository TicketRepository
		{
			get
			{
				if (ticketRepository == null)
					ticketRepository = new TicketRepository(context);
				return ticketRepository;
			}
		}
	}
}
