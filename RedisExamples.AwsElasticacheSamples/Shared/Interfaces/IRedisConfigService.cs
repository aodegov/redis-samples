using StackExchange.Redis.Extensions.Core.Configuration;

namespace RedisExamples.AwsElasticacheSamples.Shared.Interfaces
{
    public interface IRedisConfigService
    {
        /// <summary>
        /// Bind json config file data to Cognito configuration model
        /// </summary>
        /// <returns cref="RedisConfiguration">CognitoConfigurationModel</returns>
        RedisConfiguration GetConfiguration();
    }
}
