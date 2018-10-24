using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
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

		public ContactHelper Modify(int p, ContactData newData)
		{
			InitContactModification(p);
			FillContactForm(newData);
			SubmitContactModification();
			manager.Navigator.GoToHomePage();
			return this;
		}
		public ContactHelper Remove(int v)
		{
			SelectContact(v);
			InitContactRemoval();
			SubmitContactRemoval();
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
			Type(By.Name("firstname"), contact.Firstname);
			Type(By.Name("lastname"), contact.Lastname);
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
		public ContactHelper SelectContact(int index)
		{
			driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
			return this;
		}
		public ContactHelper InitContactRemoval()
		{
			driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
			return this;
		}
		public ContactHelper SubmitContactRemoval()
		{
			driver.SwitchTo().Alert().Accept();
			return this;
		}

		public bool ContactPresent()
		{
			return IsElementPresent(By.CssSelector("input[name=\"selected[]\"]"));
		}
	}
}
