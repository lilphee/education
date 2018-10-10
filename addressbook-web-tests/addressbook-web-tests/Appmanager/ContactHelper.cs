﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
	public class ContactHelper : HelperBase
	{
		public ContactHelper(ApplicationManager manager) : base(manager)
		{
		}
		public ContactHelper Create(ContactData contact)
		{
			InitContactCreation();
			FillContactForm(contact);
			SubmitContactCreation();
			manager.Navigator.GoToHomePage();
			return this;
		}

		internal ContactHelper Modify(int p, ContactData newData)
		{
			InitContactModification(p);
			FillContactForm(newData);
			SubmitContactModification();
			manager.Navigator.GoToHomePage();
			return this;
		}
		public ContactHelper InitContactCreation()
		{
			driver.FindElement(By.LinkText("add new")).Click();
			return this;
		}
		public ContactHelper FillContactForm(ContactData contact)
		{
			driver.FindElement(By.Name("firstname")).Click();
			driver.FindElement(By.Name("firstname")).Clear();
			driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
			driver.FindElement(By.Name("lastname")).Click();
			driver.FindElement(By.Name("lastname")).Clear();
			driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
			return this;
		}
		public ContactHelper SubmitContactCreation()
		{
			driver.FindElement(By.Name("submit")).Click();
			return this;
		}
		public ContactHelper InitContactModification(int index)
		{
			driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
			return this;
		}
		public ContactHelper SubmitContactModification()
		{
			driver.FindElement(By.Name("update")).Click();
			return this;
		}
	}
}
