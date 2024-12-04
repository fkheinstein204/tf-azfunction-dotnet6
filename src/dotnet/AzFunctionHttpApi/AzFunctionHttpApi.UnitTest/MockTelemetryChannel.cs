using System;
using Microsoft.ApplicationInsights.Channel;

namespace AzFunctionHttpApi.UnitTest
{
    public class MockTelemetryChannel : ITelemetryChannel
    {
        public IList<ITelemetry> Items
        {
            get;
            private set;
        }

        public bool? DeveloperMode { get; set; }
        public string EndpointAddress { get; set; }

        public void Dispose()
        {
        }

        public void Flush()
        {
        }

        public void Send(ITelemetry item)
        {
        }
    }
}
