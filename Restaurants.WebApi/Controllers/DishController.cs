using Microsoft.AspNetCore.Mvc;

namespace Restaurants.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {       
        private readonly ILogger<DishController> _logger;

        public DishController(ILogger<DishController> logger)
        {
            _logger = logger;
        }        
    }
}
