using AzFunctionHttpApi.Services.Interfaces;

namespace AzFunctionHttpApi.Services
{
    public class BulkRequestProcessor : IBulkRequestProcessor
    {
        public async Task<int> DoSomethingAsync()
        {
            return 5;
        }
        public int DoSomething()
        {
            return 5;
        }
    }
}
