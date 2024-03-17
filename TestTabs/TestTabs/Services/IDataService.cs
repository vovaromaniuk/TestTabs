using System;
using TestTabs.Models;

namespace TestTabs.Services
{
	public interface IDataService
	{
		public Task<IList<EmployeeItem>> GetItems();
	}
}

