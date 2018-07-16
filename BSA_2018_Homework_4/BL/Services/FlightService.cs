using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using BSA_2018_Homework_4.DTOs;
using BSA_2018_Homework_4.DAL.Models;
using AutoMapper;

namespace BSA_2018_Homework_4.BL.Services
{
    public class FlightService : IFlightService
    {
		//private IFlightRepository flightRepository;

		private DAL.IUnitOfWork IunitOfWork;

		public FlightService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public void CreateFlight(FlightDTO item)
		{
			IunitOfWork.FlightRepository.Create(Mapper.Map<FlightDTO, Flight>(item));
		}

		public void DeleteFlightById(int id)
		{
			IunitOfWork.FlightRepository.Delete(id);
		}

		public FlightDTO GetFlightById(int id)
		{
			return Mapper.Map<Flight, FlightDTO>(IunitOfWork.FlightRepository.Get(id)); 
		}

		public List<FlightDTO> GetFlightCollection()
		{
			return Mapper.Map<List<Flight>, List<FlightDTO>>(IunitOfWork.FlightRepository.GetAll());
		}

		public void UpdateFlight(int id, FlightDTO item)
		{
			IunitOfWork.FlightRepository.Update(id,Mapper.Map<FlightDTO, Flight>(item));
		}
	}
}
