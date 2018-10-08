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
			GoToHomePage();
			Login(new AccountData("admin", "secret"));
			GoToGroupsPage();
			InitGroupCreation();
			GroupData group = new GroupData("a");
			group.Header = "b";
			group.Footer = "c";
			FillGroupForm(group);
			SubmitGroupCreation();
			ReturnToGroupsPage();
			Logout();
		}
	}
}
