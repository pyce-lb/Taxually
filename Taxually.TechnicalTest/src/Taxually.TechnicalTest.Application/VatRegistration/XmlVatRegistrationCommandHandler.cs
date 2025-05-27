namespace Taxually.TechnicalTest.Application.VatRegistration;

public sealed class XmlVatRegistrationCommandHandler : QueueVatRegistrationCommandHandler
{
    public const string QueueName = "vat-registration-xml";

    public XmlVatRegistrationCommandHandler(ITaxuallyQueueClient queueClient, IXmlSerializer<VatRegistrationCommand> serializer)
        : base(queueClient, serializer) { }

    public override async Task HandleAsync(VatRegistrationCommand command, CancellationToken cancellationToken = default)
    {
        string xml = Serializer.Serialize(command);
        await QueueClient.EnqueueAsync(QueueName, xml, cancellationToken);
    }
}
