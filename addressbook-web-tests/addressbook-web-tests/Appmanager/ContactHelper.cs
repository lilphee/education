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
			contactCache = null;
			return this;
		}
		public ContactHelper InitContactModification(int index)
		{
			driver.FindElements(By.Name("entry"))[index]
				.FindElements(By.TagName("td"))[7]
				.FindElement(By.TagName("a")).Click();
			return this;
		}
		public ContactHelper SubmitContactModification()
		{
			driver.FindElement(By.Name("update")).Click();
			contactCache = null;
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
			contactCache = null;
			return this;
		}

		public bool ContactPresent()
		{
			return IsElementPresent(By.CssSelector("input[name=\"selected[]\"]"));
		}

		private List<ContactData> contactCache = null;

		public List<ContactData> GetContactList()
		{
			if (contactCache == null)
			{
			contactCache = new List<ContactData>();
			manager.Navigator.GoToHomePage();
			ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
			foreach (IWebElement element in elements)
				{
					var cells = element.FindElements(By.CssSelector("td"));
					contactCache.Add(new ContactData(cells[2].Text, cells[1].Text) { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });
				}
			}
			return new List<ContactData>(contactCache);
		}

		public int GetContactCount()
		{
		return driver.FindElements(By.Name("entry")).Count;
		}


		public ContactData GetContactInformationFromEditForm(int index)
		{
			manager.Navigator.GoToHomePage();
			InitContactModification(0);
			string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
			string lastName= driver.FindElement(By.Name("lastname")).GetAttribute("value");
			string address = driver.FindElement(By.Name("adress")).GetAttribute("value");

			string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
			string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
			string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

			new ContactData(firstName, lastName)
			{
				Address = address,
				HomePhone =homePhone,
				MobilePhone =mobilePhone,
				Workphone =workPhone
			};
		}

		public ContactData GetContactInformationFromTable(int index)
		{
			throw new NotImplementedException();
		}
	}
}
