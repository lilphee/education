﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactCreationTests : AuthTestBase
	{
		public static IEnumerable<ContactData> RandomContactDataProvider()
		{
			List<ContactData> contact = new List<ContactData>();
			for (int i = 0; i < 5; i++)
			{
				contact.Add(new ContactData(GenerateRandomString(50), GenerateRandomString(50))
				{
					Nickname = GenerateRandomString(50),
				});

			}
			return contact;
		}

		public static IEnumerable<ContactData> ContactDataFromXmlFile()
		{
			List<ContactData> contacts = new List<ContactData>();
			return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
		}
		public static IEnumerable<ContactData> ContactDataFromJsonFile()
		{
			return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
		}

		[Test, TestCaseSource("ContactDataFromJsonFile")]
		public void ContactCreationTest(ContactData contact)
		{
			List<ContactData> oldContacts = ContactData.GetAll();

			app.Contacts.Create(contact);

			Assert.AreEqual(oldContacts.Count+1, app.Contacts.GetContactCount());

			List<ContactData> newContacts = ContactData.GetAll();
			oldContacts.Add(contact);
			oldContacts.Sort();
			newContacts.Sort();
			Assert.AreEqual(oldContacts, newContacts);
		}	
	}
}

