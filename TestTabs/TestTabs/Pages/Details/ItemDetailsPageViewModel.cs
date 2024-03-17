using System;
using System.Collections.ObjectModel;
using TestTabs.Messaging;
using TestTabs.Models;
using TestTabs.MVVM;

namespace TestTabs.Pages.Details
{
	public class ItemDetailsPageViewModel : BaseViewModel
	{
        private EmployeeItem _item;
        public EmployeeItem Item
        {
            get => _item;
            set => SetField(ref _item, value);
        }

        public ItemDetailsPageViewModel(IMessagingService messagingService)
		{
            messagingService.Subscribe<OpenSecondTabMessage>(OnItemSelected);
        }

        private void OnItemSelected(OpenSecondTabMessage message)
        {
            Item = message?.Item;
        }
	}
}

