using TestTabs.Pages.Tabs;

namespace TestTabs;

public partial class App : Application
{
	public App(Page mainPage)
	{
		InitializeComponent();

		MainPage = mainPage;
	}
}

