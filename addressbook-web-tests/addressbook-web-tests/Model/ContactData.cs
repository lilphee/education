using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
	public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
	{
		public ContactData(string firstname, string lastname)
		{
			Firstname = firstname;
			Lastname = lastname;
		}

		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Nickname { get; set; }
		public string Address { get; set; }
		public string HomePhone { get; set; }
		public string MobilePhone { get; set; }
		public string Workphone { get; set; }
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
