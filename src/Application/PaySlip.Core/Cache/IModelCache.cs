using PaySlip.Core.Shared;
using System.Collections.Generic;

namespace PaySlip.Core.Cache
{
    public interface IModelCache<TModel, TKey> where TModel : BaseModel<TKey> where TKey : struct
    {
        bool IsEnable { get; }
        bool IsLoggerEnable { get; }

        bool TryGetValue(ModelCacheKey<TModel, TKey> key, out TModel model);
        bool TryGetValue(ModelCacheKey<TModel, TKey> key, out IEnumerable<TModel> models);

        void Set(ModelCacheKey<TModel, TKey> key, TModel model);
        void Set(ModelCacheKey<TModel, TKey> key, IEnumerable<TModel> models);

        void Reset(ModelCacheKey<TModel, TKey> key, TModel model, string reason = "");
        void Reset(ModelCacheKey<TModel, TKey> key, IEnumerable<TModel> models, string reason = "");

        void Remove(ModelCacheKey<TModel, TKey> key);

        void Clear();
    }
}
