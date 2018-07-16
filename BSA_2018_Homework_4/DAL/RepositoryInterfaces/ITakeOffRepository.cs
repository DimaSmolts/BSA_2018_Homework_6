using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
	public interface ITakeOffRepository
    {
		List<TakeOff> GetAll();
		TakeOff Get(int id);
		void Delete(int id);
		void Create(TakeOff item);
		void Update(int id, TakeOff item);
	}
}
