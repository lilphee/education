﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
	public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
	{
		private string firstname = "";
		private string middlename = "";
		private string lastname = "";
		private string nickname = "";
		//photo?
		private string title = "";
		private string company = "";
		private string address = "";
		private string homephone = "";
		private string mobilephone = "";
		private string workphone = "";
		private string fax = "";
		private string email = "";
		private string email2 = "";
		private string email3 = "";
		private string homepage = "";
		//birthday?
		//anniversary?
		//group?
		private string secaddress = "";
		private string home = "";
		private string notes = "";

		public ContactData(string firstname, string lastname)
		{
			Firstname = firstname;
			Lastname = lastname;
		}

		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Nickname { get; set; }
		public string Id { get; set; }

		public bool Equals(ContactData other)
		{
			if (Object.ReferenceEquals(other, null))
			{
				return false;
			}
			if (Object.ReferenceEquals(this, other))
			{
				return true;
			}
			return Lastname == other.Lastname && Firstname == other.Firstname;
		}
		public override int GetHashCode()
		{
			return 0;
		}
		public override string ToString()
		{
			return "firstname = " + Firstname + " lastname = " + Lastname;
		}
		public int CompareTo(ContactData other)
		{
			if (object.ReferenceEquals(other, null))
			{
				return 1;
			}
			return Firstname.CompareTo(other.Firstname) + Lastname.CompareTo(other.Lastname);
		}
	}
}
