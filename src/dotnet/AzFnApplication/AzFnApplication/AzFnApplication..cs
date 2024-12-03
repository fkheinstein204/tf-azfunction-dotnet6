using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using AzFnApplication.Services.Interfaces;


namespace AzFnApplication
{
    public class AzFnApplication
    {

        private readonly IBulkRequestProcessor _bulkRequestProcessor;

        public AzFnApplication(IBulkRequestProcessor bulkRequestProcessor)
        {
            _bulkRequestProcessor = bulkRequestProcessor;
        }


        [FunctionName("AzFnApplication")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            var myNumber = await _bulkRequestProcessor.DoSomethingAsync();
            log.LogInformation($"Here's my number: {myNumber}");



            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
