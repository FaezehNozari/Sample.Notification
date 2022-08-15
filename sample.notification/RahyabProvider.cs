namespace sample.notification
{
    class RahyabProvider : INotificationProvider
    {
        public bool IsActive => true;

        public Provider GetProviderName()
        => Provider.rahyab;

        public void Send(string to, string message)
        {
            Console.WriteLine($"{GetProviderName()} send {message} to {to}");
        }
    }
}
