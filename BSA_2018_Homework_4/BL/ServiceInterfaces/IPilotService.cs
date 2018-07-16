using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface IPilotService
    {
		List<PilotDTO> GetPilotCollection();
		PilotDTO GetPilotById(int id);
		void DeletePilotById(int id);
		void CreatePilot(PilotDTO item);
		void UpdatePilot(int id, PilotDTO item);
	}
}
