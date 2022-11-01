namespace PaySlip.Domain.Model
{
    public class CalculatedPaySlip
    {
        public string Name { get; internal set; }
        public string PayPeriod { get; internal set; }
        public decimal GrossIncome { get; internal set; }
        public decimal IncomeTax { get; internal set; }
        public decimal NetIncome
        {
            get
            {
                return (GrossIncome - IncomeTax);
            }
        }
        public decimal Super { get; internal set; }
    }
}
