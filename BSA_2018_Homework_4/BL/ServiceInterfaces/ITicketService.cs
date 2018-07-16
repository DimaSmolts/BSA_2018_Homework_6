using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface ITicketService
    {
		List<TicketDTO> GetTicketCollection();
		TicketDTO GetTicketById(int id);
		void DeleteTicketById(int id);
		void CreateTicket(TicketDTO item);
		void UpdateTicket(int id, TicketDTO item);
	}
}
