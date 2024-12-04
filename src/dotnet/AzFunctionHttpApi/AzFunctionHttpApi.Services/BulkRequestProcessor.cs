using AzFunctionHttpApi.Services.Interfaces;
using Microsoft.Extensions.Logging;


namespace AzFunctionHttpApi.Services
{
    public class BulkRequestProcessor : IBulkRequestProcessor
    {
        private readonly ILogger<BulkRequestProcessor> _logger;

        public BulkRequestProcessor(ILogger<BulkRequestProcessor> logger)
        {
            _logger = logger;
        }

        public async Task<int> DoSomethingAsync()
        {
            _logger.LogInformation("BulkRequestProcessor.DoSomethingAsync()");
            return 5;
        }
        public int DoSomething()
        {
            _logger.LogInformation("BulkRequestProcessor.DoSomething()");
            return 10;
        }
    }
}
