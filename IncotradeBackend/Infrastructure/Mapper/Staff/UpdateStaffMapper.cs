using IncotradeBackend.Application.Staff.UpdateStaff;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Staff
{
    public static class UpdateStaffMapper
    {
        public static UpdateStaffCommand ToCommand(UpdateStaffRequest request)
        {
            return new UpdateStaffCommand
            {
                StaffId = int.Parse(request.StaffId),
                FullName = request.FullName.Trim(),
                Email = request.Email.Trim(),
                IsLock = string.IsNullOrWhiteSpace(request.IsLock)
                    ? null
                    : bool.Parse(request.IsLock)
            };
        }

        public static UpdateStaffResult ToResult(
            Database.Model.Staff staff)
        {
            return new UpdateStaffResult
            {
                Id = staff.Id,
                FullName = staff.FullName,
                Email = staff.Email,
                IsLocked = staff.IsLocked,
                CreatedAt = staff.CreatedAt,
                UpdatedAt = staff.UpdatedAt
            };
        }

        public static UpdateStaffResponse ToResponse(UpdateStaffResult result)
        {
            return new UpdateStaffResponse
            {
                Id = result.Id,
                FullName = result.FullName,
                Email = result.Email,
                IsLocked = result.IsLocked,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            };
        }
    }
}
