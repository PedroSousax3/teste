namespace api.Models.Response
{
    public class LoginResponse
    {
        public class CadastrarLoginFuncionario
        {
            public int Id { get; set; }
            public string Usuario { get; set; }
            public string  Email { get; set; }
            public string  Nome { get; set; }

        }
        
        public class ConfirmarLogin
        {
            public int IdLogin { get; set; }
            public string NomeUsuario { get; set; }
            public string DescricaoPerfil { get; set; }
            public int? Id { get; set; }
            public string Nome { get; set; }
            public string NomeFoto { get; set; }
            public string Email { get; set; }
        }
    }
}