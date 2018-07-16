using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
	public interface IPlaneTypeRepository
    {
		List<PlaneType> GetAll();
		PlaneType Get(int id);
		void Delete(int id);
		void Create(PlaneType item);
		void Update(int id, PlaneType item);
	}
}
