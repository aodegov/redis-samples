using RedisExamples.AwsElasticacheSamples.Shared.Interfaces;
using RedisExamples.AwsElasticacheSamples.Shared.Models;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisExamples.AwsElasticacheSamples.Services
{
    public class RedisProcessor : IRedisProcessor
    {
        private readonly IRedisCacheClient _redisCacheClient;
        public RedisProcessor(IRedisCacheClient redisCacheClient)
        {
            _redisCacheClient = redisCacheClient;
        }

        public async Task ProcessAllCacheData()
        {
            await AddProductAsync();
            var product = await GetProductAsync();
            Console.WriteLine(product.ToString());
            var products = await GetAllProductsAsync();
            Console.WriteLine(products.ToString());
        }

        public async Task<Product> AddProductAsync()
        {
            var product = new Product()
            {
                Id = 1,
                Name = "hand sanitizer",
                Price = 100
            };

            bool isAdded = await _redisCacheClient.Db0.AddAsync("Product", product, DateTimeOffset.Now.AddMinutes(10));

            return product;
        }

        public async Task<List<Tuple<string, Product>>> AddAllProductAsync()
        {

            var values = new List<Tuple<string, Product>>
            {
                new Tuple<string, Product>("Product1", new Product()
                {
                    Id = 1,
                    Name = "hand sanitizer 1",
                    Price = 100
                }),
                new Tuple<string, Product>("Product2",new Product()
                {
                    Id = 2,
                    Name = "hand sanitizer 2",
                    Price = 200
                }),
                new Tuple<string, Product>("Product3", new Product()
                {
                    Id = 3,
                    Name = "hand sanitizer 3",
                    Price = 300
                })
            };

            await _redisCacheClient.Db0.AddAllAsync(values, DateTimeOffset.Now.AddMinutes(4));

            return values;
        }

        public async Task<Product> GetProductAsync()
        {
            return await _redisCacheClient.Db0.GetAsync<Product>("Product");
        }

        public async Task<IDictionary<string, Product>> GetAllProductsAsync()
        {
            List<string> allKeys = new List<string>()
            {
                "Product1","Product2","Product3"
            };

            return await _redisCacheClient.Db0.GetAllAsync<Product>(allKeys);
        }

    }
}
