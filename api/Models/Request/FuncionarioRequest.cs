using System;

namespace api.Models.Request
{
    public class FuncionarioRequest
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string nomedeusuario { get; set; }
        public string senha { get; set; }
        public string carteiratrabalho { get; set; }
        public string cpf { get; set; }
        public DateTime nascimento { get; set; }
        public DateTime admissao { get; set; }
        public string cargo { get; set; }
        public string endereco { get; set; }
        public string cep { get; set; }
        public int numeroresidencial { get; set; }
        public string complemento { get; set; }
    }
}