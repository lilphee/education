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
			this.firstname = firstname;
			this.lastname = lastname;
		}

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
			return Firstname == other.Firstname && Lastname == other.Lastname;
		}

		public override int GetHashCode()
		{
			return Firstname.GetHashCode();
		}

		public override string ToString()
		{
			return "firstname and lastname=" + Firstname && Lastname;
		}

		public string Firstname
		{
			get
			{
				return firstname;
			}
			set
			{
				firstname = value;
			}
		}
		public string Lastname
		{
			get
			{
				return lastname;
			}
			set
			{
				lastname = value;
			}
		}
		public string Nickname
		{
			get
			{
				return nickname;
			}
			set
			{
				nickname = value;
			}
		}
	}
}
