using StackExchange.Redis;
using System;
using System.IO;

namespace RedisExamples.AwsElasticacheSamples
{
    class RedisProcessor
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            var log = new StringWriter();
            ConfigurationOptions option = new ConfigurationOptions
            {
                AbortOnConnectFail = false
                //ConnectTimeout = 20000
            };
            option.EndPoints.Add("vehiclehub-cbb-redis.flijwf.ng.0001.cac1.cache.amazonaws.com:6379");
            return ConnectionMultiplexer.Connect(option, log);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
