using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySlip.Api.Dto
{
    public class PaySlipRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal SuperRate { get; set; }
        public string PayPeriod { get; set; }
    }
}
