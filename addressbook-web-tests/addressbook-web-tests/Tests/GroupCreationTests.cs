﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupCreationTests : AuthTestBase
	{
		public static IEnumerable<GroupData> RandomGroupDataProvider()
		{
			List<GroupData> groups = new List<GroupData>();
			for (int i = 0; i < 5; i++)
			{
				groups.Add(new GroupData(GenerateRandomString(30))
				{
					Header = GenerateRandomString(100),
					Footer = GenerateRandomString(100)
				});
				
			}
			return groups;
		}

		public static IEnumerable<GroupData> GroupDataFromCsvFile()
		{
			List<GroupData> groups = new List<GroupData>();
			string[] lines = File.ReadAllLines(@"groups.csv");
			foreach (string l in lines)
			{
				string[] parts = l.Split(',');
				groups.Add(new GroupData(parts[0]){Header= parts[1], Footer = parts[2]});
			}
			return groups;

		}

		public static IEnumerable<GroupData> GroupDataFromXmlFile()
		{
			List<GroupData> groups = new List<GroupData>();
			return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
		}

		[Test, TestCaseSource("GroupDataFromXmlFile")]
		public void GroupCreationTest(GroupData group)
		{
			List<GroupData> oldGroups = app.Groups.GetGroupList();

			app.Groups.Create(group);

			Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());

			List<GroupData> newGroups = app.Groups.GetGroupList();
			oldGroups.Add(group);
			oldGroups.Sort();
			newGroups.Sort();
			Assert.AreEqual(oldGroups, newGroups);
		}

		[Test]
		public void BadNameGroupCreationTest()
		{
			GroupData group = new GroupData("a'a");
			
			List<GroupData> oldGroups = app.Groups.GetGroupList();

			app.Groups.Create(group);

			Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

			List<GroupData> newGroups = app.Groups.GetGroupList();
			oldGroups.Sort();
			newGroups.Sort();
			Assert.AreEqual(oldGroups, newGroups);
		}
	}
}
