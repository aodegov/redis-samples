using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisExamples.AwsElasticacheSamples.Services;
using RedisExamples.AwsElasticacheSamples.Shared.Interfaces;
using StackExchange.Redis.Extensions.Newtonsoft;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RedisExamples.AwsElasticacheSamples
{
    class Program
    {
        static async Task Main(string[] args) 
        {
            var builder = CreateHostBuilder(args).Build();
            var service = builder.Services.GetService<IRedisProcessor>();
            Console.Read();
            //.Services.GetService<IRedisProcessor>().ProcessAllCacheData(); 
        }

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {

                    IRedisConfigService redisConfigService = new RedisConfigService();
                    var redisConfiguration = redisConfigService.GetConfiguration();
                    services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);

                   services.AddTransient<IRedisProcessor, RedisProcessor>();
                  
                  
                });
    }
}
