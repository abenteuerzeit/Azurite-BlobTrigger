using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Troubleshooting.FunctionApp
{
    public class BlobTrigger
    {
        private readonly ILogger<BlobTrigger> _logger;

        public BlobTrigger(ILogger<BlobTrigger> logger)
        {
            _logger = logger;
        }

        [Function(nameof(BlobTrigger))]
        public async Task Run([BlobTrigger("reproduction/{name}", Connection = "e29097_STORAGE")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
