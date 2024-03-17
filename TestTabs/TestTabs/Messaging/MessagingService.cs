using System;
namespace TestTabs.Messaging
{
    [Obsolete]
	public class MessagingService : IMessagingService
    {
        // TODO: MessagingCenter is obsolete, use smth else

        public void Send<TMessage>(TMessage message)
        {
            MessagingCenter.Instance.Send(this, typeof(TMessage).Name, message);
        }

        public void Subscribe<TMessage>(Action<TMessage> onReceived)
        {
            MessagingCenter.Subscribe<MessagingService, TMessage>(this, typeof(TMessage).Name, (o,e) =>
            {
                onReceived?.Invoke(e);
            });
        }
    }
}

