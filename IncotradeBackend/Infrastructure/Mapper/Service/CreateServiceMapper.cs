using IncotradeBackend.Application.Service.CreateService;
using IncotradeBackend.Presentation.Service.Request;
using IncotradeBackend.Presentation.Service.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Service
{
    public static class CreateServiceMapper
    {
        public static CreateServiceCommand ToCommand(CreateServiceRequest request)
        {
            return new CreateServiceCommand
            {
                ServiceName = request.ServiceName.Trim(),
                Description = string.IsNullOrWhiteSpace(request.Description)
                    ? null
                    : request.Description.Trim(),
                DurationMinutes = int.Parse(request.DurationMinutes),
                Price = long.Parse(request.Price),
                IsLock = !string.IsNullOrWhiteSpace(request.IsLock)
                    && bool.Parse(request.IsLock)
            };
        }

        public static Database.Model.Service ToEntity(CreateServiceCommand command)
        {
            return new Database.Model.Service
            {
                Name = command.ServiceName,
                Description = command.Description,
                DurationMinutes = command.DurationMinutes,
                Price = command.Price,
                IsLocked = command.IsLock
            };
        }

        public static CreateServiceResult ToResult(
            Database.Model.Service service)
        {
            return new CreateServiceResult
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

        public static CreateServiceResponse ToResponse(CreateServiceResult result)
        {
            return new CreateServiceResponse
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
