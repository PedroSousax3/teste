namespace api.Utils.Conversor
{
    public class MedidasConversor
    {
        public Models.TbMedida Conversor(Models.Request.MedidaRequest request)
        {
            Models.TbMedida tabela = new Models.TbMedida();

            tabela.VlAltura = request.altura;
            tabela.VlLargura = request.largura;
            tabela.VlPeso = request.peso;
            tabela.VlProfundidades = request.profundidade;

            return tabela;
        }

        public Models.Response.MedidaResponse Conversor(Models.TbMedida tabela)
        {
            Models.Response.MedidaResponse response = new Models.Response.MedidaResponse();

            response.id = tabela.IdMedida;
            response.altura = tabela.VlAltura;
            response.largura = tabela.VlLargura;
            response.peso = tabela.VlPeso;
            response.profundidade = tabela.VlProfundidades;

            return response;
        }
    }
}