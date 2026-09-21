using IncotradeBackend.Application.Staff.CreateStaff;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Staff
{
    public static class CreateStaffMapper
    {
        public static CreateStaffCommand ToCommand(CreateStaffRequest request)
        {
            return new CreateStaffCommand
            {
                FullName = request.FullName.Trim(),
                Email = request.Email.Trim(),
                IsLock = string.IsNullOrWhiteSpace(request.IsLock)
                    || bool.Parse(request.IsLock)
            };
        }

        public static Database.Model.Staff ToEntity(CreateStaffCommand command)
        {
            return new Database.Model.Staff
            {
                FullName = command.FullName,
                Email = command.Email,
                IsLocked = command.IsLock
            };
        }

        public static CreateStaffResult ToResult(
            Database.Model.Staff staff)
        {
            return new CreateStaffResult
            {
                Id = staff.Id,
                FullName = staff.FullName,
                Email = staff.Email,
                IsLocked = staff.IsLocked,
                CreatedAt = staff.CreatedAt,
                UpdatedAt = staff.UpdatedAt
            };
        }

        public static CreateStaffResponse ToResponse(CreateStaffResult result)
        {
            return new CreateStaffResponse
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
