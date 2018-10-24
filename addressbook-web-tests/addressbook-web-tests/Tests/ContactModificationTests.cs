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
			ContactData contact = new ContactData("Contact", "Tomodify");

			ContactData newData = new ContactData("Ivan", "Ivanov");
			newData.Nickname = "abc";

			if (!app.Contacts.ContactPresent())
			{
				app.Contacts.Create(contact);
			}

			app.Contacts.Modify(1, newData);
		}
	}
}
