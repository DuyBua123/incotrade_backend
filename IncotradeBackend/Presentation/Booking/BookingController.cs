using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IncotradeBackend.Application.Booking.CreateBooking;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Booking;
using IncotradeBackend.Presentation.Booking.Request;
using IncotradeBackend.Presentation.Booking.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncotradeBackend.Presentation.Booking
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly CreateBookingUseCase _createBookingUseCase;

        public BookingController(CreateBookingUseCase createBookingUseCase)
        {
            _createBookingUseCase = createBookingUseCase;
        }

        [Authorize(Roles = "CUSTOMER")]
        [HttpPost("create-booking")]
        public async Task<IActionResult> CreateBooking(
            [FromBody] CreateBookingRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            int customerId = GetCurrentCustomerId();
            var command = CreateBookingMapper.ToCommand(request, customerId);
            var result = await _createBookingUseCase.ExecuteAsync(command);

            var response = CreateBookingMapper.ToResponse(result);

            return Ok(SuccessResponse<CreateBookingResponse>
                .Success("Tạo lịch hẹn thành công.",
                response)
            );
        }

        private int GetCurrentCustomerId()
        {
            string? customerIdValue = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
                ?? User.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? User.FindFirstValue("sub");

            if (!int.TryParse(customerIdValue, out int customerId))
            {
                throw new InvalidCredentialException("Không xác định được người dùng hiện tại.");
            }

            return customerId;
        }
    }
}
