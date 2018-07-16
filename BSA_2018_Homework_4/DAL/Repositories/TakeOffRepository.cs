using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using Newtonsoft.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace BSA_2018_Homework_4.DAL.Repositories
{
    public class TakeOffRepository : ITakeOffRepository
    {
		private List<TakeOff> takeoffs = new List<TakeOff>();
		MyContext db;

		public TakeOffRepository(MyContext db)
		{
			this.db = db;
		//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\takeoffs.json"))
			//{
		//		JsonSerializer serializer = new JsonSerializer();
		//		takeoffs = (List<TakeOff>)serializer.Deserialize(file, typeof(List<TakeOff>));
		//	}
		}

		public void SaveChanges()
		{
			//File.WriteAllText(Environment.CurrentDirectory + @"\Data\takeoffs.json",
			//	JsonConvert.SerializeObject(takeoffs));
		}

		public List<TakeOff> GetAll()
		{
			List<TakeOff> temp = db.TakeOff.ToList();

			return db.TakeOff
				.Include(t => t.PlaneId)
				.Include(t => t.FlightNum)
				.Include(t => t.CrewId)
				.ToList();
		}

		public TakeOff Get(int id)
		{
			return db.TakeOff.Find(id);
		}

		public void Delete(int id)
		{
			TakeOff temp = db.TakeOff.Find(id);
			if (temp != null)
			{
				db.TakeOff.Remove(temp);
				db.SaveChanges();
			}				
		}

		public void Create(TakeOff item)
		{
			db.Add(item);
			db.SaveChanges();
		}

		public void Update(int id, TakeOff item)
		{
			TakeOff temp = takeoffs.FirstOrDefault(t => t.Id == id);
			if (temp != null)
			{
				//temp.Id = item.Id;
				temp.FlightNum = item.FlightNum;
				temp.Date = item.Date;
				temp.CrewId = item.CrewId;
				temp.PlaneId = item.PlaneId;

				db.SaveChanges();
			}

			//TakeOff temp = db.TakeOff.Find(id);
			//if (temp != null)
			//{
			//	db.TakeOff.Remove(temp);
			//	db.TakeOff.Add(item);
			//}

		}
	}
}
