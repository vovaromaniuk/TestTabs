using System;
using System.Collections.Concurrent;
using TestTabs.MVVM;

namespace TestTabs.Helpers
{
    public static class NavigationTypesHolder
    {
        private static ConcurrentDictionary<Type, Type> _viewToVmDict = new ConcurrentDictionary<Type, Type>();

        public static void AddOrUpdate<TPage, TViewModel>() where TPage : Page
            where TViewModel : BaseViewModel
        {
            _viewToVmDict.AddOrUpdate(typeof(TPage), typeof(TViewModel), (key, existingVal) =>
            {
                return existingVal;
            });
        }

        public static Type GetViewModelTypeForPage<TPage>() where TPage : Page
        {
            if (_viewToVmDict.TryGetValue(typeof(TPage), out var vmType))
            {
                return vmType;
            }

            return null;
        }
    }
}

