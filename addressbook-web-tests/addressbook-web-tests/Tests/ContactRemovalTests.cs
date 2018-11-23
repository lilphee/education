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

			List<ContactData> oldContacts = ContactData.GetAll();

			app.Contacts.Remove(1);

			Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

			List<ContactData> newContacts = ContactData.GetAll();
			oldContacts.RemoveAt(0);
			Assert.AreEqual(oldContacts, newContacts);
		}
	}
}
