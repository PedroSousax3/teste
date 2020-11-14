namespace api.Models.Request
{
    public class VendaLivroRequest
    {
        public int venda { get; set; }
        public int livro { get; set; }
        public int qtd { get; set; }
        public decimal valor { get; set; }
    }
}