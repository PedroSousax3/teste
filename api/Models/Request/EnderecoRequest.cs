namespace api.Models.Request
{
    public class EnderecoRequest
    {
        public int cliente { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string celular { get; set; }
    }
}