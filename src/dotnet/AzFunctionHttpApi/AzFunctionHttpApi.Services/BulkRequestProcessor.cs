using AzFunctionHttpApi.Services.Interfaces;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Logging;


namespace AzFunctionHttpApi.Services
{
    public class BulkRequestProcessor : IBulkRequestProcessor
    {
        private readonly ILogger<BulkRequestProcessor> _logger;
        private readonly TelemetryClient _telemetryClient;


        public BulkRequestProcessor(ILogger<BulkRequestProcessor> logger, TelemetryConfiguration telemetryConfiguration)
        {
            _logger = logger;
            _telemetryClient = new TelemetryClient(telemetryConfiguration);
        }

        public async Task<int> DoSomethingAsync()
        {
            _logger.LogInformation("BulkRequestProcessor.DoSomethingAsync()");
            _telemetryClient.TrackEvent("Inside the BulkRequestProcessor");
            return 5;
        }
        public int DoSomething()
        {
            _logger.LogInformation("BulkRequestProcessor.DoSomething()");
            _telemetryClient.TrackEvent("Inside the BulkRequestProcessor");
            return 10;
        }
    }
}
