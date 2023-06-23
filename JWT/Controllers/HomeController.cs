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
        public IActionResult Get()
        {
            return Ok(new
            {
                versao= "0001"
            });
        }
    }
}
