using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactModificationTests : AuthTestBase
	{
		[Test]
		public void ContactModificationTest()
		{
			ContactData newData = new ContactData("Ivan", "Ivanov");
			newData.Nickname = "abc";

			app.Contacts.Modify(1, newData);
		}
	}
}
