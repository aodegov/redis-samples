using StackExchange.Redis;
using System;

namespace RedisExamples.AwsElasticacheSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase db = RedisProcessor.Connection.GetDatabase();
            bool result = db.StringSet("key-1", "val-08", TimeSpan.FromSeconds(600));
            string value = db.StringGet("key-1");
            Console.WriteLine($"Your value: {value}");
            Console.ReadKey();
        }
    }
}
