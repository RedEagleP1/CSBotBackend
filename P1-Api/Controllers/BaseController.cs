using Microsoft.AspNetCore.Mvc;

namespace P1_Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
    }
}