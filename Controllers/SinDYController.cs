using inyeccion_dependencias_ejercicios.SinDY;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inyeccion_dependencias_ejercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinDYController : ControllerBase
    {
        [HttpGet]
        public bool EnviarMail([FromQuery] string email)
        {
            UsuarioServiceSinDY usuarioServiceSinDY = new UsuarioServiceSinDY();
            return usuarioServiceSinDY.EnviarNotificacionUsuario(email);
        }
    }
}
