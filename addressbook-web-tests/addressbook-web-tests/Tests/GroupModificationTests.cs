using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupModificationTests : AuthTestBase 
	{
		[Test]
		public void GroupModificationTest()
		{
			GroupData group = new GroupData("grouptomodify");

			GroupData newData = new GroupData("abc");
			newData.Header = null;
			newData.Footer = null;

			if (!app.Groups.GroupPresent())
			{
				app.Groups.Create(group);
			}

			app.Groups.Modify(1, newData);
		}
	}
}