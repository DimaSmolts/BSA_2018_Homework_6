using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface ITakeOffService
    {
		List<TakeOffDTO> GetTakeOffCollection();
		TakeOffDTO GetTakeOffById(int id);
		void DeleteTakeOffById(int id);
		void CreateTakeOff(TakeOffDTO item);
		void UpdateTakeOff(int id, TakeOffDTO item);
	}
}
