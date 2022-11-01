using PaySlip.Core.Shared;

namespace PaySlip.Core.Cache
{
    public class ModelCacheKey<TModel, TKey> where TModel : BaseModel<TKey> where TKey : struct
    {
        public string Value { get; private set;}

        public static ModelCacheKey<TModel, TKey> GetKey(bool isSingle = false)
        {
            return new ModelCacheKey<TModel, TKey>()
            {
                Value = typeof(TModel).Name.ToUpper() + "_" + (isSingle ? Const.Object : Const.FullTable)
            };
        }
    }
}
