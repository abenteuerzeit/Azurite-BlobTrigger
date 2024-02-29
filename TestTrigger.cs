using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class TestTrigger
    {
        private readonly ILogger<TestTrigger> _logger;

        public TestTrigger(ILogger<TestTrigger> logger)
        {
            _logger = logger;
        }

        [Function(nameof(TestTrigger))]
        public async Task Run([BlobTrigger("test/{name}", Connection = "e29097_STORAGE")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
