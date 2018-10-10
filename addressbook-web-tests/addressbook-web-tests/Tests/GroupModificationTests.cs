using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupModificationTests : TestBase
	{
		[Test]
		public void GroupModificationTest()
		{
			GroupData  newData = new GroupData("modgroup");
			newData.Header = "111";
			newData.Footer = "222";

			app.Groups.Modify(1, newData);
		}
	}
}
