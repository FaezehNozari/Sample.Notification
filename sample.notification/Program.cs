using sample.notification;

var phoneNumbers = new string[] { "091111", "09222", "09333", "09444", "095555" };
var message = "sample message";
var activeProviders =ProviderService.ActiveProviders();


var provider = activeProviders.First();
MessageService messageService = new MessageService();
if (activeProviders.Count == 1)
{
    foreach (var phoneNumber in phoneNumbers)
    {
        messageService.Send(phoneNumber, message, provider);
    }
    return;
}

var ps = (phoneNumbers.Length * 50) / 100;
var lastPhoneNUmbers = new List<string>();
foreach (var phone in phoneNumbers.Take(ps))
{
    messageService.Send(phone, message, provider);
    lastPhoneNUmbers.Add(phone);
}
var nextProvider = ProviderService.GetNextProvider(provider);
var lastActiveProvider = activeProviders.First(x => x.GetProviderName() == nextProvider);
foreach (var phone in phoneNumbers.Except(lastPhoneNUmbers))
{
    messageService.Send(phone, message, lastActiveProvider);
}
return;
