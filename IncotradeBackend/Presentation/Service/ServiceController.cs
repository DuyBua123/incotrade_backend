using IncotradeBackend.Application.Service.GetServices;
using IncotradeBackend.Infrastructure.Api;
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

        public ServiceController(GetServicesUseCase getServicesUseCase)
        {
            _getServicesUseCase = getServicesUseCase;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("get-services")]
        public async Task<IActionResult> GetServices(
            [FromQuery] GetServicesRequest request)
        {
            var command = GetServicesMapper.ToCommand(request);
            var result = await _getServicesUseCase.ExecuteAsync(command);

            var response = GetServicesMapper.ToResponse(result);

            return Ok(SuccessResponse<PageableResponse<GetServicesResponse>>
                .Success("Get services successfully.",
                response)
            );
        }
    }
}
