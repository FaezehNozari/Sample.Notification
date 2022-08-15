namespace sample.notification
{
    public class ProviderService
    {
        private static List<Type> GetProvider()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
           .SelectMany(s => s.GetTypes())
           .Where(w => typeof(INotificationProvider).IsAssignableFrom(w) && w.IsClass && w.IsAbstract is false)
           .ToList();
        }

        private static INotificationProvider CreateInstance(Type type) => Activator.CreateInstance(type) as INotificationProvider;

        public static List<INotificationProvider> ActiveProviders()
        {
            var provider = GetProvidersInstance();
            var activeProvider = provider.Where(a => a.IsActive == true).ToList();
            return activeProvider;

        }

        private static List<INotificationProvider> GetProvidersInstance()
        {
            var providers = GetProvider();
            if (providers is null)
                Console.WriteLine(" Provider is not available");

            List<INotificationProvider> providersInstance = new();

            foreach (var provider in providers)
            {
                var providerInstance = CreateInstance(provider);
                providersInstance.Add(providerInstance);
            }

            return providersInstance;
        }

        public static Provider GetNextProvider(INotificationProvider provider)
        {
            return provider switch
            {
                FaraPayamakProvider => Provider.rahyab,
                RahyabProvider => Provider.farapayamak,
                _ => Provider.rahyab,
            };
        }

    }
}
