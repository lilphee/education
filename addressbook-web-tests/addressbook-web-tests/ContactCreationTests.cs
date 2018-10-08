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
	public class ContactCreationTests
	{
		private IWebDriver driver;
		private StringBuilder verificationErrors;
		private string baseURL;
		private bool acceptNextAlert = true;

		[SetUp]
		public void SetupTest()
		{
			driver = new FirefoxDriver();
			baseURL = "https://www.katalon.com/";
			verificationErrors = new StringBuilder();
		}

		[TearDown]
		public void TeardownTest()
		{
			try
			{
				driver.Quit();
			}
			catch (Exception)
			{
				// Ignore errors if unable to close the browser
			}
			Assert.AreEqual("", verificationErrors.ToString());
		}

		[Test]
		public void ContactCreationTest()
		{
			OpenHomePage();
			Login(new AccountData("admin", "secret"));
			InitContactCreation();
			ContactData contact = new ContactData("Natalia", "Filatova");
			contact.Nickname = "lalala";
			FillContactForm(contact);
			Fill();
			SubmitContactCreation();
			Logout();
		}
		private void OpenHomePage()
		{
				driver.Navigate().GoToUrl("http://localhost/addressbook");
		}
		private void Login(AccountData account)
		{
				driver.FindElement(By.Name("user")).Clear();
				driver.FindElement(By.Name("user")).SendKeys(account.Username);
				driver.FindElement(By.Id("LoginForm")).Click();
				driver.FindElement(By.Name("pass")).Click();
				driver.FindElement(By.Name("pass")).Clear();
				driver.FindElement(By.Name("pass")).SendKeys(account.Password);
				driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
		}
		private void InitContactCreation()
		{
				driver.FindElement(By.LinkText("add new")).Click();
		}
		private void FillContactForm(ContactData contact)
		{
				driver.FindElement(By.Name("firstname")).Click();
				driver.FindElement(By.Name("firstname")).Clear();
				driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
				driver.FindElement(By.Name("lastname")).Click();
				driver.FindElement(By.Name("lastname")).Clear();
				driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
				
		}
		private void Fill()
		{
			driver.FindElement(By.Name("title")).Clear();
			driver.FindElement(By.Name("title")).SendKeys("1");
			driver.FindElement(By.Name("photo")).SendKeys("C:\\temp\\111.jpg");
			driver.FindElement(By.Name("title")).Click();
			driver.FindElement(By.Name("title")).Clear();
			driver.FindElement(By.Name("title")).SendKeys("aaa");
			driver.FindElement(By.Name("company")).Click();
			driver.FindElement(By.Name("company")).Clear();
			driver.FindElement(By.Name("company")).SendKeys("bbb");
			driver.FindElement(By.Name("address")).Click();
			driver.FindElement(By.Name("address")).Clear();
			driver.FindElement(By.Name("address")).SendKeys("ccc");
			driver.FindElement(By.Name("theform")).Click();
			driver.FindElement(By.Name("home")).Click();
			driver.FindElement(By.Name("home")).Clear();
			driver.FindElement(By.Name("home")).SendKeys("111");
			driver.FindElement(By.Name("mobile")).Click();
			driver.FindElement(By.Name("mobile")).Clear();
			driver.FindElement(By.Name("mobile")).SendKeys("222");
			driver.FindElement(By.Name("work")).Click();
			driver.FindElement(By.Name("work")).Clear();
			driver.FindElement(By.Name("work")).SendKeys("333");
			driver.FindElement(By.Name("theform")).Click();
			driver.FindElement(By.Name("fax")).Click();
			driver.FindElement(By.Name("fax")).Clear();
			driver.FindElement(By.Name("fax")).SendKeys("444");
			driver.FindElement(By.Name("email")).Click();
			driver.FindElement(By.Name("email")).Clear();
			driver.FindElement(By.Name("email")).SendKeys("111@111.ru");
			driver.FindElement(By.Name("bday")).Click();
			new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("16");
			driver.FindElement(By.Name("bday")).Click();
			driver.FindElement(By.Name("bmonth")).Click();
			new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("November");
			driver.FindElement(By.Name("bmonth")).Click();
			driver.FindElement(By.Name("byear")).Click();
			driver.FindElement(By.Name("byear")).Clear();
			driver.FindElement(By.Name("byear")).SendKeys("1990");
			driver.FindElement(By.Name("theform")).Click();
			driver.FindElement(By.Name("address2")).Click();
			driver.FindElement(By.Name("address2")).Clear();
			driver.FindElement(By.Name("address2")).SendKeys("123");
			driver.FindElement(By.Name("phone2")).Click();
			driver.FindElement(By.Name("phone2")).Clear();
			driver.FindElement(By.Name("phone2")).SendKeys("321");
			driver.FindElement(By.Name("notes")).Click();
			driver.FindElement(By.Name("notes")).Clear();
			driver.FindElement(By.Name("notes")).SendKeys("123456789");
		}

		private void SubmitContactCreation()
		{
			driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
		}
		private void Logout()
		{
			driver.FindElement(By.LinkText("Logout")).Click();
		}
		private bool IsElementPresent(By by)
		{
			try
			{
				driver.FindElement(by);
				return true;
			}
			catch (NoSuchElementException)
			{
				return false;
			}
		}

		private bool IsAlertPresent()
		{
			try
			{
				driver.SwitchTo().Alert();
				return true;
			}
			catch (NoAlertPresentException)
			{
				return false;
			}
		}

		private string CloseAlertAndGetItsText()
		{
			try
			{
				IAlert alert = driver.SwitchTo().Alert();
				string alertText = alert.Text;
				if (acceptNextAlert)
				{
					alert.Accept();
				}
				else
				{
					alert.Dismiss();
				}
				return alertText;
			}
			finally
			{
				acceptNextAlert = true;
			}
		}
	}
}

