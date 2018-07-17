using System;
using System.Collections.Generic;
using System.Text;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;

namespace Tests.CreateUpdateTests.FlightTest
{
	class FakeFlightRepository : IFlightRepository
	{
		Flight flight;

		public void Create(Flight item)
		{
			flight = item;
		}

		public void Delete(int id)
		{
			
		}

		public Flight Get(int id)
		{
			return flight;
		}

		public List<Flight> GetAll()
		{
			return null;
		}

		public void Update(int id, Flight item)
		{
			flight = item;
		}
	}
}
