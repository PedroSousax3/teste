using System;
namespace api.Business.Validador
{
    public class ValidadorDevolucao:ValidadorPadrao
    {
        public void ValidarDevolucao(Models.TbDevolucao tabela)
        {
            if(tabela == null)
              throw new ArgumentException("Essa tabela esta vazia");

              ValidarTexto(tabela.DsComprovante," Comprovante");
              ValidarTexto(tabela.DsCodigoRastreio, "Codigo de Rastreio");
              ValidarTexto(tabela.DsMotivo,"Motivo");
              ValidarData(tabela.DtDevolucao,"Data de Devolucao");
              ValidarId(tabela.IdVendaLivro);
        }
    }
}