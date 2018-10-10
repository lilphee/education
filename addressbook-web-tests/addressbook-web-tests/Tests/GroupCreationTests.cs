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
			GroupData group = new GroupData("group1");
			group.Header = "aaa";
			group.Footer = "bbb";

			app.Groups.Create(group);
		}
		[Test]
		public void EmptyGroupCreationTest()
		{
			GroupData group = new GroupData("");
			group.Header = "";
			group.Footer = "";

			app.Groups.Create(group);
		}
	}
}
