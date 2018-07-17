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
    public class PilotRepository : IPilotRepository
    {
		private List<Pilot> pilots = new List<Pilot>();
		MyContext db;

		public PilotRepository(MyContext db)
		{
			this.db = db;
			//using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\pilots.json"))
			//{
			//	JsonSerializer serializer = new JsonSerializer();
			//	pilots = (List<Pilot>)serializer.Deserialize(file, typeof(List<Pilot>));
			//}
		}

		public void SaveChanges()
		{
			//File.WriteAllText(Environment.CurrentDirectory + @"\Data\pilots.json",
			//	JsonConvert.SerializeObject(pilots));
		}

		public List<Pilot> GetAll()
		{
			return db.Pilot.ToList();
		}

		public Pilot Get(int id)
		{
			return db.Pilot.Find(id);
		}

		public void Delete(int id)
		{
			Pilot temp = db.Pilot.Find(id);
			if (temp != null)
			{
				db.Pilot.Remove(temp);
				db.SaveChanges();
			}				
		}

		public void Create(Pilot item)
		{
			db.Pilot.Add(item);
			db.SaveChanges();
			//return item;
		}

		public void Update(int id, Pilot item)
		{
			Pilot temp = db.Pilot.Find(id);
			if (temp != null)
			{
				//temp.Id = item.Id;
				temp.Name = item.Name;
				temp.Surname = item.Surname;
				temp.Birth = item.Birth;
				temp.Experience = item.Experience;

				db.Pilot.Update(temp);
				db.SaveChanges();
			}
		}
	}
}
