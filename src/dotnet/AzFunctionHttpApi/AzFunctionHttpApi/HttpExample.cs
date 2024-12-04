using AzFunctionHttpApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

using AzFunctionHttpApi.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace AzFunctionHttpApi
{
    public class HttpExample
    {
        private readonly ILogger<HttpExample> _logger;
        private readonly IBulkRequestProcessor _bulkRequestProcessor;

        public HttpExample(ILogger<HttpExample> logger, IBulkRequestProcessor bulkRequestProcessor)
        {
            _logger = logger;
            _bulkRequestProcessor = bulkRequestProcessor;
        }
                
        
        [Function("HttpExample")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var myNumber = _bulkRequestProcessor.DoSomething();
            _logger.LogInformation($"Here's my number: {myNumber}");

            return new OkObjectResult("Welcome to Azure Functions!");
        }
        
        

        [Function("HttpExample2")]
        public async Task<IActionResult> Run2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var myNumber = await _bulkRequestProcessor.DoSomethingAsync();

            _logger.LogInformation($"Here's my number: {myNumber}");


            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully. My number was {myNumber}";

            return new OkObjectResult(responseMessage);
        }
        
    }
}
