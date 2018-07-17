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
    public class CrewService : ICrewService
    {
		//private ICrewRepository crewRepository;
		private DAL.IUnitOfWork IunitOfWork;

		public CrewService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public void CreateCrew(CrewDTO item)
		{
			//Crew temp = new Crew();
			//temp.PilotId = IunitOfWork.PilotRepository.Get(item.PilotId);

			//List<Stewardess> tempS = IunitOfWork.StewardessRepository.GetAll();
			//List<Stewardess> selected = new List<Stewardess>();
			//foreach (Stewardess s in tempS)
			//{
			//	foreach (int i in item.StewardessIds)
			//	{
			//		if (s.Id == i)
			//			selected.Add(s);
			//}

			//}
			//temp.StewardessIds = selected;

			//if (temp.StewardessIds.Count == item.StewardessIds.Count() && temp.PilotId != null)
			//{
			//	IunitOfWork.CrewRepository.Create(temp);
			//}			


			IunitOfWork.CrewRepository.Create(Mapper.Map<CrewDTO,Crew>(item));

		}

		public void DeleteCrewById(int id)
		{
			IunitOfWork.CrewRepository.Delete(id);
		}

		public CrewDTO GetCrewById(int id)
		{


			return Mapper.Map<Crew, CrewDTO>(IunitOfWork.CrewRepository.Get(id));
		}

		public List<CrewDTO> GetCrewCollection()
		{
			//List<Crew> temp = IunitOfWork.CrewRepository.GetAll();
			//List<CrewDTO> selected = Mapper.Map<List<Crew>, List<CrewDTO>>(temp);

			//List<Stewardess> tempS = new List<Stewardess>();
			//List<Stewardess> stw = IunitOfWork.StewardessRepository.GetAll();

			//foreach 

			//List<CrewDTO> selected

			//List<CrewDTO> crewDTOs = Mapper.Map<List<Crew>, List<CrewDTO>>(IunitOfWork.CrewRepository.GetAll());

			return Mapper.Map<List<Crew>, List<CrewDTO>>(IunitOfWork.CrewRepository.GetAll());// crewDTOs;
		}

		public void UpdateCrew(int id, CrewDTO item)
		{
			IunitOfWork.CrewRepository.Update(id,Mapper.Map<CrewDTO, Crew>(item));
		}
	}
}
