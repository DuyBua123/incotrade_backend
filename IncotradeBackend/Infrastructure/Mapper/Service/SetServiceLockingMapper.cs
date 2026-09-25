using IncotradeBackend.Application.Service.SetServiceLocking;
using IncotradeBackend.Presentation.Service.Request;
using IncotradeBackend.Presentation.Service.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Service
{
    public static class SetServiceLockingMapper
    {
        public static SetServiceLockingCommand ToCommand(SetServiceLockingRequest request)
        {
            return new SetServiceLockingCommand
            {
                ServiceId = int.Parse(request.ServiceId),
                IsLock = bool.Parse(request.IsLocked)
            };
        }

        public static SetServiceLockingResult ToResult(
            Database.Model.Service service)
        {
            return new SetServiceLockingResult
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

        public static SetServiceLockingResponse ToResponse(SetServiceLockingResult result)
        {
            return new SetServiceLockingResponse
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
