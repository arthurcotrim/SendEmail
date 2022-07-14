using Microsoft.AspNetCore.Mvc;
using SendEmail.Model;

namespace SendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmailController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> SendEmail(Email? email)
        {
            string response = await new Services.EmailService.Enviar().SendEmail(email);

            if (response.Contains("Erro")) return BadRequest(response);

            return Ok(response);
        }
    }
}