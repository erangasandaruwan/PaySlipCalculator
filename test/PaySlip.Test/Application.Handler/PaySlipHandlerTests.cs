using Moq;
using PaySlip.Domain.Infrastructure.Repository;
using PaySlip.Domain.Model;
using PaySlip.Domain.ServiceBehaviour;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PaySlip.Test.Application.Handler
{
    public class PaySlipHandlerTests
    {
        private IPaySlipCalculateService _paySlipCalculateService;
        private Mock<ITaxRateRepository> _mockTaxRateRepository;

        private List<TaxRate> taxRates = new List<TaxRate>()
        {
            new TaxRate(){ Order = 1, Over = 0.0M, UpTo = 14000.0M, Rate = 10.5M },
            new TaxRate(){ Order = 2, Over = 14000.0M, UpTo = 48000.0M, Rate = 17.5M },
            new TaxRate(){ Order = 3, Over = 48000.0M, UpTo = 70000.0M, Rate = 30.0M },
            new TaxRate(){ Order = 4, Over = 70000.0M, UpTo = 180000.0M, Rate = 33.0M },
            new TaxRate(){ Order = 5, Over = 180000.0M, UpTo = 9999999999.9M, Rate = 39.0M }
        };

        public PaySlipHandlerTests()
        {
            DependencyRegistra.RegisterPaySlipServices();

            _mockTaxRateRepository = new Mock<ITaxRateRepository>();
            _mockTaxRateRepository
                .Setup(mr => mr.Get())
                .Returns(taxRates);
            _mockTaxRateRepository
                .Setup(mr => mr.FindAllAsNoTracking(null))
                .Returns(taxRates.AsEnumerable());

            _paySlipCalculateService = new PaySlipCalculateService(_mockTaxRateRepository.Object);
        }

        [Fact]
        public void PaySlipCalculate_Handle_1()
        {
            var request = new PaySlipRequestInfo()
            {
                FirstName = "John",
                LastName = "Smith",
                PayPeriod = "March",
                AnnualSalary = 60050.0M,
                SuperRate = 9.0M
            };

            string expectedName = "John Smith";
            string expectedPayPeriod = "01 March - 31 March";
            decimal expectedGrossPay = 5004.17M;
            decimal expectedIncomeTax = 919.58M;
            decimal expectedNetIncome = 4084.59M;
            decimal expectedSuper = 450.38M;

            var response = _paySlipCalculateService.CalculatePaySlip(request).Result;

            Assert.Equal(expectedName, response.Name);
            Assert.Equal(expectedPayPeriod, response.PayPeriod);
            Assert.Equal(expectedGrossPay, response.GrossIncome);
            Assert.Equal(expectedIncomeTax, response.IncomeTax);
            Assert.Equal(expectedNetIncome, response.NetIncome);
            Assert.Equal(expectedSuper, response.Super);
        }

        [Fact]
        public void PaySlipCalculate_Handle_2()
        {
            var request = new PaySlipRequestInfo()
            {
                FirstName = "Alex",
                LastName = "Wong",
                PayPeriod = "March",
                AnnualSalary = 120000.0M,
                SuperRate = 10.0M
            };

            string expectedName = "Alex Wong";
            string expectedPayPeriod = "01 March - 31 March";
            decimal expectedGrossPay = 10000.00M;
            decimal expectedIncomeTax = 2543.33M;
            decimal expectedNetIncome = 7456.67M;
            decimal expectedSuper = 1000.00M;

            var response = _paySlipCalculateService.CalculatePaySlip(request).Result;

            Assert.Equal(expectedName, response.Name);
            Assert.Equal(expectedPayPeriod, response.PayPeriod);
            Assert.Equal(expectedGrossPay, response.GrossIncome);
            Assert.Equal(expectedIncomeTax, response.IncomeTax);
            Assert.Equal(expectedNetIncome, response.NetIncome);
            Assert.Equal(expectedSuper, response.Super);
        }
    }
}
