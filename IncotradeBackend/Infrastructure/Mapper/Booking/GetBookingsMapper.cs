using IncotradeBackend.Application.Booking.GetBookings;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Presentation.Booking.Request;
using IncotradeBackend.Presentation.Booking.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Booking
{
    public static class GetBookingsMapper
    {
        public static GetBookingsCommand ToCommand(GetBookingsRequest request)
        {
            return new GetBookingsCommand
            {
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

        public static GetBookingsResult ToResult(
            Database.Model.Booking booking)
        {
            return new GetBookingsResult
            {
                Id = booking.Id,
                BookingCode = booking.BookingCode,
                CustomerId = booking.CustomerId,
                CustomerFullName = booking.Customer.FullName,
                ServiceName = booking.Service.Name,
                StaffFullName = booking.Staff.FullName,
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

        public static PageableResponse<GetBookingsResponse> ToResponse(
            PageableResult<GetBookingsResult> result)
        {
            return new PageableResponse<GetBookingsResponse>
            {
                Items = result.Items
                    .Select(booking => new GetBookingsResponse
                    {
                        Id = booking.Id,
                        BookingCode = booking.BookingCode,
                        CustomerId = booking.CustomerId,
                        CustomerFullName = booking.CustomerFullName,
                        ServiceName = booking.ServiceName,
                        StaffFullName = booking.StaffFullName,
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
