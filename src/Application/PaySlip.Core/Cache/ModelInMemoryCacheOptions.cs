using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using PaySlip.Core.Shared;
using System;

namespace PaySlip.Core.Cache
{
    public abstract class ModelInMemoryCacheOptions<TModel, TKey> where TModel : BaseModel<TKey> where TKey : struct
    {
        private const int ABSOLUTE_EXPIRATION_IN_MINUTES = 10;

        private readonly IConfiguration _config;

        protected bool _isEnable = false;
        protected bool _isLoggerEnable = false;

        public ModelInMemoryCacheOptions(IConfiguration config)
        {
            _config = config;
            _isEnable = (!string.IsNullOrEmpty(_config["Cache:Enabled"]) && bool.TryParse(_config["Cache:Enabled"], out _isEnable)) ? _isEnable : false;
            _isLoggerEnable = (!string.IsNullOrEmpty(_config["Cache:LoggerEnabled"]) && bool.TryParse(_config["Cache:LoggerEnabled"], out _isLoggerEnable)) ? _isLoggerEnable : false;
        }

        protected MemoryCacheEntryOptions GetMemoryCacheEntryOptions(string cacheKey)
        {
            // Size and sliding expiration and  will not be specified
            return new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(
                    DateTime.Now.AddMinutes(string.IsNullOrEmpty(_config["Cache:AbsExpInMinutes"]) ?
                        ABSOLUTE_EXPIRATION_IN_MINUTES : int.Parse(_config["Cache:AbsExpInMinutes"])))
                .SetPriority(CacheItemPriority.Normal);
        }

    }
}
