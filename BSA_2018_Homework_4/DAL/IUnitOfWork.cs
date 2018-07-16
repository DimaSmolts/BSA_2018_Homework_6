using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;

namespace BSA_2018_Homework_4.DAL
{
    public interface IUnitOfWork
    {
		ICrewRepository CrewRepository { get; }
		IFlightRepository FlightRepository { get; }
		IPilotRepository PilotRepository { get; } 
		IPlaneRepository PlaneRepository { get; }
		IPlaneTypeRepository PlaneTypeRepository { get; }
		IStewardessRepository StewardessRepository { get; }
		ITakeOffRepository TakeOffRepository { get; }
		ITicketRepository TicketRepository { get; }
    }
}
