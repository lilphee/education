﻿using System;
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
			[Test]
		public void ContactCreationTest()
		{
			ContactData contact = new ContactData("Natalia", "Filatova");
			contact.Nickname = "lalala";

			List<ContactData> oldContacts = app.Contacts.GetContactList();

			app.Contacts.Create(contact);

			List<ContactData> newContacts = app.Contacts.GetContactList();
			oldContacts.Add(contact);
			oldContacts.Sort();
			newContacts.Sort();
			Assert.AreEqual(oldContacts, newContacts);
		}	
	}
}

