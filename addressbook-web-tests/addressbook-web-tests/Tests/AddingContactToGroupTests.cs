using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
	public class AddingContactToGroupTests : AuthTestBase
	{
		[Test]
		public void TestAddingContactToGroup()
		{
			GroupData group = GroupData.GetAll()[0];
			//получаем список контактов, не входящих в выбранную группу, и берем первый из списка
			List<ContactData> oldList = group.GetContacts();
			ContactData contact = ContactData.GetAll().Except(oldList).First();

			//действия
			app.Contacts.AddContactToGroup(contact, group);

			List<ContactData> newList = group.GetContacts();
			oldList.Add(contact);
			oldList.Sort();
			newList.Sort();

			Assert.AreEqual(oldList, newList);
			
		}

	}
}
