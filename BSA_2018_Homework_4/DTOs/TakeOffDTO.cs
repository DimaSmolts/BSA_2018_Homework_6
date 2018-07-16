using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSA_2018_Homework_4.DTOs
{
    public class TakeOffDTO
    {
		public int Id { get; set; }
		public int FlightNum { get; set; }
		public DateTime Date { get; set; }
		public int CrewId { get; set; }
		public int PlaneId { get; set; }
	}
}
