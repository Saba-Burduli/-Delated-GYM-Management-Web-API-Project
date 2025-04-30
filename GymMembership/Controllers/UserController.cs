using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymMembership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceProviderIsService _serviceProvider;

        public UserController(IServiceProviderIsService serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
