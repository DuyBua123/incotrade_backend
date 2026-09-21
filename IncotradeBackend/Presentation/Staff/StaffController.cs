using IncotradeBackend.Application.Staff.CreateStaff;
using IncotradeBackend.Application.Staff.GetStaff;
using IncotradeBackend.Application.Staff.GetStaffs;
using IncotradeBackend.Application.Staff.UpdateStaff;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Staff;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncotradeBackend.Presentation.Staff
{
    [ApiController]
    [Route("api/staffs")]
    public class StaffController : ControllerBase
    {
        private readonly CreateStaffUseCase _createStaffUseCase;
        private readonly GetStaffUseCase _getStaffUseCase;
        private readonly GetStaffsUseCase _getStaffsUseCase;
        private readonly UpdateStaffUseCase _updateStaffUseCase;

        public StaffController(
            CreateStaffUseCase createStaffUseCase,
            GetStaffUseCase getStaffUseCase,
            GetStaffsUseCase getStaffsUseCase,
            UpdateStaffUseCase updateStaffUseCase)
        {
            _createStaffUseCase = createStaffUseCase;
            _getStaffUseCase = getStaffUseCase;
            _getStaffsUseCase = getStaffsUseCase;
            _updateStaffUseCase = updateStaffUseCase;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost("create-staff")]
        public async Task<IActionResult> CreateStaff(
            [FromBody] CreateStaffRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = CreateStaffMapper.ToCommand(request);
            var result = await _createStaffUseCase.ExecuteAsync(command);

            var response = CreateStaffMapper.ToResponse(result);

            return Ok(SuccessResponse<CreateStaffResponse>
                .Success("Tạo nhân viên thành công.",
                response)
            );
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("get-staffs")]
        public async Task<IActionResult> GetStaffs(
            [FromQuery] GetStaffsRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = GetStaffsMapper.ToCommand(request);
            var result = await _getStaffsUseCase.ExecuteAsync(command);

            var response = GetStaffsMapper.ToResponse(result);

            return Ok(SuccessResponse<PageableResponse<GetStaffsResponse>>
                .Success("Lấy danh sách nhân viên thành công.",
                response)
            );
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("get-staff")]
        public async Task<IActionResult> GetStaff(
            [FromQuery] GetStaffRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = GetStaffMapper.ToCommand(request);
            var result = await _getStaffUseCase.ExecuteAsync(command);

            var response = GetStaffMapper.ToResponse(result);

            return Ok(SuccessResponse<GetStaffResponse>
                .Success("Lấy chi tiết nhân viên thành công.",
                response)
            );
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("update-staff")]
        public async Task<IActionResult> UpdateStaff(
            [FromBody] UpdateStaffRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = UpdateStaffMapper.ToCommand(request);
            var result = await _updateStaffUseCase.ExecuteAsync(command);

            var response = UpdateStaffMapper.ToResponse(result);

            return Ok(SuccessResponse<UpdateStaffResponse>
                .Success("Cập nhật nhân viên thành công.",
                response)
            );
        }
    }
}
