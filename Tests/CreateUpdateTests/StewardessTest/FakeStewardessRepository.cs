using System;
using System.Collections.Generic;
using System.Text;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;

namespace Tests.CreateUpdateTests.StewardessTest
{
	public class FakeStewardessRepository : IStewardessRepository
	{
		Stewardess stewardess;

		public void Create(Stewardess item)
		{
			stewardess = item;
		}

		public void Delete(int id)
		{			
		}

		public Stewardess Get(int id)
		{
			return stewardess;
		}

		public List<Stewardess> GetAll()
		{
			return null;
		}

		public void Update(int id, Stewardess item)
		{
			stewardess = item;
		}
	}
}
