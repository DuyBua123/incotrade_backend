using IncotradeBackend.Application.Staff.GetStaffSchedule;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Staff
{
    public static class GetStaffScheduleMapper
    {
        public static GetStaffScheduleCommand ToCommand(
            GetStaffScheduleRequest request)
        {
            return new GetStaffScheduleCommand
            {
                StaffScheduleId = int.Parse(request.StaffScheduleId)
            };
        }

        public static GetStaffScheduleResult ToResult(
            Database.Model.WorkSchedule schedule)
        {
            return new GetStaffScheduleResult
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

        public static GetStaffScheduleResponse ToResponse(
            GetStaffScheduleResult result)
        {
            return new GetStaffScheduleResponse
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
