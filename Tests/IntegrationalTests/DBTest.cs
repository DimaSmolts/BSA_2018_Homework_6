using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BSA_2018_Homework_4.Controllers;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DTOs;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using BSA_2018_Homework_4.DAL;
using BSA_2018_Homework_4.DAL.Models;

using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Tests.IntegrationalTest
{
	[TestFixture]
	public class DBTest
    {
		private MyContext mc;


		[SetUp]
		public void TestSetup()
		{
			var connection = @"Server=DESKTOP-DMYTRO\SQLEXPRESS;Initial Catalog=Academy;Trusted_Connection=True;ConnectRetryCount=0";

			DbContextOptionsBuilder<MyContext> t = new DbContextOptionsBuilder<MyContext>();
			t.UseSqlServer(connection);
			mc = new MyContext(t.Options);
		}

		[TearDown]
		public void TestTearDown()
		{

		}



		[TestCase]
		public void Connection()
		{			
			//
			Assert.IsNotNull(mc);
		}

		[TestCase]
		public void BadConnection()
		{
			//
			var connection = @"BadServer;Initial Catalog=Academy;Trusted_Connection=True;ConnectRetryCount=0";

			DbContextOptionsBuilder<MyContext> t = new DbContextOptionsBuilder<MyContext>();
			t.UseSqlServer(connection);

			//
			Assert.That(() => new MyContext(t.Options), Throws.Exception);
		}

		[TestCase]
		public void AddingEntity()
		{
			//
			Pilot pilot = new Pilot()
			{				
				Surname = "mytestpilot",
				Name = "toliptsetym"
			};

			mc.Pilot.Add(pilot);
			mc.SaveChanges();
			//
			var result = mc.Pilot.FirstOrDefault(p => p.Name == "toliptsetym");
			//
			Assert.IsNotNull(result);
		}

		[TestCase]
		public void RemovingEntity()
		{	

			//
			var result = mc.Pilot.FirstOrDefault(p => p.Name == "toliptsetym");

			//
			Assert.IsNotNull(result);
			mc.Pilot.Remove(result);
			mc.SaveChanges();
		}

		[TestCase]		
		public void AddingEntityWithId()
		{

			Pilot pilot = new Pilot()
			{
				Id = 1,
				Surname = "mytestpilot",
				Name = "toliptsetym"
			};

			
			//
			mc.Add(pilot);

			//
			Assert.That(() => mc.SaveChanges(), Throws.Exception);			
		}
		

		[TestCase]
		public void WrongIdentifier()
		{
			//

			//
			var Nullpilot = mc.Pilot.Find(0);
			//
			Assert.IsNull(Nullpilot);
		}

		[TestCase]
		public void GoodIdentifier()
		{
			//
			var Nullpilot = mc.Pilot.Find(1);
			//
			Assert.IsNotNull(Nullpilot);
		}


		[TestCase]
		public void IdChecking()
		{
			//

			//
			var pilot = mc.Pilot.Find(1);
			//
			Assert.AreEqual(pilot.Id, 1);
		}


	}
}
