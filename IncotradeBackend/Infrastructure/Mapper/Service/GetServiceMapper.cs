using IncotradeBackend.Application.Service.GetService;
using IncotradeBackend.Presentation.Service.Request;
using IncotradeBackend.Presentation.Service.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Service
{
    public static class GetServiceMapper
    {
        public static GetServiceCommand ToCommand(GetServiceRequest request)
        {
            return new GetServiceCommand
            {
                ServiceId = int.Parse(request.ServiceId)
            };
        }

        public static GetServiceResult ToResult(
            Database.Model.Service service)
        {
            return new GetServiceResult
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

        public static GetServiceResponse ToResponse(GetServiceResult result)
        {
            return new GetServiceResponse
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                DurationMinutes = result.DurationMinutes,
                Price = result.Price,
                IsLocked = result.IsLocked,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            };
        }
    }
}
