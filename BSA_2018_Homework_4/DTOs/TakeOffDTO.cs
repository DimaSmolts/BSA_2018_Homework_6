using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSA_2018_Homework_4.DTOs
{
    public class TakeOffDTO
    {
		public int Id { get; set; }
		public FlightDTO FlightNum { get; set; }
		public DateTime Date { get; set; }
		public CrewDTO CrewId { get; set; }
		public PlaneDTO PlaneId { get; set; }
	}
}
