using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using inyeccion_dependencias_ejercicios.ConDY;

namespace inyeccion_dependencias_ejercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConDYController : ControllerBase
    {
        private IEmailServiceConDY _emailService;

        public ConDYController(IEmailServiceConDY emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public bool EnviarMail([FromQuery] string mail)
        {
            UsuarioServiceConDY usuarioServiceConDY = new ConDY.UsuarioServiceConDY(_emailService);
            return true;
            
        }
    }
}
