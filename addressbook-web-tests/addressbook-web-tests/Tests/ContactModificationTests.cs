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
			ContactData contactToModify = new ContactData("Contact", "Tomodify");

			ContactData newData = new ContactData("aaaaa", "aaaaa");

			if (!app.Contacts.ContactPresent())
			{
				app.Contacts.Create(contactToModify);
			}

			List<ContactData> oldContacts = ContactData.GetAll();
			ContactData oldData = oldContacts[0];

			app.Contacts.Modify(0, newData);

			Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

			List<ContactData> newContacts = ContactData.GetAll();
			oldContacts[0].Firstname = newData.Firstname;
			oldContacts[0].Lastname = newData.Lastname;
			newContacts.Sort();
			oldContacts.Sort();
			Assert.AreEqual(oldContacts, newContacts);

			foreach (ContactData contact in newContacts)
			{
				if (contact.Id == oldData.Id)
				{
					Assert.AreEqual(newData.Firstname, contact.Firstname);
				}
			}
		}
	}
}
