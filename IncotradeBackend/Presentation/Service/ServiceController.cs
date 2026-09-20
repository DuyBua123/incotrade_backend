using IncotradeBackend.Application.Service.CreateService;
using IncotradeBackend.Application.Service.GetService;
using IncotradeBackend.Application.Service.GetServices;
using IncotradeBackend.Application.Service.SetServiceLocking;
using IncotradeBackend.Application.Service.UpdateService;
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
        private readonly CreateServiceUseCase _createServiceUseCase;
        private readonly GetServicesUseCase _getServicesUseCase;
        private readonly GetServiceUseCase _getServiceUseCase;
        private readonly SetServiceLockingUseCase _setServiceLockingUseCase;
        private readonly UpdateServiceUseCase _updateServiceUseCase;

        public ServiceController(
            CreateServiceUseCase createServiceUseCase,
            GetServicesUseCase getServicesUseCase,
            GetServiceUseCase getServiceUseCase,
            SetServiceLockingUseCase setServiceLockingUseCase,
            UpdateServiceUseCase updateServiceUseCase)
        {
            _createServiceUseCase = createServiceUseCase;
            _getServicesUseCase = getServicesUseCase;
            _getServiceUseCase = getServiceUseCase;
            _setServiceLockingUseCase = setServiceLockingUseCase;
            _updateServiceUseCase = updateServiceUseCase;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost("create-service")]
        public async Task<IActionResult> CreateService(
            [FromBody] CreateServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = CreateServiceMapper.ToCommand(request);
            var result = await _createServiceUseCase.ExecuteAsync(command);

            var response = CreateServiceMapper.ToResponse(result);

            return Ok(SuccessResponse<CreateServiceResponse>
                .Success("Tạo dịch vụ thành công.",
                response)
            );
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

        [Authorize(Roles = "ADMIN")]
        [HttpPut("update-service")]
        public async Task<IActionResult> UpdateService(
            [FromBody] UpdateServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = UpdateServiceMapper.ToCommand(request);
            var result = await _updateServiceUseCase.ExecuteAsync(command);

            var response = UpdateServiceMapper.ToResponse(result);

            return Ok(SuccessResponse<UpdateServiceResponse>
                .Success("Cập nhật dịch vụ thành công.",
                response)
            );
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPatch("set-service-locking")]
        public async Task<IActionResult> SetServiceLocking(
            [FromBody] SetServiceLockingRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = SetServiceLockingMapper.ToCommand(request);
            var result = await _setServiceLockingUseCase.ExecuteAsync(command);

            var response = SetServiceLockingMapper.ToResponse(result);

            return Ok(SuccessResponse<SetServiceLockingResponse>
                .Success("Cập nhật trạng thái khóa dịch vụ thành công.",
                response)
            );
        }
    }
}
