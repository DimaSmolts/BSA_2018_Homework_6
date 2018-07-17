using System;
using System.Collections.Generic;
using System.Text;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;


namespace Tests.CreateUpdateTests.PlaneTypeTest
{
	class FakePlaneTypeRepository : IPlaneTypeRepository
	{
		PlaneType planeType;

		public void Create(PlaneType item)
		{
			planeType = item;
		}

		public void Delete(int id)
		{
			
		}

		public PlaneType Get(int id)
		{
			return planeType;
		}

		public List<PlaneType> GetAll()
		{
			return null;
		}

		public void Update(int id, PlaneType item)
		{
			planeType = item;
		}
	}
}
