using IncotradeBackend.Application.Booking.GetMyBookings;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Presentation.Booking.Request;
using IncotradeBackend.Presentation.Booking.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Booking
{
    public static class GetMyBookingsMapper
    {
        public static GetMyBookingsCommand ToCommand(
            GetMyBookingsRequest request,
            int customerId)
        {
            return new GetMyBookingsCommand
            {
                CustomerId = customerId,
                Page = int.Parse(request.Page),
                Size = int.Parse(request.Size),
                ServedDate = string.IsNullOrWhiteSpace(request.ServedDate)
                    ? null
                    : DateOnly.Parse(request.ServedDate),
                Status = string.IsNullOrWhiteSpace(request.Status)
                    ? null
                    : Enum.Parse<BookingStatus>(request.Status, true)
            };
        }

        public static GetMyBookingsResult ToResult(
            Database.Model.Booking booking)
        {
            return new GetMyBookingsResult
            {
                Id = booking.Id,
                BookingCode = booking.BookingCode,
                CustomerId = booking.CustomerId,
                ServiceId = booking.ServiceId,
                StaffId = booking.StaffId,
                ServedDate = booking.ServedDate,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                Status = booking.Status,
                CustomerNote = booking.CustomerNote,
                CancellationReason = booking.CancellationReason,
                CreatedAt = booking.CreatedAt,
                UpdatedAt = booking.UpdatedAt
            };
        }

        public static PageableResponse<GetMyBookingsResponse> ToResponse(
            PageableResult<GetMyBookingsResult> result)
        {
            return new PageableResponse<GetMyBookingsResponse>
            {
                Items = result.Items
                    .Select(booking => new GetMyBookingsResponse
                    {
                        Id = booking.Id,
                        BookingCode = booking.BookingCode,
                        CustomerId = booking.CustomerId,
                        ServiceId = booking.ServiceId,
                        StaffId = booking.StaffId,
                        ServedDate = booking.ServedDate,
                        StartTime = booking.StartTime,
                        EndTime = booking.EndTime,
                        Status = booking.Status.ToString(),
                        CustomerNote = booking.CustomerNote,
                        CancellationReason = booking.CancellationReason,
                        CreatedAt = booking.CreatedAt,
                        UpdatedAt = booking.UpdatedAt
                    })
                    .ToList(),
                Pagination = result.Pagination
            };
        }
    }
}
