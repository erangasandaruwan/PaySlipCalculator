using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySlip.Api.Dto;
using PaySlip.Api.Dto.Shared;
using PaySlip.Application.Command;
using PaySlip.Application.Core;
using PaySlip.Application.Core.Log;
using PaySlip.Domain.Model;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PaySlip.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaySlipController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IMediator _mediator;

        public PaySlipController(ILoggerManager logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("calculate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JsonResultVm<PaySlipResponseDto>))]
        public async Task<IActionResult> Post(PaySlipRequestDto request)
        {
            JsonResultVm<PaySlipResponseDto> vmResponse;

            try
            {
                var response = await _mediator.Send(new PaySlipCalculate
                {
                    PaySlipRequestInformation = _mapper.Map<PaySlipRequestInfo>(request)
                });

                vmResponse = new JsonResultVm<PaySlipResponseDto>()
                {
                    Data = _mapper.Map<PaySlipResponseDto>(response),
                    Message = "Pay slip calculated successfully.",
                    StatusCode = HttpStatusCode.OK,
                    Success = true,
                    TotalCount = 1
                };
            }
            catch (PaySlipException ex)
            {
                vmResponse = new JsonResultVm<PaySlipResponseDto>()
                {
                    Data = null,
                    Message = ex.Message,
                    StatusCode = HttpStatusCode.BadRequest,
                    Success = false,
                    TotalCount = 0
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + "/n" + ex.StackTrace);

                vmResponse = new JsonResultVm<PaySlipResponseDto>()
                {
                    Data = null,
                    Message = "Something went wrong. Please try again shortly or contact administrator.",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false,
                    TotalCount = 0
                };
            }

            return Ok(vmResponse);
        }
    }
}
