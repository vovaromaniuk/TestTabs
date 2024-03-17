using System;
using TestTabs.Models;

namespace TestTabs.Messaging
{
	public class OpenSecondTabMessage
	{
		public readonly EmployeeItem Item;

		public OpenSecondTabMessage(EmployeeItem item)
			=> Item = item;
	}
}

