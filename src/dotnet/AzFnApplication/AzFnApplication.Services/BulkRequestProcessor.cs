using AzFnApplication.Services.Interfaces;

namespace AzFnApplication.Services
{
    public class BulkRequestProcessor : IBulkRequestProcessor
    {
        public async Task<int> DoSomethingAsync()
        {
            return 5;
        }
    }
}
