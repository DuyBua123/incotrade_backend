using IncotradeBackend.Application.Staff.UpdateStaffSchedule;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Staff
{
    public static class UpdateStaffScheduleMapper
    {
        public static UpdateStaffScheduleCommand ToCommand(
            UpdateStaffScheduleRequest request)
        {
            return new UpdateStaffScheduleCommand
            {
                StaffScheduleId = int.Parse(request.StaffScheduleId),
                StaffId = int.Parse(request.StaffId),
                WorkDate = DateOnly.Parse(request.WorkDate),
                StartTime = TimeOnly.Parse(request.StartTime),
                EndTime = TimeOnly.Parse(request.EndTime)
            };
        }

        public static UpdateStaffScheduleResult ToResult(
            Database.Model.WorkSchedule schedule)
        {
            return new UpdateStaffScheduleResult
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

        public static UpdateStaffScheduleResponse ToResponse(
            UpdateStaffScheduleResult result)
        {
            return new UpdateStaffScheduleResponse
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
