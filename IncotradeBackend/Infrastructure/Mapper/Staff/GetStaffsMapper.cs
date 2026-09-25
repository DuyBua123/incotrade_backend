using IncotradeBackend.Application.Staff.GetStaffs;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Staff
{
    public static class GetStaffsMapper
    {
        public static GetStaffsCommand ToCommand(GetStaffsRequest request)
        {
            return new GetStaffsCommand
            {
                Page = int.Parse(request.Page),
                Size = int.Parse(request.Size),
                SearcFullhName = request.SearchFullName
            };
        }

        public static GetStaffsResult ToResult(
            Database.Model.Staff staff)
        {
            return new GetStaffsResult
            {
                Id = staff.Id,
                FullName = staff.FullName,
                Email = staff.Email,
                IsLocked = staff.IsLocked,
                CreatedAt = staff.CreatedAt,
                UpdatedAt = staff.UpdatedAt
            };
        }

        public static PageableResponse<GetStaffsResponse> ToResponse(
            PageableResult<GetStaffsResult> result)
        {
            return new PageableResponse<GetStaffsResponse>
            {
                Items = result.Items
                    .Select(staff => new GetStaffsResponse
                    {
                        Id = staff.Id,
                        FullName = staff.FullName,
                        Email = staff.Email,
                        IsLocked = staff.IsLocked,
                        CreatedAt = staff.CreatedAt,
                        UpdatedAt = staff.UpdatedAt
                    })
                    .ToList(),
                Pagination = result.Pagination
            };
        }
    }
}
