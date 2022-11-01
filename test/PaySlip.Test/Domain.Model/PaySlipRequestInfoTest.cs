using PaySlip.Application.Validator;
using PaySlip.Domain.Model;
using Xunit;

namespace PaySlip.Test.Domain.Model
{
    public class PaySlipRequestInfoTest
    {
        private PaySlipRequestInfoValidator _validator;

        public PaySlipRequestInfoTest()
        {
            DependencyRegistra.RegisterPaySlipServices();
        }

        [Fact]
        public void PaySlipRequestInfo_Should_Have_FirstName()
        {
            var model = new PaySlipRequestInfo()
            {
                FirstName = string.Empty,
                LastName = "LastName",
                AnnualSalary = 50000,
                PayPeriod = "March",
                SuperRate = 5.6M
            };

            _validator = new PaySlipRequestInfoValidator();

            var result = _validator.Validate(model);
            Assert.Contains(result.Errors, o => o.PropertyName == "FirstName");
        }

        [Fact]
        public void PaySlipRequestInfo_Should_Have_LastName()
        {
            var model = new PaySlipRequestInfo()
            {
                FirstName = "FirstName",
                LastName = string.Empty,
                AnnualSalary = 50000,
                PayPeriod = "March",
                SuperRate = 5.6M
            };

            _validator = new PaySlipRequestInfoValidator();

            var result = _validator.Validate(model);
            Assert.Contains(result.Errors, o => o.PropertyName == "LastName");
        }

        [Fact]
        public void PaySlipRequestInfo_AnnuaSalary_Greater_Than_Zero()
        {
            var model = new PaySlipRequestInfo()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                AnnualSalary = -5,
                PayPeriod = "March",
                SuperRate = 5.6M
            };

            _validator = new PaySlipRequestInfoValidator();

            var result = _validator.Validate(model);
            Assert.Contains(result.Errors, o => o.PropertyName == "AnnualSalary");
        }

        [Fact]
        public void PaySlipRequestInfo_SuperRate_Greater_Than_Or_Equal_Zero()
        {
            var model = new PaySlipRequestInfo()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                AnnualSalary = 50000,
                PayPeriod = "April",
                SuperRate = -0.001M
            };

            _validator = new PaySlipRequestInfoValidator();

            var result = _validator.Validate(model);
            Assert.Contains(result.Errors, o => o.PropertyName == "SuperRate");
        }

        [Fact]
        public void PaySlipRequestInfo_SuperRate_Less_Than_Or_Equal_Fifty()
        {
            var model = new PaySlipRequestInfo()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                AnnualSalary = 50000,
                PayPeriod = "April",
                SuperRate = 50.001M
            };

            _validator = new PaySlipRequestInfoValidator();

            var result = _validator.Validate(model);
            Assert.Contains(result.Errors, o => o.PropertyName == "SuperRate");
        }

        [Fact]
        public void PaySlipRequestInfo_Should_Have_PayPeriod()
        {
            var model = new PaySlipRequestInfo()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                AnnualSalary = 50000,
                PayPeriod = string.Empty,
                SuperRate = 5.6M
            };

            _validator = new PaySlipRequestInfoValidator();

            var result = _validator.Validate(model);
            Assert.Contains(result.Errors, o => o.PropertyName == "PayPeriod");
        }

        [Fact]
        public void PaySlipRequestInfo_Should_Have_Valid_PayPeriod()
        {
            var model = new PaySlipRequestInfo()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                AnnualSalary = 50000,
                PayPeriod = "PayPeriod",
                SuperRate = 5.6M
            };

            _validator = new PaySlipRequestInfoValidator();

            var result = _validator.Validate(model);
            Assert.Contains(result.Errors, o => o.PropertyName == "PayPeriod");
        }
    }
}
