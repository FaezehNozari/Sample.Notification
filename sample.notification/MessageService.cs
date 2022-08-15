namespace sample.notification
{
    class MessageService : IMessageService
    {
        public void Send(string to, string message, INotificationProvider provider)
        {
            provider.Send(to, message);
        }
    }
}
