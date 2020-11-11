using Microsoft.Extensions.Configuration;

namespace dotnetcorewebapp.webtests.Helpers
{
    public static class Configuration
    {
        public static IConfigurationRoot GetConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static TestConfiguration GetApplicationConfiguration(string outputPath)
        {
            var configuration = new TestConfiguration();

            var iConfig = GetConfigurationRoot(outputPath);

            ConfigurationBinder.Bind(iConfig, configuration);
            
            return configuration;
        }
    }

    public class TestConfiguration
    {
        public string testUrl { get; set; }
    }
}
