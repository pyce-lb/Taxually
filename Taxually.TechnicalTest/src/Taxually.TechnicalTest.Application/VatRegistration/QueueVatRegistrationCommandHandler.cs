namespace Taxually.TechnicalTest.Application.VatRegistration;

public abstract class QueueVatRegistrationCommandHandler : ICommandHandler<VatRegistrationCommand>
{
    protected QueueVatRegistrationCommandHandler(ITaxuallyQueueClient queueClient, ISerializer<VatRegistrationCommand> serializer)
    {
        QueueClient = queueClient;
        Serializer = serializer;
    }

    protected ITaxuallyQueueClient QueueClient { get; }
    protected ISerializer<VatRegistrationCommand> Serializer { get; }

    public abstract ValueTask HandleAsync(VatRegistrationCommand command, CancellationToken cancellationToken = default);
}
