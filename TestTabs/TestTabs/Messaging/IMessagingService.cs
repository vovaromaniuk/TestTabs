using System;
namespace TestTabs.Messaging
{
	public interface IMessagingService
	{
		void Send<TMessage>(TMessage message);
        void Subscribe<TMessage>(Action<TMessage> onReceived);

		// TODO: add unsubscribe
    }
}

