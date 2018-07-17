using System;
using System.Collections.Generic;
using System.Text;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;

namespace Tests.CreateUpdateTests.TakeOffTest
{
    class FakeTakeOffRepository : ITakeOffRepository
    {
		TakeOff takeOff;

		public void Create(TakeOff item)
		{
			takeOff = item;
		}

		public void Delete(int id)
		{
			
		}

		public TakeOff Get(int id)
		{
			return takeOff;
		}

		public List<TakeOff> GetAll()
		{
			return null;
		}

		public void Update(int id, TakeOff item)
		{
			takeOff = item;
		}
	}
}
