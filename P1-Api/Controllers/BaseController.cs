using Microsoft.AspNetCore.Mvc;
using P1_Application.Boundaries;

namespace P1_Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;
        protected readonly ApplicationContext _context;

        public BaseController(ILogger<BaseController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected void setUserId(int Id)
        {
            _context.UserId = Id;
        }
    }
}