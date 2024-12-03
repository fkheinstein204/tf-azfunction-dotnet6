using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

using AzFnApplication.Services;
using AzFnApplication.Services.Interfaces;



[assembly: FunctionsStartup(typeof(AzFnApplication.Startup))]
namespace AzFnApplication
{
    public class Startup : FunctionsStartup
    {
        public Startup() 
        {                  
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IBulkRequestProcessor, BulkRequestProcessor>();
        }
    }
}
