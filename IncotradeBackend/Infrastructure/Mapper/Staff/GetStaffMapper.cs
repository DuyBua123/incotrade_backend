using IncotradeBackend.Application.Staff.GetStaff;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Staff
{
    public static class GetStaffMapper
    {
        public static GetStaffCommand ToCommand(GetStaffRequest request)
        {
            return new GetStaffCommand
            {
                StaffId = int.Parse(request.StaffId)
            };
        }

        public static GetStaffResult ToResult(
            Database.Model.Staff staff)
        {
            return new GetStaffResult
            {
                Id = staff.Id,
                FullName = staff.FullName,
                Email = staff.Email,
                IsLocked = staff.IsLocked,
                CreatedAt = staff.CreatedAt,
                UpdatedAt = staff.UpdatedAt
            };
        }

        public static GetStaffResponse ToResponse(GetStaffResult result)
        {
            return new GetStaffResponse
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
