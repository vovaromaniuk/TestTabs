using System;
using System.Collections.ObjectModel;
using TestTabs.Models;
using TestTabs.MVVM;
using TestTabs.Services;

namespace TestTabs.Pages.Listing
{
	public class ItemsListPageViewModelBase : BaseViewModel
    {
        private bool _inited;

        protected readonly IDataService _dataService;

        private ObservableCollection<EmployeeItem> _items = new ObservableCollection<EmployeeItem>();
        public ObservableCollection<EmployeeItem> Items
        {
            get => _items;
            set => SetField(ref _items, value);
        }

        public ItemsListPageViewModelBase(IDataService dataService)
            => _dataService = dataService;


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
                    // TODO: use another aproach
                    foreach (var item in loadedItems)
                        Items.Add(item);
                }
                else
                {
                    // TODO: display alert
                }
            }
        }
    }
}

