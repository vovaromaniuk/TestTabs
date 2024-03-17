using System;
using TestTabs.Models;

namespace TestTabs.Services
{
    public class DataService : IDataService
	{
        private readonly IHttpRequestSender _httpRequestSender;


        public DataService(IHttpRequestSender httpRequestSender)
            => _httpRequestSender = httpRequestSender;

        public async Task<IList<EmployeeItem>> GetItems()
        {
            IList<EmployeeItem> result = null;

            var response = await _httpRequestSender.GetAsync<EmployeeItemsApiResponse>(Constants.ApiEndpoint);

            if(response.Success)
            {
                result = response.Result?.Data;
            }

            return result;
        }
    }
}

