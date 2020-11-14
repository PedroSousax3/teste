using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Business
{
    public class EnderecoBusiness : Business.Validador.ValidadorPadrao
    {
        Database.EnderecoDatabase business = new Database.EnderecoDatabase();
        public async Task<TbEndereco> InserirEnderecoDatabase(TbEndereco endereco)
        {
            ValidarId(endereco.IdCliente);
            ValidarTexto(endereco.DsComplemento, "endereço");
            ValidarTexto(endereco.NmCidade, "cidade");
            ValidarTexto(endereco.NmEstado, "estado");
            ValidarTexto(endereco.NmEndereco, "nome do endereço");
            ValidarTexto(endereco.DsEndereco, "endereço");
            ValidarTexto(endereco.DsCep, "cep");
            List<TbEndereco> lista = await ListarEnderecoClienteDatabase(endereco.IdCliente);

            foreach (TbEndereco item in lista)
            {
                if(endereco.NmEndereco == item.NmEndereco 
                && endereco.DsEndereco == item.DsEndereco 
                && endereco.NrEndereco == item.NrEndereco
                && endereco.DsCep == item.DsCep)
                {
                    throw new ArgumentException("Esse Endereço já foi cadastrado");
                }
            }

            return await business.InserirEnderecoDatabase(endereco);
        }

        public async Task<Models.TbEndereco> ConsultarEnderecoPorId(int idendereco)
        {
            ValidarId(idendereco);

            return await business.ConsultarEnderecoPorId(idendereco);
        }

        public async Task<List<Models.TbEndereco>> ListarEnderecoClienteDatabase(int cliente)
        {
            ValidarId(cliente);
            List<Models.TbEndereco> enderecos = await business.ListarEnderecoClienteDatabase(cliente);
            if(enderecos.Count == 0)
                throw new ArgumentException("Não há endereços cadastrados.");

            return enderecos;
        }

        public async Task<Models.TbEndereco> AlterarEndereco(int idendereco, Models.TbEndereco novo)
        {
            ValidarId(idendereco);
            ValidarId(novo.IdCliente);
            ValidarTexto(novo.DsComplemento, "endereço");
            ValidarTexto(novo.NmCidade, "cidade");
            ValidarTexto(novo.NmEstado, "estado");
            ValidarTexto(novo.NmEndereco, "nome do endereço");
            ValidarTexto(novo.DsEndereco, "endereço");
            ValidarTexto(novo.DsCep, "cep");
            
            return await business.AlterarEndereco(idendereco, novo);
        }
        
        public async Task<Models.TbEndereco> RemoverEnderecoPorId(int idendereco)
        {
            ValidarId(idendereco);

            return await business.RemoverEnderecoPorId(idendereco);
        }   

    }
}