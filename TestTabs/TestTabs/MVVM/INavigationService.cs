using System;
namespace TestTabs.MVVM
{
	public interface INavigationService
	{
		Task PuhAsync<TPage>(object? parameter = null) where TPage : Page;
	}
}

