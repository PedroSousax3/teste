using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Business
{
    public class FuncionarioBusiness : Business.Validador.ValidadorPadrao
    {
        Validador.ValidadorFuncionario validador = new Validador.ValidadorFuncionario();
        Database.FuncionarioDatabase database = new Database.FuncionarioDatabase();

        public async Task<Models.TbFuncionario> CadastrarBusiness(Models.TbFuncionario novo)
        {
            validador.ValidarFuncionario(novo);
            
            Models.TbFuncionario funcionario = await database.CadastrarFuncionario(novo);

            if(funcionario == null)
                throw new ArgumentException("Não foi possivel cadastrar o funcionario.");

            return funcionario;
        }

        public async Task<List<Models.TbFuncionario>> ListaBusiness()
        {
            List<Models.TbFuncionario> funcionario = await database.ListarFuncionarios();

            if(funcionario == null)
                new ArgumentException("Não foi possivel cadastrar o funcionario");
            
            return funcionario;
        }
        public async Task<Models.TbFuncionario> ConsultarPorIdBusiness(int id)
        {
            ValidarId(id);
            Models.TbFuncionario funcionario = await database.ConsultarPorId(id);
            if(funcionario == null)
                throw new ArgumentException("Funcionario Não foi encontrado");
            return funcionario;
        }

        public async Task<Models.TbFuncionario> AlterarBusiness(int id,Models.TbFuncionario novo)
        {
            ValidarTexto(novo.NmFuncionario, "Nome do funcionario");
            ValidarTexto(novo.DsCarteiraTrabalho, "carteira de trabalho");
            ValidarTexto(novo.DsCep, "cep");
            ValidarTexto(novo.DsEmail, "e-mail");
            ValidarTexto(novo.DsEndereco, "endereço residencial");
            ValidarId(novo.IdLogin);
            ValidarTexto(novo.DsCpf, "cpf");

            Models.TbFuncionario funcionario = await database.AlterarFuncionario(id,novo);
            if(funcionario == null)
                throw new ArgumentException("Não fio possivel encontrar o funcionario.");
            return funcionario;

        }

        public async Task<Models.TbFuncionario> DeletarBusiness(int id)
        {
            ValidarId(id);
            Models.TbFuncionario funcionario = await database.DeletarFuncionario(id);
            if(funcionario == null)
                throw new ArgumentException("Não fio possivel encontrar o funcionario.");
            return funcionario;
        }        
    }
}