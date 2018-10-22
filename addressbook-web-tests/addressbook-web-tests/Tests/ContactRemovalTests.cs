﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	class ContactRemovalTests : AuthTestBase
	{
		[Test]
		public void ContactRemovalTest()
		{
			app.Contacts.Remove(1);
		}
	}
}