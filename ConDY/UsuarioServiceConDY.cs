namespace inyeccion_dependencias_ejercicios.ConDY
{
    public class UsuarioServiceConDY
    {
        private IEmailServiceConDY _emailService;

        public UsuarioServiceConDY(IEmailServiceConDY emailService)
        {
            _emailService = emailService;
        }

        public bool EnviarNotificacionUsuario(string email)
        {
            _emailService.Enviar(email, "Notificacion");
            return true;
        }
    }
}
