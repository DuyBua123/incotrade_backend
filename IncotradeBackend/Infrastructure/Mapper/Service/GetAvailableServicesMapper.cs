using IncotradeBackend.Application.Service.GetAvailableServices;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Presentation.Service.Request;
using IncotradeBackend.Presentation.Service.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Service
{
    public static class GetAvailableServicesMapper
    {
        public static GetAvailableServicesCommand ToCommand(
            GetAvailableServicesRequest request)
        {
            return new GetAvailableServicesCommand
            {
                Page = int.Parse(request.Page),
                Size = int.Parse(request.Size),
                SearchName = request.SearchName
            };
        }

        public static GetAvailableServicesResult ToResult(
            Database.Model.Service service)
        {
            return new GetAvailableServicesResult
            {
                Id = service.Id,
                ServiceName = service.Name,
                Description = service.Description,
                DurationMinutes = service.DurationMinutes,
                Price = service.Price,
                IsLocked = service.IsLocked,
                CreatedAt = service.CreatedAt,
                UpdatedAt = service.UpdatedAt
            };
        }

        public static PageableResponse<GetAvailableServicesResponse> ToResponse(
            PageableResult<GetAvailableServicesResult> result)
        {
            return new PageableResponse<GetAvailableServicesResponse>
            {
                Items = result.Items
                    .Select(service => new GetAvailableServicesResponse
                    {
                        Id = service.Id,
                        ServiceName = service.ServiceName,
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
