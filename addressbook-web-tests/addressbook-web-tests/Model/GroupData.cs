﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
	[Table(Name = "group_list")]
	public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
	{
		public GroupData()
		{
		}

		public GroupData(string name)
		{
			Name = name;
		}
		[Column(Name = "group_name")]
		public string Name { get; set; }
		[Column(Name = "group_header")]
		public string Header { get; set; }
		[Column(Name = "group_footer")]
		public string Footer { get; set; }
		[Column(Name = "group_id"), PrimaryKey, Identity]
		public string Id { get; set; }

		[Column(Name = "deprecated")]
		public string Deprecated { get; set; }

		public static List<GroupData> GetAll()
		{
			using (AddressBookDB db = new AddressBookDB())
			{
				return (from g in db.Groups.Where(x => x.Deprecated == "0000 - 00 - 00 00:00:00") select g).ToList();
			}
		}

		public List<ContactData> GetContacts()
		{
			using (AddressBookDB db = new AddressBookDB())
			{
				return (from c in db.Contacts 
						from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000 - 00 - 00 00:00:00")
						select c).Distinct().ToList();
			}
		}


		public bool Equals(GroupData other)
		{
			if (Object.ReferenceEquals(other, null))
			{
				return false;
			}
			if (Object.ReferenceEquals(this, other))
			{
				return true;
			}
			return Name == other.Name;
		}
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
		public override string ToString()
		{
			return "name=" + Name + "\nheader=" + Header + "\nfooter=" + Footer;
		}

		//Сравнивает текущий экземпляр с другим объектом того же типа и возвращает целое число, 
		//которое показывает, расположен ли текущий экземпляр перед, после или на той же позиции в порядке сортировки, что и другой объект.
		public int CompareTo(GroupData other)
		{
			if (Object.ReferenceEquals(other, null))
			{
				return 1;
			}
			return Name.CompareTo(other.Name);
		}
	}
}
