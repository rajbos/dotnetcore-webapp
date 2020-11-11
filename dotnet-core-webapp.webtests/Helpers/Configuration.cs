using Microsoft.Extensions.Configuration;

namespace dotnetcorewebapp.webtests.Helpers
{
    public static class Configuration
    {
        public static IConfigurationRoot GetConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json", optional: true)
                .Build();
        }

        public static TestConfiguration GetApplicationConfiguration()
        {
            var configuration = new TestConfiguration();

            var iConfig = GetConfigurationRoot();

            ConfigurationBinder.Bind(iConfig, configuration);
            
            return configuration;
        }
    }

    public class TestConfiguration
    {
        public string testUrl { get; set; }
    }
}
