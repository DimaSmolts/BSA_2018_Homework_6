using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface IPlaneService
    {
		List<PlaneDTO> GetPlaneCollection();
		PlaneDTO GetPlaneById(int id);
		void DeletePlaneById(int id);
		void CreatePlane(PlaneDTO item);
		void UpdatePlane(int id, PlaneDTO item);
	}
}
