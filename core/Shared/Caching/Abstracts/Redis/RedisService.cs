﻿using StackExchange.Redis;

namespace Shared.Caching.Abstracts.Redis
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _redis;
        public IDatabase Database => _redis.GetDatabase();

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
            _redis = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        }
    }
}
