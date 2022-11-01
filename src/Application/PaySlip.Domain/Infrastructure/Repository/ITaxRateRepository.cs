using PaySlip.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PaySlip.Domain.Infrastructure.Repository
{
    public interface ITaxRateRepository
    {
        IEnumerable<TaxRate> Get();
        IEnumerable<TaxRate> FindAllAsNoTracking(Expression<Func<TaxRate, bool>> predicate = null);
    }
}
