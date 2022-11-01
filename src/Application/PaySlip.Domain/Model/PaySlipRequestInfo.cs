using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlip.Domain.Model
{
    public class PaySlipRequestInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal SuperRate { get; set; }
        public string PayPeriod { get; set; }
    }
}
