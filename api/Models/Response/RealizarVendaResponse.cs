using System.Collections.Generic;
using System.Collections;
namespace api.Models.Response
{
    public class RealizarVendaResponse
    {
        public int IdVenda { get; set; }
        public Models.Response.VendaResponse Venda { get; set; }
        public List<Models.Response.VendaLivroResponse> VendaLivro { get; set; }
        public Models.Response.VendaStatusResponse Status { get; set; }

    }
}