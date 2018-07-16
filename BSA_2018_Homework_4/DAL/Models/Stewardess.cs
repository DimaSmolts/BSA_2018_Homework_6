using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BSA_2018_Homework_4.DAL.Models
{
	public class Stewardess
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(50)]
		public string Surname { get; set; }
		public DateTime Birth { get; set; }
	}
}
