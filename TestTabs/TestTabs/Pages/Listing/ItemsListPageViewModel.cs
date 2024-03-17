using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TestTabs.Messaging;
using TestTabs.Models;
using TestTabs.MVVM;
using TestTabs.Pages.Details;
using TestTabs.Services;

namespace TestTabs.Pages.Listing
{
	public class ItemsListPageViewModel : ItemsListPageViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessagingService _messagingService;

        private ICommand _openHorizontalListCommand;
        public ICommand OpenHorizontalListCommand => _openHorizontalListCommand ?? (_openHorizontalListCommand = new Command(OpenHorizontalList));

        private ICommand _openItemDetailsCommand;
        public ICommand OpenItemDetailsCommand => _openItemDetailsCommand ?? (_openItemDetailsCommand = new Command<object>(OpenItemDetails));

        public ItemsListPageViewModel(IDataService dataService,
            INavigationService navigationService,
            IMessagingService messagingService) : base(dataService)
        {
            _navigationService = navigationService;
            _messagingService = messagingService;
        }

        private void OpenItemDetails(object obj)
        {
            if (obj is EmployeeItem item)
                _messagingService.Send(new OpenSecondTabMessage(item));

            // TODO: log
        }

        private async void OpenHorizontalList()
        {
            await _navigationService.PuhAsync<HorizontalItemsListPage>();
        }
    }
}

