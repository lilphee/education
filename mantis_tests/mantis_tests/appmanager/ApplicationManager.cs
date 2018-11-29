﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
	public class ApplicationManager
	{
		protected IWebDriver driver;
		protected string baseURL;


		private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

		private ApplicationManager()
		{
		driver = new FirefoxDriver();
		baseURL = "http://localhost/";

		}

		~ApplicationManager()
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
		public static ApplicationManager GetInstance()
		{
			if (! app.IsValueCreated)
			{
				ApplicationManager newInstance = new ApplicationManager();
				newInstance.driver.Url = "http://localhost/mantisbt-1.2.17/login_page.php";
				app.Value = newInstance;
			}
			return app.Value;
		}
		public IWebDriver Driver
		{
			get
			{
				return driver;
			}
		}
	}
}
