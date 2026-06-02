using Aula03Blog.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Aula03Blog.Controllers {

    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase {

        [HttpGet("")]
        public IActionResult Get() {
            return Ok();
        }

        // criei esse método apenas para testar o atributo Apikey que eu criei
        [HttpGet("2")]
        [ApiKey]
        public IActionResult Get2() {
            return Ok();
        }
    }
}
