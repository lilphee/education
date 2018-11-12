using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
	public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
	{
		private string allPhones;
		private string allEmails;
		private string allData;

		public ContactData(string firstname, string lastname)
		{
			Firstname = firstname;
			Lastname = lastname;
		}

		public string Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Nickname { get; set; }

		public string Address { get; set; }

		public string HomePhone { get; set; }
		public string MobilePhone { get; set; }
		public string Workphone { get; set; }
		public string AllPhones
		{
			get
			{ if (allPhones != null)
				{
					return allPhones;
				}
				else
				{
					return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(Workphone)).Trim();
				}
			}
			set
			{
				allPhones = value;
			}
		}
		private string CleanUpPhone(string phone)
		{
			if (phone == null || phone == "")
			{
				return "";
			}
			return Regex.Replace(phone, "[ -()]", "") + "\r\n";
		}

		public string Email { get; set; }
		public string Email2 { get; set; }
		public string Email3 { get; set; }
		public string AllEmails
		{
			get
			{
				if (allEmails!= null)
				{
					return allEmails;
				}
				else
				{
					return (CleanUpMail(Email)+ CleanUpMail(Email2) + CleanUpMail(Email3)).Trim();
				}
			}
			set
			{
				allEmails = value;
			}
		}
		private string CleanUpMail(string mail)
		{
			if (mail == null || mail == "")
			{
				return "";
			}
			return Regex.Replace(mail, "[ ]", "") + "\r\n";
		}

		public string AllData
		{
			get
			{
				if (allData != null)
				{
					return allData;
				}
				else
				{
					return (Firstname + "\r\n" 
						+ Lastname + "\r\n"
						+ Address + "\r\n" 
						+ CleanUpPhone("H:" + HomePhone) + CleanUpPhone("M:" + MobilePhone) + CleanUpPhone("W:" + Workphone)
						+ CleanUpMail(Email) + CleanUpMail(Email2) + CleanUpMail(Email3))
						.Trim();
				}
			}
			set
			{
				allData = value;
			}
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
		//Сравнивает текущий экземпляр с другим объектом того же типа и возвращает целое число, 
		//которое показывает, расположен ли текущий экземпляр перед, после или на той же позиции в порядке сортировки, что и другой объект.
		public int CompareTo(ContactData other)
		{
			//условие сравнения
			if (object.ReferenceEquals(other, null))
			{
				return 1;
			}
			if (Lastname.CompareTo(other.Lastname) == 0)
			{
				return Firstname.CompareTo(other.Firstname);
			}
			return Lastname.CompareTo(other.Lastname);
		}
	}
}
