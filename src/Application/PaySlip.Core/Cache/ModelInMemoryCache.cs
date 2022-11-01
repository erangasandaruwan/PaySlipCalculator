using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PaySlip.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlip.Core.Cache
{
    public class ModelInMemoryCache<TModel, TKey> : ModelInMemoryCacheOptions<TModel, TKey>, IModelCache<TModel, TKey> where TModel : BaseModel<TKey> where TKey : struct
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ModelInMemoryCacheOptions<TModel, TKey>> _logger;

        public bool IsEnable => _isEnable;

        public bool IsLoggerEnable => _isLoggerEnable;

        public ModelInMemoryCache(IMemoryCache memoryCache,
            IConfiguration config, ILogger<ModelInMemoryCacheOptions<TModel, TKey>> logger) : base(config)
        {
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public bool TryGetValue(ModelCacheKey<TModel, TKey> key, out TModel model)
        {
            LogEvent(key.Value, CacheOperation.Read);
            return _memoryCache.TryGetValue<TModel>(key.Value, out model);
        }

        public bool TryGetValue(ModelCacheKey<TModel, TKey> key, out IEnumerable<TModel> models)
        {
            LogEvent(key.Value, CacheOperation.Read);
            return _memoryCache.TryGetValue<IEnumerable<TModel>>(key.Value, out models);
        }

        public void Set(ModelCacheKey<TModel, TKey> key, TModel models)
        {
            _memoryCache.Set(key.Value, models, GetMemoryCacheEntryOptions(key.Value));
            LogEvent(key.Value, CacheOperation.Create);
        }

        public void Set(ModelCacheKey<TModel, TKey> key, IEnumerable<TModel> models)
        {
            _memoryCache.Set(key.Value, models, GetMemoryCacheEntryOptions(key.Value));
            LogEvent(key.Value, CacheOperation.Create);
        }

        public void Reset(ModelCacheKey<TModel, TKey> key, TModel model, string reason = "")
        {
            _memoryCache.Remove(key.Value);
            LogEvent(key.Value, CacheOperation.Delete, Const.InitializeReset);
            _memoryCache.Set(key.Value, model, GetMemoryCacheEntryOptions(key.Value));
            LogEvent(key.Value, CacheOperation.Reset, reason);
        }

        public void Reset(ModelCacheKey<TModel, TKey> key, IEnumerable<TModel> models, string reason = "")
        {
            _memoryCache.Remove(key.Value);
            LogEvent(key.Value, CacheOperation.Delete, Const.InitializeReset);
            _memoryCache.Set(key.Value, models, GetMemoryCacheEntryOptions(key.Value));
            LogEvent(key.Value, CacheOperation.Reset, reason);
        }

        public void Remove(ModelCacheKey<TModel, TKey> key)
        {
            _memoryCache.Remove(key.Value);
            LogEvent(key.Value, CacheOperation.Delete);
        }

        public void Clear()
        {
            // Get the empty definition for the EntriesCollection
            var cacheEntriesCollectionDefinition =
                typeof(MemoryCache).GetProperty(Const.EntriesCollection,
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Populate the definition with your IMemoryCache instance.  
            // It needs to be cast as a dynamic, otherwise you can't
            // loop through it due to it being a collection of objects.
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;

            foreach (var cacheItem in cacheEntriesCollection)
            {
                string key = cacheItem.GetType().GetProperty(Const.Key).GetValue(cacheItem, null).ToString();
                if (key.StartsWith(Const.Prefix))
                    _memoryCache.Remove(key);
            }
            LogEvent("All", CacheOperation.DeleteAll);
        }

        private void LogEvent(string objectKey, CacheOperation operation, string reason = "")
        {
            if (_isLoggerEnable)
                _logger.LogInformation("Entity In-Memory Cache object:" + objectKey + ", Operation:" + operation.ToString().ToLower() + ", Reason:" + reason);
        }
    }
}
