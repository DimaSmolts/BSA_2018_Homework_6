using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSA_2018_Homework_4.DTOs
{
    public class PlaneDTO
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public PlaneTypeDTO Type { get; set; }
		public DateTime Made { get; set; }
		public TimeSpan Exploitation { get; set; }
	}
}
