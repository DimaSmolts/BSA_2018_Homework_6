using System;
using System.Collections.Generic;
using System.Text;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;

namespace Tests.CreateUpdateTests.CrewTest
{
	class FakeCrewRepository : ICrewRepository
	{
		Crew crew;

		public void Create(Crew item)
		{
			crew = item;
		}

		public void Delete(int id)
		{
			
		}

		public Crew Get(int id)
		{
			return crew;
		}

		public List<Crew> GetAll()
		{
			return null;
		}

		public void Update(int id, Crew item)
		{
			crew = item;
		}
	}
}
