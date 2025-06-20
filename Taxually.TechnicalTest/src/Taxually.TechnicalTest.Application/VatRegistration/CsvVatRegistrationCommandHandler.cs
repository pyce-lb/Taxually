﻿using System.Text;

namespace Taxually.TechnicalTest.Application.VatRegistration;

public sealed class CsvVatRegistrationCommandHandler : QueueVatRegistrationCommandHandler
{
    public const string QueueName = "vat-registration-csv";

    public CsvVatRegistrationCommandHandler(ITaxuallyQueueClient queueClient, ICsvSerializer<VatRegistrationCommand> serializer)
        : base(queueClient, serializer) { }

    public override async ValueTask HandleAsync(VatRegistrationCommand command, CancellationToken cancellationToken = default)
    {
        string csv = Serializer.Serialize(command);
        byte[] payload = Encoding.UTF8.GetBytes(csv);
        await QueueClient.EnqueueAsync(QueueName, payload, cancellationToken);
    }
}
