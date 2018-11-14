using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

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

		[Test, TestCaseSource("RandomContactDataProvider")]
		public void ContactCreationTest(ContactData contact)
		{
			List<ContactData> oldContacts = app.Contacts.GetContactList();

			app.Contacts.Create(contact);

			Assert.AreEqual(oldContacts.Count+1, app.Contacts.GetContactCount());

			List<ContactData> newContacts = app.Contacts.GetContactList();
			oldContacts.Add(contact);
			oldContacts.Sort();
			newContacts.Sort();
			Assert.AreEqual(oldContacts, newContacts);
		}	
	}
}

