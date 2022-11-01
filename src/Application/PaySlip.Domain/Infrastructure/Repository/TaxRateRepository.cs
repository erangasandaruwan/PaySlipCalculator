using PaySlip.Core.Cache;
using PaySlip.Core.Data;
using PaySlip.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PaySlip.Domain.Infrastructure.Repository
{
    public class TaxRateRepository : Repository<TaxRate, int>, ITaxRateRepository
    {
        private readonly IModelCache<TaxRate, int> _cache;
        private readonly PaySlipDbContext _paySlipDbContext;

        public TaxRateRepository(PaySlipDbContext paySlipDbContext, IModelCache<TaxRate, int> cache) : base(paySlipDbContext, cache)
        {
            _cache = cache;
            _paySlipDbContext = paySlipDbContext;
        }

        public override IEnumerable<TaxRate> Get()
        {
            return GetQuery().ToList();
        }

        public IEnumerable<TaxRate> FindAllAsNoTracking(Expression<Func<TaxRate, bool>> predicate = null)
        {
            IEnumerable<TaxRate> list = GetEntityCache();

            if (predicate != null)
                list = list.Where(predicate.Compile());
            return list.AsEnumerable();
        }
    }
}
