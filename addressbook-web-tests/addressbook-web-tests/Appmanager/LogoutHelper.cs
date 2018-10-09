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
	public class LogoutHelper : HelperBase
	{
		public LogoutHelper(IWebDriver driver) : base(driver)
		{
		}
		public void Logout()
		{
			driver.FindElement(By.LinkText("Logout")).Click();
		}
	}
}
