using System;
namespace TestTabs.Services
{
	public interface IHttpRequestSender
	{
        Task<(TReturn Result, bool Success)> GetAsync<TReturn>(string endpoint);
    }
}

