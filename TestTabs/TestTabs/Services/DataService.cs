using System;
using TestTabs.Models;

namespace TestTabs.Services
{
    public class DataService : IDataService
	{
        private static IList<EmployeeItem> _cachedItems;

        private readonly IHttpRequestSender _httpRequestSender;

        public DataService(IHttpRequestSender httpRequestSender)
            => _httpRequestSender = httpRequestSender;

        public async Task<IList<EmployeeItem>> GetItems()
        {
            if(_cachedItems?.Any() == true)
            {
                return _cachedItems;
            }
            else
            {
                var response = await _httpRequestSender.GetAsync<EmployeeItemsApiResponse>(Constants.ApiEndpoint);

                if (response.Success)
                {
                    _cachedItems = response.Result?.Data;
                }
            }

            return _cachedItems;
        }
    }
}

