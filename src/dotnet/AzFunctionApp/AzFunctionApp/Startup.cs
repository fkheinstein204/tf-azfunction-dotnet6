using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


//[assembly: FunctionsStartup(typeof(AzFunctionApp.Startup))]

namespace AzFunctionApp
{
    public class Startup : FunctionsStartup
    {
        public Startup()
        {
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();

            // builder.Services.AddSingleton<IBulkRequestProcessor, BulkRequestProcessor>();
        }
    }
}
