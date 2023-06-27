using Blog.Atribute;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        //[ApiKey] Criado um Atributo
        public IActionResult Get([FromServices] IConfiguration config)
        {
            return Ok(new
            {
                versao= "0001",
                ambiente = config.GetValue<string>("Env")
            });
        }
    }
}
