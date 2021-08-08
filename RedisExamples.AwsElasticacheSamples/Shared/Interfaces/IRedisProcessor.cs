using System.Threading.Tasks;

namespace RedisExamples.AwsElasticacheSamples.Shared.Interfaces
{
    public interface IRedisProcessor
    {
        Task ProcessAllCacheData();
    }
}
