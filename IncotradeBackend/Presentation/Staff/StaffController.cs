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
        private readonly GetStaffsUseCase _getStaffsUseCase;

        public StaffController(GetStaffsUseCase getStaffsUseCase)
        {
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
    }
}
