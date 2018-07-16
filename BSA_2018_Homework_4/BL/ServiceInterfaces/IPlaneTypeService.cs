using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface IPlaneTypeService
    {
		List<PlaneTypeDTO> GetPlaneTypeCollection();
		PlaneTypeDTO GetPlaneTypeById(int id);
		void DeletePlaneType(int id);
		void CreatePlaneType(PlaneTypeDTO item);
		void UpdatePlaneType(int id, PlaneTypeDTO item);
	}
}
