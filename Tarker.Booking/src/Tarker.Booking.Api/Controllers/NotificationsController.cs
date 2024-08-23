using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.External.SendGridEmail;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Domain.Models.SendGridEmail;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class NotificationsController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SendGridEmailRequestModel model, [FromServices] ISendGridEmailService sendGridEmail)
        {
            var data = await sendGridEmail.Execute(model);

            if (!data)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }
    }
}
