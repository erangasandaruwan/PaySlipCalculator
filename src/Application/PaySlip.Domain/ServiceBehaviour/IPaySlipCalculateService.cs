using PaySlip.Domain.Model;
using System.Threading.Tasks;

namespace PaySlip.Domain.ServiceBehaviour
{
    public interface IPaySlipCalculateService
    {
        Task<CalculatedPaySlip> CalculatePaySlip(PaySlipRequestInfo paySlipRequestInfo);
    }
}
