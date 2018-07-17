using System;
using System.Collections.Generic;
using System.Text;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;

namespace Tests.CreateUpdateTests.TicketTest
{
	class FakeTicketRepository : ITicketRepository
	{
		Ticket ticket;

		public void Create(Ticket item)
		{
			ticket = item;
		}

		public void Delete(int id)
		{
			
		}

		public Ticket Get(int id)
		{
			return ticket;
		}

		public List<Ticket> GetAll()
		{
			return null;
		}

		public void Update(int id, Ticket item)
		{
			ticket = item;
		}
	}
}
