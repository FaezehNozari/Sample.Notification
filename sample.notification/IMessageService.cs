namespace sample.notification
{
    public interface IMessageService
    {
        void Send(string to, string message, INotificationProvider provider);
    }
}
