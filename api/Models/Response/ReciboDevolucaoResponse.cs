using System;

namespace api.Models.Response
{
    public class ReciboDevolucaoResponse
    {
        public int id { get; set; }
        public int devolucao { get; set; }
        public DateTime data_recebido { get; set; }
        public string descricao { get; set; }
    }
}