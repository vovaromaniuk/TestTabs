using System;
using TestTabs.Helpers;
using TestTabs.MVVM;

namespace TestTabs.MVVM
{
	public class NavigationService : INavigationService
    {
        readonly IServiceProvider _services;

        private INavigation _navigation;
        protected INavigation? Navigation => _navigation ?? (_navigation = Application.Current?.MainPage?.Navigation);

        public NavigationService(IServiceProvider services)
           => _services = services;

        public async Task PuhAsync<TPage>(object? parameter = null) where TPage : Page
        {
            var page = _services.ResolvePage<TPage>(parameter);

            if (page is not null)
            {
                await Navigation?.PushAsync(page);
            }
        }
    }
}

