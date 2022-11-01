using MediatR;
using PaySlip.Domain.Model;

namespace PaySlip.Application.Command
{
    public class PaySlipCalculate: IRequest<CalculatedPaySlip>
    {
        public PaySlipRequestInfo PaySlipRequestInformation { get; set; }
    }
}
