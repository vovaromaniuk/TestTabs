using TestTabs.Messaging;

namespace TestTabs.Pages.Tabs;

public partial class TabsPage : TabbedPage
{
    public TabsPage(IMessagingService messagingService)
	{
		InitializeComponent();
		messagingService.Subscribe<OpenSecondTabMessage>(OpenSecondTab);

    }

	private void OpenSecondTab(OpenSecondTabMessage message)
	{
		this.CurrentPage = this.Children[1];
	}
}
