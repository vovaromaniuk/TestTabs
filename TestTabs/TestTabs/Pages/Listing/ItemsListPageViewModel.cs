using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TestTabs.Models;
using TestTabs.MVVM;
using TestTabs.Pages.Details;
using TestTabs.Services;

namespace TestTabs.Pages.Listing
{
	public class ItemsListPageViewModel : BaseViewModel
	{
        private bool _inited;

		private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        private ICommand _openHorizontalListCommand;
        public ICommand OpenHorizontalListCommand => _openHorizontalListCommand ?? (_openHorizontalListCommand = new Command(OpenHorizontalList));

        private ICommand _openItemDetailsCommand;
        public ICommand OpenItemDetailsCommand => _openItemDetailsCommand ?? (_openItemDetailsCommand = new Command<object>(OpenItemDetails));

        private ObservableCollection<EmployeeItem> _items = new ObservableCollection<EmployeeItem>();
        public ObservableCollection<EmployeeItem> Items
        {
            get => _items;
            set => SetField(ref _items, value);
        }


        public ItemsListPageViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
        }

        public override async void NavigatedTo(object parameter)
        {
            base.NavigatedTo(parameter);

            if (!_inited)
            {
                _inited = true;

                IsLoading = true;
                var loadedItems = await _dataService.GetItems();
                IsLoading = false;

                Items.Clear();

                if (loadedItems?.Any() == true)
                {
                    foreach (var item in loadedItems)
                        Items.Add(item);
                }
                else
                {
                    // TODO: display alert
                }
            }
        }

        private void OpenItemDetails(object obj)
        {

        }

        private async void OpenHorizontalList()
        {
            await _navigationService.PuhAsync<ItemDetailsPage>();
        }
    }
}

