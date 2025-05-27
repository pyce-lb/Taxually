using System.Net;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Taxually.TechnicalTest.Tests.Integration.Controllers;

public sealed class VatRegistrationControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private const string Url = "api/vatregistration";

    private readonly WebApplicationFactory<Program> _factory;
    private readonly StringBuilder _requestBuilder = new StringBuilder("""
        {
          "companyId": "company-id",
          "companyName": "Taxually"
        """);

    public VatRegistrationControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    private string CreateRequest(string? country)
    {
        if (country is not null)
        {
            _requestBuilder.AppendLine(",");
            _requestBuilder.Append($"\"country\": \"{country}\"");
        }
        _requestBuilder.Append('}');

        return _requestBuilder.ToString();
    }

    [Theory]
    [InlineData("GB")]
    [InlineData("FR")]
    [InlineData("DE")]
    public async Task Post_ValidRequest_Ok(string country)
    {
        // Arrange
        string request = CreateRequest(country);
        HttpClient client = _factory.CreateClient();
        var content = new StringContent(request, Encoding.UTF8, "application/json");

        // Act
        HttpResponseMessage response = await client.PostAsync(Url, content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("HU")]
    public async Task Post_InvalidCountry_BadRequest(string? country)
    {
        // Arrange
        string request = CreateRequest(country);
        HttpClient client = _factory.CreateClient();
        var content = new StringContent(request, Encoding.UTF8, "application/json");

        // Act
        HttpResponseMessage response = await client.PostAsync(Url, content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public async Task Post_InvalidCompanyName_BadRequest(string? companyName)
    {
        // Arrange
        var requestBuilder = new StringBuilder("""
            {
              "companyId": "company-id",
              "country": "GB"
            """);

        if (companyName is not null)
        {
            requestBuilder.AppendLine(",");
            requestBuilder.Append($"\"companyName\": \"{companyName}\"");
        }
        requestBuilder.Append('}');

        string request = requestBuilder.ToString();
        HttpClient client = _factory.CreateClient();
        var content = new StringContent(request, Encoding.UTF8, "application/json");

        // Act
        HttpResponseMessage response = await client.PostAsync(Url, content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public async Task Post_InvalidCompanyId_BadRequest(string? companyId)
    {
        // Arrange
        var requestBuilder = new StringBuilder("""
            {
              "companyName": "Taxually",
              "country": "GB"
            """);

        if (companyId is not null)
        {
            requestBuilder.AppendLine(",");
            requestBuilder.Append($"\"companyId\": \"{companyId}\"");
        }
        requestBuilder.Append('}');

        string request = requestBuilder.ToString();
        HttpClient client = _factory.CreateClient();
        var content = new StringContent(request, Encoding.UTF8, "application/json");

        // Act
        HttpResponseMessage response = await client.PostAsync(Url, content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
