using Microsoft.AspNetCore.Mvc;

namespace challenge_2_factory.API.Controllers;

[ApiController]
[Route("api")]
public class IndexController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Factory API is running");
    }
}