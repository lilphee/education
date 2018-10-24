using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupRemovalTests : AuthTestBase
	{
		[Test]
		public void GroupRemovalTest()
		{
			GroupData group = new GroupData("grouptodelete");

			if (!app.Groups.GroupPresent())
			{
				app.Groups.Create(group);
			}

			app.Groups.Remove(1);
		}
	}
}
