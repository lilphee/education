using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
	[Table(Name = "addressbook")]
	public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
	{
		private string allPhones;
		private string allEmails;
		private string allData;

		public ContactData()
		{
		}
		public ContactData(string firstname, string lastname)
		{
			Firstname = firstname;
			Lastname = lastname;
		}
	
		[Column(Name = "id"), PrimaryKey, Identity]
		public string Id { get; set; }
		[Column(Name = "firstname")]
		public string Firstname { get; set; }
		[Column(Name = "lastname")]
		public string Lastname { get; set; }
		[Column(Name = "nickname")]
		public string Nickname { get; set; }
		[Column(Name = "address")]
		public string Address { get; set; }

		[Column(Name = "home")]
		public string HomePhone { get; set; }
		[Column(Name = "mobile")]
		public string MobilePhone { get; set; }
		[Column(Name = "work")]
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

		[Column(Name = "im")]
		public string Email { get; set; }
		[Column(Name = "im2")]
		public string Email2 { get; set; }
		[Column(Name = "im3")]
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


		public static List<ContactData> GetAll()
		{
			using (AddressBookDB db = new AddressBookDB())
			{
				return (from g in db.Contacts select g).ToList();
			}
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
