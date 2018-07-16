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
    public class StewardessService : IStewardessService
    {
		private DAL.IUnitOfWork IunitOfWork;

		public StewardessService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public void CreateStewardess(StewardessDTO item)
		{
			IunitOfWork.StewardessRepository.Create(Mapper.Map<StewardessDTO, Stewardess>(item));
		}

		public void DeleteStewardessById(int id)
		{
			IunitOfWork.StewardessRepository.Delete(id);
		}

		public StewardessDTO GetStewardessById(int id)
		{
			return Mapper.Map<Stewardess,StewardessDTO>(IunitOfWork.StewardessRepository.Get(id));
		}

		public List<StewardessDTO> GetStewardessCollection()
		{
			return Mapper.Map<List<Stewardess>,List<StewardessDTO>>(IunitOfWork.StewardessRepository.GetAll());
		}

		public void UpdateStewardess(int id, StewardessDTO item)
		{
			IunitOfWork.StewardessRepository.Update(id,Mapper.Map<StewardessDTO,Stewardess>(item));
		}
	}
}
