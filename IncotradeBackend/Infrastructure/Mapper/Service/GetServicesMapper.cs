using IncotradeBackend.Application.Service.GetServices;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Presentation.Service.Request;
using IncotradeBackend.Presentation.Service.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Service
{
    public static class GetServicesMapper
    {
        public static GetServicesCommand ToCommand(GetServicesRequest request)
        {
            return new GetServicesCommand
            {
                Page = int.Parse(request.Page),
                Size = int.Parse(request.Size),
                SearchName = request.SearchName
            };
        }

        public static GetServicesResult ToResult(
            Database.Model.Service service)
        {
            return new GetServicesResult
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                DurationMinutes = service.DurationMinutes,
                Price = service.Price,
                IsLocked = service.IsLocked,
                CreatedAt = service.CreatedAt,
                UpdatedAt = service.UpdatedAt
            };
        }

        public static PageableResponse<GetServicesResponse> ToResponse(
            PageableResult<GetServicesResult> result)
        {
            return new PageableResponse<GetServicesResponse>
            {
                Items = result.Items
                    .Select(service => new GetServicesResponse
                    {
                        Id = service.Id,
                        Name = service.Name,
                        Description = service.Description,
                        DurationMinutes = service.DurationMinutes,
                        Price = service.Price,
                        IsLocked = service.IsLocked,
                        CreatedAt = service.CreatedAt,
                        UpdatedAt = service.UpdatedAt
                    })
                    .ToList(),
                Pagination = result.Pagination
            };
        }
    }
}
