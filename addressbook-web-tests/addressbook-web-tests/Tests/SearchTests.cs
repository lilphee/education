﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	public class SearchTests : AuthTestBase
	{
		[Test]
		public void TestSearch()
		{
			System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
		}
	}
}
