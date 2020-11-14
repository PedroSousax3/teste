namespace api.Business.Validador
{
    public class ValidadorAutor : Validador.ValidadorPadrao
    {
        public void ValidarAutor(Models.TbAutor tabela,string descricao,int id)
        {
            ValidarData(tabela.DtNascimento,"Data de Nascimento");
            ValidarTexto(tabela.NmAutor,"Nome do Autor");
            ValidarTexto(tabela.DsAutor,"Descrição do Autor");
            if(descricao == "alterar")
               ValidarAutorId(id);
        }

        public void ValidarAutorId(int id)
        {
            ValidarAutorId(id);
        }
    }
}