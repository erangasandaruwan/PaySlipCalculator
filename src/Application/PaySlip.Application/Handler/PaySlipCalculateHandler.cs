using MediatR;
using PaySlip.Application.Command;
using PaySlip.Domain.Model;
using PaySlip.Domain.ServiceBehaviour;
using System.Threading;
using System.Threading.Tasks;

namespace PaySlip.Application.Handler
{
    public class PaySlipCalculateHandler : IRequestHandler<PaySlipCalculate, CalculatedPaySlip>
    {
        private readonly IPaySlipCalculateService _paySlipCalculateService;

        public PaySlipCalculateHandler(IPaySlipCalculateService paySlipCalculateService) : base()
        {
            _paySlipCalculateService = paySlipCalculateService;
        }

        public async Task<CalculatedPaySlip> Handle(PaySlipCalculate request, CancellationToken cancellationToken)
        {
            var response = await _paySlipCalculateService.CalculatePaySlip(request.PaySlipRequestInformation);

            return await Task.FromResult(response);
        }
    }
}
