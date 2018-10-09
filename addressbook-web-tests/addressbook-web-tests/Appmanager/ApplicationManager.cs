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
	public class ApplicationManager
	{
		protected IWebDriver driver;
		protected string baseURL;

		protected LoginHelper loginHelper;
		protected NavigationHelper navigationHelper;
		protected GroupHelper groupHelper;
		protected ContactHelper contactHelper;
		protected LogoutHelper logoutHelper;

		public ApplicationManager()
		{
		loginHelper = new LoginHelper(driver);
		navigationHelper = new NavigationHelper(driver, baseURL);
		groupHelper = new GroupHelper(driver);
		contactHelper = new ContactHelper(driver);
		logoutHelper = new LogoutHelper(driver);
		}

		public void Stop()
		{
			try
			{
				driver.Quit();
			}
			catch (Exception)
			{
				// Ignore errors if unable to close the browser
			}
		}
		public LoginHelper Auth
		{
			get
			{
				return loginHelper;
			}
		}
		public NavigationHelper Navigator
		{
			get
			{
				return navigationHelper;
			}
		}
		public GroupHelper Groups
		{
			get
			{
				return groupHelper;
			}
		}
		public ContactHelper Contacts
		{
			get
			{
				return contactHelper;
			}
		}
		public LogoutHelper Logout
		{
			get
			{
				return logoutHelper;
			}
		}
	}
}
