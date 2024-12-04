
using AzFunctionHttpApi.Services.Interfaces;
using AzFunctionHttpApi.Services;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
//
//builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddLogging();
builder.Services.AddSingleton<IBulkRequestProcessor, BulkRequestProcessor>();

builder.Build().Run();
