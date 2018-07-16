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
    public class StewardessRepository : IStewardessRepository
    {
		private List<Stewardess> stewardesses = new List<Stewardess>();
		MyContext db;

		public StewardessRepository(MyContext db)
		{
			this.db = db;
		//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\stewardesses.json"))
		//	{
		//		JsonSerializer serializer = new JsonSerializer();
		//		stewardesses = (List<Stewardess>)serializer.Deserialize(file, typeof(List<Stewardess>));
		//	}
		}

		public void SaveChanges()
		{
			//File.WriteAllText(Environment.CurrentDirectory + @"\Data\stewardesses.json",
			//	JsonConvert.SerializeObject(stewardesses));
		}

		public List<Stewardess> GetAll()
		{
			return db.Stewardess.ToList();
		}

		public Stewardess Get(int id)
		{
			return db.Stewardess.Find(id);
		}

		public void Delete(int id)
		{
			Stewardess temp = db.Stewardess.Find(id); 
			if (temp != null)
			{
				db.Stewardess.Remove(temp);
				db.SaveChanges();
			}				
		}

		public void Create(Stewardess item)
		{
			db.Stewardess.Add(item);
			db.SaveChanges();
		}

		public void Update(int id, Stewardess item)
		{
			Stewardess temp = db.Stewardess.Find(id);
			if (temp != null)
			{

				temp.Name = item.Name;
				temp.Surname = item.Surname;
				temp.Birth = item.Birth;

				db.Stewardess.Update(temp);
				db.SaveChanges();
			}
		}
	}
}
