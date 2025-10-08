using DotNetEnv;

namespace Configuration
{
    public static class AppConfiguration
    {
        static AppConfiguration()
        {
            Env.Load();
        }

        public static string BlobUrl => 
            Environment.GetEnvironmentVariable("AZURE_BLOB_URL") 
            ?? throw new InvalidOperationException("AZURE_BLOB_URL environment variable is not set");

        public static void ValidateConfiguration()
        {
            try
            {
                _ = BlobUrl;
                Console.WriteLine("✓ Configuration validation passed");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"✗ Configuration validation failed: {ex.Message}");
                throw;
            }
        }
    }
}