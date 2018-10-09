using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupCreationTests : TestBase
	{
		[Test]
		public void GroupCreationTest()
		{
			navigationHelper.GoToHomePage();
			loginHelper.Login(new AccountData("admin", "secret"));
			navigationHelper.GoToGroupsPage();
			groupHelper.InitGroupCreation();
			GroupData group = new GroupData("a");
			group.Header = "b";
			group.Footer = "c";
			groupHelper.FillGroupForm(group);
			groupHelper.SubmitGroupCreation();
			groupHelper.ReturnToGroupsPage();
			Logout();
		}
	}
}
