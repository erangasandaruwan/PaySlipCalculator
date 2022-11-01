using PaySlip.Application.Core.Util;
using PaySlip.Core;
using PaySlip.Core.Util;
using PaySlip.Domain.Infrastructure.Repository;
using PaySlip.Domain.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaySlip.Domain.ServiceBehaviour
{
    public class PaySlipCalculateService : IPaySlipCalculateService
    {
        private readonly ITaxRateRepository _taxRateRepository;

        public PaySlipCalculateService(ITaxRateRepository taxRateRepository)
        {
            _taxRateRepository = taxRateRepository;
        }

        public async Task<CalculatedPaySlip> CalculatePaySlip(PaySlipRequestInfo paySlipRequestInfo)
        {
            var taxRates = _taxRateRepository.FindAllAsNoTracking(null)
                            .OrderBy(x => x.Order)
                            .ToList();

            var calculatedPaySlip = new CalculatedPaySlip();

            // Name
            calculatedPaySlip.Name = paySlipRequestInfo.FirstName + " " + paySlipRequestInfo.LastName;

            // Pay Period
            calculatedPaySlip.PayPeriod = Month.GetMonthDuration(paySlipRequestInfo.PayPeriod);

            // Gross Income
            calculatedPaySlip.GrossIncome = Math.Round((paySlipRequestInfo.AnnualSalary / 12), 
                                                Config.Get<int>(Const.Settings_NoOfDecimals));

            decimal tax = 0;
            decimal runningGross = paySlipRequestInfo.AnnualSalary;
            for (int i = (taxRates.Count() - 1); i >= 0; i--)
            {
                if (runningGross > taxRates[i].Over)
                {
                    tax += (runningGross - taxRates[i].Over) * taxRates[i].Rate / 100;
                    runningGross = taxRates[i].Over;
                }
            }

            // Income Tax
            calculatedPaySlip.IncomeTax = Math.Round(tax / 12, Config.Get<int>(Const.Settings_NoOfDecimals));

            // Super
            calculatedPaySlip.Super = Math.Round((paySlipRequestInfo.AnnualSalary / 12) * (paySlipRequestInfo.SuperRate / 100),
                                            Config.Get<int>(Const.Settings_NoOfDecimals));

            return await Task.FromResult(calculatedPaySlip);
        }
    }
}
