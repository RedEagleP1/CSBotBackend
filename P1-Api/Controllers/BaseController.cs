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

        /// <summary>
        /// The base class to be inherited by all controllers, providing a logger and context.
        /// </summary>
        /// <param name="logger">The logger instance for recording events</param>
        /// <param name="context">The application DB context</param>
        /// <remarks>
        /// Use a typed logger in the derived class with the type argument being the derived type.
        /// For example: ILogger{DerivedController} not ILogger{BaseController}
        /// </remarks>
        /// <example>
        /// public class DerivedController : BaseController 
        /// {
        ///     public DerivedController(ILogger{DerivedController} logger, ApplicationContext context)
        ///         : base(logger, context) { }
        /// }
        /// </example>
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