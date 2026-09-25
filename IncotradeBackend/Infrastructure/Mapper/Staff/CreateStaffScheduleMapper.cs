using IncotradeBackend.Application.Staff.CreateStaffSchedule;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Staff
{
    public static class CreateStaffScheduleMapper
    {
        public static CreateStaffScheduleCommand ToCommand(
            CreateStaffScheduleRequest request)
        {
            return new CreateStaffScheduleCommand
            {
                StaffId = int.Parse(request.StaffId),
                WorkDate = DateOnly.Parse(request.WorkDate),
                StartTime = TimeOnly.Parse(request.StartTime),
                EndTime = TimeOnly.Parse(request.EndTime)
            };
        }

        public static Database.Model.WorkSchedule ToEntity(
            CreateStaffScheduleCommand command)
        {
            return new Database.Model.WorkSchedule
            {
                StaffId = command.StaffId,
                WorkDate = command.WorkDate,
                StartTime = command.StartTime,
                EndTime = command.EndTime
            };
        }

        public static CreateStaffScheduleResult ToResult(
            Database.Model.WorkSchedule schedule)
        {
            return new CreateStaffScheduleResult
            {
                Id = schedule.Id,
                StaffId = schedule.StaffId,
                WorkDate = schedule.WorkDate,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                CreatedAt = schedule.CreatedAt,
                UpdatedAt = schedule.UpdatedAt
            };
        }

        public static CreateStaffScheduleResponse ToResponse(
            CreateStaffScheduleResult result)
        {
            return new CreateStaffScheduleResponse
            {
                Id = result.Id,
                StaffId = result.StaffId,
                WorkDate = result.WorkDate,
                StartTime = result.StartTime,
                EndTime = result.EndTime,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            };
        }
    }
}
