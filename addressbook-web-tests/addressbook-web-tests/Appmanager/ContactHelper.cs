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
using System.Text.RegularExpressions;

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

		public ContactHelper Remove (ContactData contact)
		{
			SelectContact(contact.Id);
			InitContactRemoval();
			SubmitContactRemoval();
			manager.Navigator.GoToHomePage();
			return this;
		}
		public ContactHelper AddContactToGroup(ContactData contact, GroupData group)
		{
			manager.Navigator.GoToHomePage();
			ClearGroupFilter();
			SelectContact(contact.Id);
			SelectGroupToAdd(group.Name);
			CommitAddingContactToGroup();
			new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count>0);
			return this;
		}

		public ContactHelper CommitAddingContactToGroup()
		{
			driver.FindElement(By.Name("add")).Click();
			return this;
		}

		public ContactHelper SelectGroupToAdd(string name)
		{
			new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
			return this;
		}

		public ContactHelper ClearGroupFilter()
		{
			new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
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
		public void InitContactModification(int index)
		{
			driver.FindElements(By.Name("entry"))[index]
				.FindElements(By.TagName("td"))[7]
				.FindElement(By.TagName("a")).Click();
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

		public ContactHelper SelectContact(string contactid)
		{
			driver.FindElement(By.Id(contactid)).Click();
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

		public void GetContactDetails(int index)
		{
			driver.FindElement(By.XPath("(//img[@alt='Details'])[" + index + "]")).Click();
		}

		public ContactData GetContactInformationFromEditForm(int index)
		{
			manager.Navigator.GoToHomePage();
			InitContactModification(0);
			string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
			string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
			string address = driver.FindElement(By.Name("address")).GetAttribute("value");

			string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
			string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
			string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

			string email = driver.FindElement(By.Name("email")).GetAttribute("value");
			string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
			string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

			return new ContactData(firstName, lastName)
			{
				Address = address,
				HomePhone = homePhone,
				MobilePhone = mobilePhone,
				Workphone = workPhone,
				Email = email,
				Email2 = email2,
				Email3 = email3
			};
		}
		public ContactData GetContactInformationFromTable(int index)
		{
			manager.Navigator.GoToHomePage();
			IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
			string lastName = cells[1].Text;
			string firstName = cells[2].Text;
			string address = cells[3].Text;
			string allEmails = cells[4].Text;
			string allPhones = cells[5].Text;

			return new ContactData(firstName, lastName)
			{
				Address = address,
				AllPhones = allPhones,
				AllEmails = allEmails
			};
		}

		public int GetNumberOfSearchResults()
		{
			manager.Navigator.GoToHomePage();
			string text = driver.FindElement(By.TagName("label")).Text;
			Match m = new Regex(@"\d+").Match(text);
			return Int32.Parse(m.Value);
		}
		public string GetContactInformationFromDetails(int index)
		{
			manager.Navigator.GoToHomePage();
			GetContactDetails(0);
			string allData = driver.FindElement(By.Id("content")).GetAttribute("value");

			return allData;
		}
	}
}