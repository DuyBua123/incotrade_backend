using IncotradeBackend.Application.Staff.GetStaff;
using IncotradeBackend.Application.Staff.GetStaffs;
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
        private readonly GetStaffUseCase _getStaffUseCase;
        private readonly GetStaffsUseCase _getStaffsUseCase;

        public StaffController(
            GetStaffUseCase getStaffUseCase,
            GetStaffsUseCase getStaffsUseCase)
        {
            _getStaffUseCase = getStaffUseCase;
            _getStaffsUseCase = getStaffsUseCase;
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
    }
}
