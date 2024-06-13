using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Interfaces.RedisCache
{
    public interface IRedisCacheService
    {
        Task<T>GetAsync<T>(string key);
        Task<T> SetAsync<T>(string key, T value,DateTime? expirarionTime=null);
    }
}
