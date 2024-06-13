﻿using Api.Application.Interfaces.RedisCache;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDatabase _database;
        private readonly RedisCacheSettings _setting;
        public RedisCacheService(IOptions<RedisCacheSettings> options)
        {
            _setting = options.Value;
            var opt=ConfigurationOptions.Parse(_setting.ConnectionString);
            _redisConnection=ConnectionMultiplexer.Connect(opt);
            _database= _redisConnection.GetDatabase();
        }
        public async Task<T> GetAsync<T>(string key)
        {
            var value=await _database.StringGetAsync(key);
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expirarionTime = null)
        {
            TimeSpan timeUnitExpiration=expirarionTime.Value-DateTime.Now;
            await _database.StringSetAsync(key,JsonConvert.SerializeObject(value),timeUnitExpiration);

        }
    }
}
