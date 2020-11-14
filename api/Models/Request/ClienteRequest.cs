using System;
using Microsoft.AspNetCore.Http;
namespace api.Models.Request
{
    public class ClienteRequest
    {
        public class CadastroCliente 
        {
            public string usuario { get; set; }
            public string email { get; set; }
            public string senha { get; set; }
            public string cpf { get; set; }
            public string nome { get; set; }
            public string celular { get; set; }
            public IFormFile foto { get; set; }
            public string genero { get; set; }
            public DateTime Nascimento { get; set; }
        }


        public class Cliente
        {
            public string email { get; set; }
            public string nome { get; set; }
            public string celular { get; set; }
            public IFormFile foto { get; set; }
            public string genero { get; set; }
            public DateTime nascimento { get; set; }
        }
    }
}