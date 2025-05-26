using Microsoft.AspNetCore.HttpLogging;

const string HttpLoggingKey = $"{nameof(Microsoft.Extensions.Logging)}:{nameof(Microsoft.AspNetCore.HttpLogging)}";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<HttpLoggingOptions>(builder.Configuration.GetSection(HttpLoggingKey));

builder.Services.AddHttpLogging();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHttpLogging();

app.MapControllers();

app.Run();
