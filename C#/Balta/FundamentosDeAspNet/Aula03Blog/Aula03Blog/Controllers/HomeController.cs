using Microsoft.AspNetCore.Mvc;

namespace Aula03Blog.Controllers {

    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase {

        [HttpGet("")]
        public IActionResult Get() {
            return Ok();
        }
    }
}
