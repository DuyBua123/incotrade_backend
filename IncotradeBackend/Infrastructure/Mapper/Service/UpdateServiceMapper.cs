using IncotradeBackend.Application.Service.UpdateService;
using IncotradeBackend.Presentation.Service.Request;
using IncotradeBackend.Presentation.Service.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Service
{
    public static class UpdateServiceMapper
    {
        public static UpdateServiceCommand ToCommand(UpdateServiceRequest request)
        {
            return new UpdateServiceCommand
            {
                ServiceId = int.Parse(request.ServiceId),
                ServiceName = request.ServiceName.Trim(),
                Description = string.IsNullOrWhiteSpace(request.Description)
                    ? null
                    : request.Description.Trim(),
                DurationMinutes = int.Parse(request.DurationMinutes),
                Price = long.Parse(request.Price),
                IsLock = string.IsNullOrWhiteSpace(request.IsLock)
                    ? null
                    : bool.Parse(request.IsLock)
            };
        }

        public static UpdateServiceResult ToResult(
            Database.Model.Service service)
        {
            return new UpdateServiceResult
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

        public static UpdateServiceResponse ToResponse(UpdateServiceResult result)
        {
            return new UpdateServiceResponse
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
