using Microsoft.Extensions.Configuration;
using RedisExamples.AwsElasticacheSamples.Shared.Interfaces;
using StackExchange.Redis.Extensions.Core.Configuration;
using System.IO;

namespace RedisExamples.AwsElasticacheSamples.Services
{
    public class RedisConfigService: IRedisConfigService
    {
        public RedisConfigService()
        {
        }
        public IConfigurationRoot GetJsonConfig() => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Shared/Configuration/redis-settings.json",
                optional: false,
                reloadOnChange: true).Build();

        public RedisConfiguration GetConfiguration()
        {
            var cognitoConfig = new RedisConfiguration();

            GetJsonConfig()
               .GetSection("CognitoSettings")
                .Bind(cognitoConfig);

            return cognitoConfig;
        }
    }
}
