using System.Linq.Expressions;
using IncotradeBackend.Application.Staff.GetAvailableStaffs;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Staff
{
    public static class GetAvailableStaffsMapper
    {
        public static GetAvailableStaffsCommand ToCommand(
            GetAvailableStaffsRequest request)
        {
            return new GetAvailableStaffsCommand
            {
                Page = int.Parse(request.Page),
                Size = int.Parse(request.Size),
                SearchFullName = request.SearchFullName
            };
        }

        public static Expression<Func<Database.Model.Staff, GetAvailableStaffsResult>>
            ToResultExpression()
        {
            return staff => new GetAvailableStaffsResult
                {
                    Id = staff.Id,
                    FullName = staff.FullName,
                    Email = staff.Email,
                    IsLocked = staff.IsLocked,
                    WorkSchedules = staff.WorkSchedules
                        .OrderBy(schedule => schedule.WorkDate)
                        .ThenBy(schedule => schedule.StartTime)
                        .Select(schedule => new GetAvailableStaffsWorkScheduleResult
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
                    CreatedAt = staff.CreatedAt,
                    UpdatedAt = staff.UpdatedAt
                };
        }

        public static PageableResponse<GetAvailableStaffsResponse> ToResponse(
            PageableResult<GetAvailableStaffsResult> result)
        {
            return new PageableResponse<GetAvailableStaffsResponse>
            {
                Items = result.Items
                    .Select(staff => new GetAvailableStaffsResponse
                    {
                        Id = staff.Id,
                        FullName = staff.FullName,
                        Email = staff.Email,
                        IsLocked = staff.IsLocked,
                        WorkSchedules = staff.WorkSchedules
                            .Select(schedule => new GetAvailableStaffsWorkScheduleResponse
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
                        CreatedAt = staff.CreatedAt,
                        UpdatedAt = staff.UpdatedAt
                    })
                    .ToList(),
                Pagination = result.Pagination
            };
        }
    }
}
