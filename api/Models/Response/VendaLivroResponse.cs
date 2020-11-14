namespace api.Models.Response
{
    public class VendaLivroResponse
    {
        public int id { get; set; }
        public int venda { get; set; }
        public int livro { get; set; }
        public int qtd { get; set; }
        public decimal valor { get; set; }
        public sbyte? devolvido {get;set;}
        public Models.Response.LivroResponse livroInfo { get; set; }
    }
}