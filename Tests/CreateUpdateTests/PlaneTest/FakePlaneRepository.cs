using System;
using System.Collections.Generic;
using System.Text;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;

namespace Tests.CreateUpdateTests.PlaneTest
{
    class FakePlaneRepository : IPlaneRepository
    {
		Plane plane;

		public void Create(Plane item)
		{
			plane = item;
		}

		public void Delete(int id)
		{
			
		}

		public Plane Get(int id)
		{
			return plane;
		}

		public List<Plane> GetAll()
		{
			return null;
		}

		public void Update(int id, Plane item)
		{
			plane = item;
		}
	}
}
