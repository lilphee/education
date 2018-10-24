using System;
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
			ContactData contact = new ContactData("Contact", "Todelete");

			if (!app.Contacts.ContactPresent())
			{
				app.Contacts.Create(contact);
			}
			app.Contacts.Remove(1);
		}
	}
}
