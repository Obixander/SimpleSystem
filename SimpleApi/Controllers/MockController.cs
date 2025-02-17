using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

    }
}
