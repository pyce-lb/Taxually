﻿using Taxually.TechnicalTest.Application;

namespace Taxually.TechnicalTest.Infrastructure
{
    public sealed class TaxuallyHttpClient : ITaxuallyHttpClient
    {
        public Task PostAsync<TRequest>(string url, TRequest request, CancellationToken cancellationToken = default)
        {
            // Actual HTTP call removed for purposes of this exercise
            return Task.CompletedTask;
        }
    }
}
