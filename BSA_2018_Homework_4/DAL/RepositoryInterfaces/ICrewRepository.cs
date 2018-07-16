using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
	public interface ICrewRepository
    {
		List<Crew> GetAll();
		Crew Get(int id);
		void Delete(int id);
		void Create(Crew item);
		void Update(int id, Crew item);
	}
}
