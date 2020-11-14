namespace api.Models.Request
{
    public class LoginRequest
    {
        public class CadastrarLoginFuncionario
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string NomeDeUsuario { get; set; }
            public string Senha { get; set; }
        }
        public class CadastrarLogin
        {
            public string Usuario { get; set; }
            public string Email { get; set; }
            public string ConfirmarEmail { get; set; }
            public string Senha { get; set; }
            public string ConfirmarSenha { get; set; }
        }
        public class ConfirmarLogin
        {
            public string Usuario { get; set; }
            public string Senha { get; set; }
        }
        public class RecuperarSenha
        {
            public string Codigo { get; set; }
        }
        public class ResetarSenha
        {
            public string Senha { get; set; }
        }
    }
}