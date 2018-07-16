using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using Newtonsoft.Json;
using System.IO;

namespace BSA_2018_Homework_4.DAL.Repositories
{
    public class PlaneTypeRepository : IPlaneTypeRepository
    {
		private List<PlaneType> planetypes = new List<PlaneType>();
		MyContext db;

		public PlaneTypeRepository(MyContext db)
		{
			this.db = db;

		//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\planetypes.json"))
			//{
		//		JsonSerializer serializer = new JsonSerializer();
		//		planetypes = (List<PlaneType>)serializer.Deserialize(file, typeof(List<PlaneType>));
		//	}
		}

		public void SaveChanges()
		{
		//	File.WriteAllText(Environment.CurrentDirectory + @"\Data\planetypes.json",
			//	JsonConvert.SerializeObject(planetypes));
		}

		public List<PlaneType> GetAll()
		{
			return db.PlaneType.ToList();
		}

		public PlaneType Get(int id)
		{
			return db.PlaneType.Find(id);
		}

		public void Delete(int id)
		{
			PlaneType temp = db.PlaneType.Find(id);
			if (temp != null)
			{
				db.PlaneType.Remove(temp);
				db.SaveChanges();
			}				
		}

		public void Create(PlaneType item)
		{
			db.PlaneType.Add(item);
			db.SaveChanges();
		}

		public void Update(int id, PlaneType item)
		{			

			PlaneType temp = db.PlaneType.Find(id);
			if (temp != null)
			{
				temp.CarryCapacity = item.CarryCapacity;
				temp.Model = item.Model;
				temp.Places = item.Places;


				db.PlaneType.Update(temp);
				db.SaveChanges();
			}

		}
	}
}
