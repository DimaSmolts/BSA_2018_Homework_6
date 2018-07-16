using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface IStewardessService
    {
		List<StewardessDTO> GetStewardessCollection();
		StewardessDTO GetStewardessById(int id);
		void DeleteStewardessById(int id);
		void CreateStewardess(StewardessDTO item);
		void UpdateStewardess(int id, StewardessDTO item);
	}
}
