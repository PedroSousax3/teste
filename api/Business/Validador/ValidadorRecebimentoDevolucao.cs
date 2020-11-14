using System;
namespace api.Business.Validador
{
    public class ValidadorRecebimentoDevolucao:Validador.ValidadorPadrao
    {
        public void ValidarRecebimentoDevolucao(Models.TbRecebimentoDevolucao tabela)
        {
            ValidarTexto(tabela.DsStatusLivro,"Status do Livro");
            ValidarData(tabela.DtRecebimentoLivro,"Data de Recebimento do Livro");
            if(tabela.DtRecebimentoLivro < DateTime.Now)
               throw new ArgumentException("A data nao pode ser menor que a data atual");
               ValidarId(tabela.IdDevolucao);
        }
    }
}