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
    public class PlaneTypeService : IPlaneTypeService
    {
		private DAL.IUnitOfWork IunitOfWork;

		public PlaneTypeService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public void CreatePlaneType(PlaneTypeDTO item)
		{
			IunitOfWork.PlaneTypeRepository.Create(Mapper.Map<PlaneTypeDTO,PlaneType>(item));
		}

		public void DeletePlaneType(int id)
		{
			IunitOfWork.PlaneTypeRepository.Delete(id);
		}

		public PlaneTypeDTO GetPlaneTypeById(int id)
		{
			return Mapper.Map<PlaneType,PlaneTypeDTO>(IunitOfWork.PlaneTypeRepository.Get(id));
		}

		public List<PlaneTypeDTO> GetPlaneTypeCollection()
		{
			return Mapper.Map<List<PlaneType>, List<PlaneTypeDTO>>(IunitOfWork.PlaneTypeRepository.GetAll());
		}

		public void UpdatePlaneType(int id, PlaneTypeDTO item)
		{
			IunitOfWork.PlaneTypeRepository.Update(id, Mapper.Map<PlaneTypeDTO, PlaneType>(item));
		}
	}
}
