using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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

			app.Contacts.Create(contact);
		}	
	}
}

