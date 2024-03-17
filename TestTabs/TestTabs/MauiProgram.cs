using Microsoft.Extensions.Logging;
using TestTabs.Helpers;
using TestTabs.MVVM;
using TestTabs.Pages.Details;
using TestTabs.Pages.Listing;
using TestTabs.Pages.Tabs;

namespace TestTabs;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>((services) =>
			{
				var tabsPage = services.ResolvePage<TabsPage>();

				var list = services.ResolvePage<ItemsListPage>();
				var details = services.ResolvePage<ItemDetailsPage>();

				tabsPage.Children.Add(list);
				tabsPage.Children.Add(details);

                return new App(new NavigationPage(tabsPage));
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<INavigationService, NavigationService>();

		builder.RegisterPageAndViewModel<TabsPage, TabsPageViewModel>();
        builder.RegisterPageAndViewModel<ItemsListPage, ItemsListPageViewModel>();
        builder.RegisterPageAndViewModel<ItemDetailsPage, ItemDetailsPageViewModel>();
		
        

        return builder.Build();
	}
}

