using System;
using static Microsoft.Maui.Controls.Internals.Profile;

namespace TestTabs.Models
{
	public class EmployeeItemsApiResponse
	{
        public string Status { get; set; }
        public List<EmployeeItem> Data { get; set; }
        public string Message { get; set; }
    }
}

