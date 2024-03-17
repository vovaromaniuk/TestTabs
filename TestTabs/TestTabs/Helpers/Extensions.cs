using System;
using System.Collections.Concurrent;
using TestTabs.MVVM;

namespace TestTabs.Helpers
{
	public static class Extensions
	{
		public static void RegisterPageAndViewModel<TPage, TViewModel>(this MauiAppBuilder builder)
			where TPage : Page
			where TViewModel : BaseViewModel
		{
            builder.Services.AddTransient<TPage>();
            builder.Services.AddTransient<TViewModel>();

            NavigationTypesHolder.AddOrUpdate<TPage, TViewModel>();
        }

        public static TPage ResolvePage<TPage>(this IServiceProvider services, object arguments = null)
            where TPage : Page
        {
            // TODO: add try catch + logging 

            var page = services.GetRequiredService<TPage>();

            if(page is not null)
            {
                var vmType = NavigationTypesHolder.GetViewModelTypeForPage<TPage>();

                if(vmType != null)
                {
                    var vm = services.GetRequiredService(vmType);


                    page.BindingContext = vm;
                }
            }

            return page;
        }

    }

    
}

