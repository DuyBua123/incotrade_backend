using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IncotradeBackend.Application.Booking.CompleteBooking;
using IncotradeBackend.Application.Booking.ConfirmBooking;
using IncotradeBackend.Application.Booking.CreateBooking;
using IncotradeBackend.Application.Booking.GetBookings;
using IncotradeBackend.Application.Booking.GetMyBookings;
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
        private readonly CompleteBookingUseCase _completeBookingUseCase;
        private readonly ConfirmBookingUseCase _confirmBookingUseCase;
        private readonly CreateBookingUseCase _createBookingUseCase;
        private readonly GetBookingsUseCase _getBookingsUseCase;
        private readonly GetMyBookingsUseCase _getMyBookingsUseCase;

        public BookingController(
            CompleteBookingUseCase completeBookingUseCase,
            ConfirmBookingUseCase confirmBookingUseCase,
            CreateBookingUseCase createBookingUseCase,
            GetBookingsUseCase getBookingsUseCase,
            GetMyBookingsUseCase getMyBookingsUseCase)
        {
            _completeBookingUseCase = completeBookingUseCase;
            _confirmBookingUseCase = confirmBookingUseCase;
            _createBookingUseCase = createBookingUseCase;
            _getBookingsUseCase = getBookingsUseCase;
            _getMyBookingsUseCase = getMyBookingsUseCase;
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

        [Authorize(Roles = "ADMIN")]
        [HttpPatch("confirm-booking")]
        public async Task<IActionResult> ConfirmBooking(
            [FromBody] ConfirmBookingRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = ConfirmBookingMapper.ToCommand(request);
            var result = await _confirmBookingUseCase.ExecuteAsync(command);

            var response = ConfirmBookingMapper.ToResponse(result);

            return Ok(SuccessResponse<ConfirmBookingResponse>
                .Success("Xác nhận lịch hẹn thành công.",
                response)
            );
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPatch("complete-booking")]
        public async Task<IActionResult> CompleteBooking(
            [FromBody] CompleteBookingRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = CompleteBookingMapper.ToCommand(request);
            var result = await _completeBookingUseCase.ExecuteAsync(command);

            var response = CompleteBookingMapper.ToResponse(result);

            return Ok(SuccessResponse<CompleteBookingResponse>
                .Success("Hoàn thành lịch hẹn thành công.",
                response)
            );
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("get-bookings")]
        public async Task<IActionResult> GetBookings(
            [FromQuery] GetBookingsRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = GetBookingsMapper.ToCommand(request);
            var result = await _getBookingsUseCase.ExecuteAsync(command);

            var response = GetBookingsMapper.ToResponse(result);

            return Ok(SuccessResponse<PageableResponse<GetBookingsResponse>>
                .Success("Lấy danh sách lịch hẹn thành công.",
                response)
            );
        }

        [Authorize(Roles = "CUSTOMER")]
        [HttpGet("get-my-bookings")]
        public async Task<IActionResult> GetMyBookings(
            [FromQuery] GetMyBookingsRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            int customerId = GetCurrentCustomerId();
            var command = GetMyBookingsMapper.ToCommand(request, customerId);
            var result = await _getMyBookingsUseCase.ExecuteAsync(command);

            var response = GetMyBookingsMapper.ToResponse(result);

            return Ok(SuccessResponse<PageableResponse<GetMyBookingsResponse>>
                .Success("Lấy danh sách lịch hẹn của tôi thành công.",
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
