using System;
using System.Collections.Generic;
using System.Text;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;

namespace Tests.CreateUpdateTests.PilotTest
{
	public class FakePilotRepository : IPilotRepository
	{
		Pilot pilot;

		public void Create(Pilot item)
		{
			pilot = item;
		}

		public void Delete(int id)
		{			
		}

		public Pilot Get(int id)
		{
			return pilot;
		}

		public List<Pilot> GetAll()
		{
			return null;
		}

		public void Update(int id, Pilot item)
		{
			pilot = item;
		}
	}
}
