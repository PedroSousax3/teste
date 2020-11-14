using System;

namespace api.Models.Request
{
    public class ReciboDevolucaoRequest
    {
        public int devolucao { get; set; }
        public DateTime data_recebido { get; set; }
        public string descricao { get; set; }
    }
}