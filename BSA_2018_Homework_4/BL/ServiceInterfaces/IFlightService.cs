using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface IFlightService
    {
		List<FlightDTO> GetFlightCollection();
		FlightDTO GetFlightById(int id);
		void DeleteFlightById(int id);
		void CreateFlight(FlightDTO item);
		void UpdateFlight(int id, FlightDTO item);
	}
}
