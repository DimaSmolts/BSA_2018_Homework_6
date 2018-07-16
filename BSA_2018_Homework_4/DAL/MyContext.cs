using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL
{
    public class MyContext : DbContext
    {
		public DbSet<Crew> Crew { get; set; }
		public DbSet<Flight> Flight { get; set; }
		public DbSet<TakeOff> TakeOff { get; set; }
		public DbSet<Ticket> Ticket { get; set; }
		public DbSet<Stewardess> Stewardess { get; set; }
		public DbSet<Pilot> Pilot { get; set; }
		public DbSet<Plane> PLane { get; set; }
		public DbSet<PlaneType> PlaneType { get; set; }

		public MyContext(DbContextOptions<MyContext> options) : base(options)
		{
			this.Database.Migrate();
			Seed();
			this.SaveChanges();
		}

		public void Seed()
		{
			//Pilot.RemoveRange(Pilot);
			//Stewardess.RemoveRange(Stewardess);
			//Ticket.RemoveRange(Ticket);
			//Flight.RemoveRange(Flight);
			//PLane.RemoveRange(PLane);
			//PlaneType.RemoveRange(PlaneType);

			//this.SaveChanges();

			///////////////////////////////////////////////////////////////////////////////////////////////////////
			Pilot p1 = new Pilot()
			{
				Name = "Skyler",
				Surname = "Bunker",
				Birth = new DateTime(1998, 6, 28),
				Experience = new TimeSpan(0, 1, 3, 4)
			};
			Pilot p2 = new Pilot()
			{
				Name = "Garry",
				Surname = "Murdoch",
				Birth = new DateTime(1998, 6, 28),
				Experience = new TimeSpan(0, 1, 3, 4)
			};
			Pilot p3 = new Pilot()
			{
				Name = "Dennisson",
				Surname = "Keegan",
				Birth = new DateTime(1998, 6, 28),
				Experience = new TimeSpan(0, 1, 3, 4)
			};
			if (!Pilot.Any())
			{
				Pilot.AddRange(p1,p2,p3);
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////
			Stewardess s1 = new Stewardess
			{
				Name = "Zelda",
				Surname = "Gouse",
				Birth = new DateTime(1998, 6, 28),
			};
			Stewardess s2 = new Stewardess
			{
				Name = "Anna",
				Surname = "Rosser",
				Birth = new DateTime(1998, 6, 28),
			};
			Stewardess s3 = new Stewardess
			{
				Name = "Bobina",
				Surname = "Vaccaro",
				Birth = new DateTime(1998, 6, 28),
			};
			Stewardess s4 = new Stewardess
			{
				Name = "Sharron",
				Surname = "Herwitz",
				Birth = new DateTime(1998, 6, 28),
			};
			Stewardess s5 = new Stewardess
			{
				Name = "Isa",
				Surname = "Dorwart",
				Birth = new DateTime(1998, 6, 28),
			};
			if (!Stewardess.Any())
			{
				Stewardess.AddRange(s1, s2, s3, s4, s5);
			}
			///////////////////////////////////////////////////////////////////////////////////////////////////////
			Crew cr1 = new Crew()
			{
				PilotId = p1,
				StewardessIds = new List<Stewardess>() { s1, s2 }
			};
			Crew cr2 = new Crew()
			{
				PilotId = p2,
				StewardessIds = new List<Stewardess>() { s3, s5 }
			};
			Crew cr3 = new Crew()
			{
				PilotId = p3,
				StewardessIds = new List<Stewardess>() { s4 }
			};
			if (!Crew.Any())
			{
				Crew.AddRange(cr1, cr2, cr3);				
			};
			////////////////////////////////////////////////////////////////////////////////////////////////////////////

			Flight f1 = new Flight()
			{
				DeperturePlace = "Kyiv",
				DepartureTime = new DateTime(1998, 6, 28),
				ArrivalPlace = "London",
				ArrivalTime = new DateTime(1998, 6, 28)
			};
			Flight f2 = new Flight()
			{
				DeperturePlace = "Kyiv",
				DepartureTime = new DateTime(1998, 6, 28),
				ArrivalPlace = "Manchester",
				ArrivalTime = new DateTime(1998, 6, 28),
			};
			Flight f3 = new Flight()
			{
				DeperturePlace = "Kyiv",
				DepartureTime = new DateTime(1998, 6, 28),
				ArrivalPlace = "Frankfurt",
				ArrivalTime = new DateTime(1998, 6, 28),

			};
			if (!Flight.Any())
			{
				Flight.AddRange(f1, f2, f3);
			}
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////
			Ticket t1 = new Ticket()
			{
				Price = 500,
				FlightNum = f1
			};
			Ticket t2 = new Ticket()
			{
				Price = 800,
				FlightNum = f2
			};
			Ticket t3 = new Ticket()
			{
				Price = 500,
				FlightNum = f1
			};
			Ticket t4 = new Ticket()
			{
				Price = 800,
				FlightNum = f2
			};
			Ticket t5 = new Ticket()
			{
				Price = 600,
				FlightNum = f3
			};
			Ticket t6 = new Ticket()
			{
				Price = 600,
				FlightNum = f3
			};
			Ticket t7 = new Ticket()
			{
				Price = 1000,
				FlightNum = f2
			};
			if (!Ticket.Any())
			{
				Ticket.AddRange(t1, t2, t3, t4, t5, t6, t7);
			}
			//////////////////////////////////////////////////////////////////////////////////////////////////////////
			PlaneType pt1 = new PlaneType()
			{
				Model = "Airbus A310",
				Places = 183,
				CarryCapacity = 164000
			};
			PlaneType pt2 = new PlaneType()
			{
				Model = "Boeing",
				Places = 235,
				CarryCapacity = 242000
			};
			if (!PlaneType.Any())
			{
				PlaneType.AddRange(pt1, pt2);
			}
			//////////////////////////////////////////////////////////////////////////////////////////////////////////
			Plane pl1 = new Plane()
			{
				Name = "Skyshark",
				Made = new DateTime(1998, 6, 28),
				Exploitation = new TimeSpan(0, 1, 3, 4),
				Type = pt1
			};
			Plane pl2 = new Plane()
			{
				Name = "Dragon",
				Made = new DateTime(1998, 6, 28),
				Exploitation = new TimeSpan(0, 1, 3, 4),
				Type = pt2
			};
			Plane pl3 = new Plane()
			{
				Name = "Airking",
				Made = new DateTime(1998, 6, 28),
				Exploitation = new TimeSpan(0, 1, 3, 4),
				Type = pt2
			};
			Plane pl4 = new Plane()
			{
				Name = "Kondor",
				Made = new DateTime(1998, 6, 28),
				Exploitation = new TimeSpan(0, 1, 3, 4),
				Type = pt2
			};
			if (!PLane.Any())
			{
				PLane.AddRange(pl1, pl2, pl3, pl4);
			}
			//////////////////////////////////////////////////////////////////////////////////////////////////////////
			TakeOff to1 = new TakeOff()
			{
				FlightNum = f1,
				CrewId = cr3,
				PlaneId = pl2,
				Date = new DateTime(1998, 6, 28)
			};
			TakeOff to2 = new TakeOff()
			{
				FlightNum = f2,
				CrewId = cr2,
				PlaneId = pl4,
				Date = new DateTime(1998, 6, 28)
			};
			TakeOff to3 = new TakeOff()
			{
				FlightNum = f1,
				CrewId = cr1,
				PlaneId = pl3,
				Date = new DateTime(1998, 6, 28)
			};
			if (!TakeOff.Any())
			{
				TakeOff.AddRange(to1, to2, to3);
			}


		}
	}
}
