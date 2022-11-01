using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlip.Core.Shared
{
    public class BaseModel<TKey> where TKey : struct
    {
        public virtual TKey Id { get; set; }
    }
}
