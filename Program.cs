using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Storage.Blobs;
using Configuration;

class Program
{
    private static readonly string blobUrl = AppConfiguration.BlobUrl;
    static async Task Main(string[] args)
    {
        var blobClient = new BlobClient(new Uri(blobUrl), new DefaultAzureCredential());

        Console.WriteLine("Conectando al blob...");

        try
        {
            var response = await blobClient.DownloadAsync();

            using (var streamReader = new StreamReader(response.Value.Content))
            {
                string blobContent = await streamReader.ReadToEndAsync();
                Console.WriteLine("Blob content");
                Console.WriteLine(blobContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the blob: {ex.Message}");
        }
    }
}
