using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySlip.Api.Dto
{
    public class PaySlipResponseDto
    {
        public string Name { get; set; }
        public string PayPeriod { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal Super { get; set; }
    }
}
