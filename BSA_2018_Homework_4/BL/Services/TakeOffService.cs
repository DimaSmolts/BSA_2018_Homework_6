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
    public class TakeOffService : ITakeOffService
    {
		private DAL.IUnitOfWork IunitOfWork;

		public TakeOffService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public void CreateTakeOff(TakeOffDTO item)
		{
			//TakeOff temp = Mapper.Map<TakeOffDTO, TakeOff>(item);
			//temp.CrewId = IunitOfWork.CrewRepository.Get(item.CrewId);

			//temp.FlightNum = IunitOfWork.FlightRepository.Get(item.FlightNum);

			//temp.PlaneId = IunitOfWork.PlaneRepository.Get(item.PlaneId);

			//if(temp.CrewId != null && temp.PlaneId != null && temp.FlightNum != null)
			//{
			//	IunitOfWork.TakeOffRepository.Create(temp);
			//}		


			IunitOfWork.TakeOffRepository.Create(Mapper.Map<TakeOffDTO, TakeOff>(item));

		}

		public void DeleteTakeOffById(int id)
		{
			IunitOfWork.TakeOffRepository.Delete(id);
		}

		public TakeOffDTO GetTakeOffById(int id)
		{
			List<TakeOff> temp = IunitOfWork.TakeOffRepository.GetAll();

			List<TakeOffDTO> tempDTO = Mapper.Map<List<TakeOff>, List<TakeOffDTO>>(temp);


			return tempDTO.Where(dto => dto.Id == id).First();
		}

		public List<TakeOffDTO> GetTakeOffCollection()
		{
			List<TakeOff> temp = IunitOfWork.TakeOffRepository.GetAll();

			List<TakeOffDTO> tempDTO = Mapper.Map<List<TakeOff>, List<TakeOffDTO>>(temp);


			return tempDTO;
		}

		public void UpdateTakeOff(int id, TakeOffDTO item)
		{
			IunitOfWork.TakeOffRepository.Update(id, Mapper.Map<TakeOffDTO, TakeOff>(item));
		}
	}
}
