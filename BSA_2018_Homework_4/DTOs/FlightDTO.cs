using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSA_2018_Homework_4.DTOs
{
    public class FlightDTO
    {
		public int FlightNum { get; set; }
		public string DeperturePlace { get; set; }
		public DateTime DepartureTime { get; set; }
		public string ArrivalPlace { get; set; }
		public DateTime ArrivalTime { get; set; }
		//public int[] TicketId { get; set; }
	}
}
