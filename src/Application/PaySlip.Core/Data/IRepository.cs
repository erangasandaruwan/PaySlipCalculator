using PaySlip.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PaySlip.Core.Data
{
    public interface IRepository<TModel, TKey> where TModel : BaseModel<TKey> where TKey : struct
    {
        TModel Get(TKey key);
        IEnumerable<TModel> Get();
        Task Add(TModel model);
        Task AddRange(List<TModel> models);
        void Update(TModel model);
        void UpdateRange(List<TModel> models);
        void Remove(TModel model);
        IEnumerable<TModel> Find(Expression<Func<TModel, bool>> expression);
        void Save();
    }
}
