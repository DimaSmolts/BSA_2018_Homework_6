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
    public class PilotService : IPilotService
    {
		//private IPilotRepository pilotRepo;
		private DAL.IUnitOfWork IunitOfWork;

		public PilotService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public void CreatePilot(PilotDTO item)
		{
			IunitOfWork.PilotRepository.Create(Mapper.Map<PilotDTO, Pilot>(item));
		}

		public void DeletePilotById(int id)
		{
			IunitOfWork.PilotRepository.Delete(id);
		}

		public PilotDTO GetPilotById(int id)
		{
			return Mapper.Map<Pilot,PilotDTO>(IunitOfWork.PilotRepository.Get(id));
		}

		public List<PilotDTO> GetPilotCollection()
		{
			return Mapper.Map<List<Pilot>, List<PilotDTO>>(IunitOfWork.PilotRepository.GetAll());
		}

		public void UpdatePilot(int id, PilotDTO item)
		{
			IunitOfWork.PilotRepository.Update(id, Mapper.Map<PilotDTO, Pilot>(item));
		}
	}
}
