namespace api.Models.Request
{
    public class EmailRequest
    {
        public class EnvioEmailRequest
        {
            public string destinatario { get; set; }
            public string titulo { get; set; }
            public string msn { get; set; }
        }

        public class EmailRecuperarSenha
        {
            public string Email { get; set; }
        }
    }
}