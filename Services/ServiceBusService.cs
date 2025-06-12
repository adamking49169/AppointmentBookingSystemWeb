using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

public class ServiceBusService
{
    private readonly string _connectionString;
    private readonly string _queueName;
    private readonly ServiceBusClient _client;
    private readonly ServiceBusSender _sender;

    public ServiceBusService(IConfiguration config)
    {
        _connectionString = config["AzureServiceBus:ConnectionString"]
        ?? throw new ArgumentNullException("Service Bus connection string is missing in config.");
        _queueName = config["AzureServiceBus:QueueName"]
            ?? throw new ArgumentNullException("Queue name is missing in config.");

        _client = new ServiceBusClient(_connectionString);
        _sender = _client.CreateSender(_queueName);
    }

    public async Task SendMessageAsync(string message)
    {
        ServiceBusMessage busMessage = new(message);
        await _sender.SendMessageAsync(busMessage);
    }

    public async Task<string> ReceiveMessageAsync()
    {
        var receiver = _client.CreateReceiver(_queueName);
        var receivedMessage = await receiver.ReceiveMessageAsync();
        if (receivedMessage != null)
        {
            string body = receivedMessage.Body.ToString();
            await receiver.CompleteMessageAsync(receivedMessage);
            return body;
        }
        return "No messages found.";
    }
}