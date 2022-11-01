using PaySlip.Core.Shared;

namespace PaySlip.Domain.Model
{
    public class TaxRate : BaseModel<int>
    {
        public int Order { get; set; }
        public decimal Over { get; set; }
        public decimal UpTo { get; set; }
        public decimal Rate { get; set; }
    }
}
