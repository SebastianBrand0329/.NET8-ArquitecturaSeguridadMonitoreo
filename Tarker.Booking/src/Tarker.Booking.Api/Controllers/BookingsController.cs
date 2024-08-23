using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByType;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingsController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBookingModel model, [FromServices] ICreateBookingCommand createBooking, [FromServices] IValidator<CreateBookingModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if(!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createBooking.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookingsQuery getAllBookings)
        {
            var data = await getAllBookings.Execute();

            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-documentNumber")]
        public async Task<IActionResult> GetByDocumentNumber([FromQuery] string documentNumber, [FromServices] IGetBookingsByDocumentNumberQuery getBookings)
        {
            if(string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getBookings.Execute(documentNumber);

            if(data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-type")]
        public async Task<IActionResult> GetByType([FromQuery] string type, [FromServices] IGetBookingByTypeQuery getBookingByType)
        {
            if(string.IsNullOrEmpty(type))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getBookingByType.Execute(type);

            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }
    }
}
