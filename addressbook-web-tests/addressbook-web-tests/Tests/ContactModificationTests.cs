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

			ContactData newData = new ContactData("Im", "modified");
			newData.Nickname = "abc";

			if (!app.Contacts.ContactPresent())
			{
				app.Contacts.Create(contact);
			}

			List<ContactData> oldContacts = app.Contacts.GetContactList();

			app.Contacts.Modify(1, newData);

			List<ContactData> newContacts = app.Contacts.GetContactList();

			oldContacts[0].Firstname = newData.Firstname;
			oldContacts[0].Lastname = newData.Lastname;

			newContacts.Sort();
			oldContacts.Sort();

			Assert.AreEqual(oldContacts, newContacts);
		}
	}
}
