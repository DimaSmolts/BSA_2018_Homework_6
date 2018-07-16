using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BSA_2018_Homework_4.DAL.Models
{
	public class Ticket
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public decimal Price { get; set; }
		public Flight FlightNum { get; set; }
	}
}
