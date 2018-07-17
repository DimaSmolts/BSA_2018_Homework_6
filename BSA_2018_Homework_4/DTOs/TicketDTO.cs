using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSA_2018_Homework_4.DTOs
{
    public class TicketDTO
    {
		public int Id { get; set; }
		public decimal Price { get; set; }
		public FlightDTO FlightNum { get; set; }
	}
}
