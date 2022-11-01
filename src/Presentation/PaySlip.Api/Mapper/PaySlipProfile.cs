using AutoMapper;
using Microsoft.Extensions.Configuration;
using PaySlip.Api.Dto;
using PaySlip.Domain.Model;

namespace PaySlip.Api.Mapper
{
    public class PaySlipProfile : Profile
    {
        public PaySlipProfile()
        {
            CreateMap<PaySlipRequestDto, PaySlipRequestInfo>()
                .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, o => o.MapFrom(src => src.LastName))
                .ForMember(dest => dest.AnnualSalary, o => o.MapFrom(src => src.AnnualSalary))
                .ForMember(dest => dest.PayPeriod, o => o.MapFrom(src => src.PayPeriod))
                .ForMember(dest => dest.SuperRate, o => o.MapFrom(src => src.SuperRate));

            CreateMap<CalculatedPaySlip, PaySlipResponseDto>()
                .ForMember(dest => dest.Name, o => o.MapFrom(src => src.Name))
                .ForMember(dest => dest.PayPeriod, o => o.MapFrom(src => src.PayPeriod))
                .ForMember(dest => dest.NetIncome, o => o.MapFrom(src => src.NetIncome))
                .ForMember(dest => dest.GrossIncome, o => o.MapFrom(src => src.GrossIncome))
                .ForMember(dest => dest.Super, o => o.MapFrom(src => src.Super));

        }
    }
}
