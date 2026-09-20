using IncotradeBackend.Application.Service.GetService;
using IncotradeBackend.Application.Service.GetServices;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Service;
using IncotradeBackend.Presentation.Service.Request;
using IncotradeBackend.Presentation.Service.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncotradeBackend.Presentation.Service
{
    [ApiController]
    [Route("api/services")]
    public class ServiceController : ControllerBase
    {
        private readonly GetServicesUseCase _getServicesUseCase;
        private readonly GetServiceUseCase _getServiceUseCase;

        public ServiceController(
            GetServicesUseCase getServicesUseCase,
            GetServiceUseCase getServiceUseCase)
        {
            _getServicesUseCase = getServicesUseCase;
            _getServiceUseCase = getServiceUseCase;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("get-services")]
        public async Task<IActionResult> GetServices(
            [FromQuery] GetServicesRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = GetServicesMapper.ToCommand(request);
            var result = await _getServicesUseCase.ExecuteAsync(command);

            var response = GetServicesMapper.ToResponse(result);

            return Ok(SuccessResponse<PageableResponse<GetServicesResponse>>
                .Success("Lấy danh sách các dịch vụ thành công.",
                response)
            );
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("get-service")]
        public async Task<IActionResult> GetService(
            [FromQuery] GetServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = GetServiceMapper.ToCommand(request);
            var result = await _getServiceUseCase.ExecuteAsync(command);

            var response = GetServiceMapper.ToResponse(result);

            return Ok(SuccessResponse<GetServiceResponse>
                .Success("Lấy chi tiết dịch vụ thành công.",
                response)
            );
        }
    }
}
