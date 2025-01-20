using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Commands.Address.Create;

namespace Restaurants.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController(ILogger<AddressController> logger, ISender sender) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAddresses()
        {
            return Ok("GetAddresses");
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateAddress(CreateAddressCommand command)
        {
            logger.LogInformation("CreateAddress endpoint accessed");

            int addressId = await sender.Send(command);

            return Ok(addressId);
        }
    }
}
