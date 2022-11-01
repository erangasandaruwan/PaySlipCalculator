using System;

namespace PaySlip.Application.Core
{
    public class PaySlipException : Exception
    {
        public PaySlipException() { }

        public PaySlipException(string message) : base(message) { }

        public PaySlipException(string message, Exception inner) : base(message, inner) { }
    }
}
