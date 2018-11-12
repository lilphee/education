using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
[TestFixture]
	class ContactInformationTest : AuthTestBase
	{
		[Test]
	//	public void TestContactInformation()
	//	{
	//	ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
	//	ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

			//verification
	//		Assert.AreEqual(fromTable, fromForm); //firstname lastname
	//		Assert.AreEqual(fromTable.Address, fromForm.Address);
	//		Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
	//		Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
	//	}

		public void TestContactInformationDetails()
		{
		string fromDetailsAllData = app.Contacts.GetContactInformationFromDetails(0);
		ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

			//verification
			Assert.AreEqual(fromDetailsAllData, fromForm.AllData);
		}
	}
}
