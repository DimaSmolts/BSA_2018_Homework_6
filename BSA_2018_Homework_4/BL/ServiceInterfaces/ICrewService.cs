using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface ICrewService
    {
		List<CrewDTO> GetCrewCollection();
		CrewDTO GetCrewById(int id);
		void DeleteCrewById(int id);
		void CreateCrew(CrewDTO item);
		void UpdateCrew(int id, CrewDTO item);
	}
}
