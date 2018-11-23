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
	public class GroupModificationTests : GroupTestBase
	{
		[Test]
		public void GroupModificationTest()
		{
			GroupData groupToModify = new GroupData("grouptomodify");

			GroupData newData = new GroupData("abc");
			newData.Header = null;
			newData.Footer = null;

			if (!app.Groups.GroupPresent())
			{
				app.Groups.Create(groupToModify);
			}

			List<GroupData> oldGroups = app.Groups.GetGroupList();
			GroupData oldData = oldGroups[0];

			app.Groups.Modify(0, newData);

			Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

			List<GroupData> newGroups = app.Groups.GetGroupList();
			oldGroups[0].Name = newData.Name;
			oldGroups.Sort();
			newGroups.Sort();
			Assert.AreEqual(oldGroups, newGroups);

			foreach (GroupData group in newGroups)
			{
				if (group.Id == oldData.Id)
				{
					Assert.AreEqual(newData.Name, group.Name);
				}
			}
		}
	}
}