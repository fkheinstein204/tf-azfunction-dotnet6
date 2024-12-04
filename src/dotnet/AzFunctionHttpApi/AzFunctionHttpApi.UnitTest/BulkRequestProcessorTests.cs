using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzFunctionHttpApi.Services;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Xunit.Abstractions;

namespace AzFunctionHttpApi.UnitTest
{
    public class BulkRequestProcessorTests
    {
        private readonly ILogger<BulkRequestProcessor> _logger;
        private readonly TelemetryConfiguration _telemetryConfiguration;

        public BulkRequestProcessorTests(ITestOutputHelper output)
        {
            _logger = new XunitLogger<BulkRequestProcessor>(output);

            _telemetryConfiguration = new TelemetryConfiguration
            {
                TelemetryChannel = new MockTelemetryChannel(),
                InstrumentationKey = Guid.NewGuid().ToString()
            };
        }



        [Trait("Category", "Unit")]
        [Fact]
        public async void Test1()
        {
            var service = new BulkRequestProcessor(_logger, _telemetryConfiguration);

            var myNumber = await service.DoSomethingAsync();
            
            Assert.Equal(5, myNumber);
        }
    }
}
