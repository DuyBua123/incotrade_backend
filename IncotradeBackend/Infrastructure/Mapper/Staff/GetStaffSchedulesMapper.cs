using IncotradeBackend.Application.Staff.GetStaffSchedules;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Staff
{
    public static class GetStaffSchedulesMapper
    {
        public static GetStaffSchedulesCommand ToCommand(
            GetStaffSchedulesRequest request)
        {
            return new GetStaffSchedulesCommand
            {
                StaffId = int.Parse(request.StaffId),
                Page = int.Parse(request.Page),
                Size = int.Parse(request.Size)
            };
        }

        public static GetStaffSchedulesResult ToResult(
            Database.Model.WorkSchedule schedule)
        {
            return new GetStaffSchedulesResult
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

        public static PageableResponse<GetStaffSchedulesResponse> ToResponse(
            PageableResult<GetStaffSchedulesResult> result)
        {
            return new PageableResponse<GetStaffSchedulesResponse>
            {
                Items = result.Items
                    .Select(schedule => new GetStaffSchedulesResponse
                    {
                        Id = schedule.Id,
                        StaffId = schedule.StaffId,
                        WorkDate = schedule.WorkDate,
                        StartTime = schedule.StartTime,
                        EndTime = schedule.EndTime,
                        CreatedAt = schedule.CreatedAt,
                        UpdatedAt = schedule.UpdatedAt
                    })
                    .ToList(),
                Pagination = result.Pagination
            };
        }
    }
}
