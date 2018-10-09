﻿using System;
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
	public class ContactCreationTests : TestBase
	{
			[Test]
		public void ContactCreationTest()
		{
			navigationHelper.GoToHomePage();
			loginHelper.Login(new AccountData("admin", "secret"));
			contactHelper.InitContactCreation();
			ContactData contact = new ContactData("Natalia", "Filatova");
			contact.Nickname = "lalala";
			contactHelper.FillContactForm(contact);
			contactHelper.SubmitContactCreation();
			Logout();
		}	
	}
}

