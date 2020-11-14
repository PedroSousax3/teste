using System;

namespace api.Models.Response
{
    public class VendaStatusResponse
    {
        public int id { get; set; }
        public int venda { get; set; }
        public string status { get; set; }
        public string DsVendaStatus { get; set; }
        public DateTime DtAtualizacao { get; set; }
    }
}