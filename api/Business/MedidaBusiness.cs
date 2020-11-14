using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Business
{
    public class MedidaBusiness : Business.Validador.ValidadorPadrao
    {
        Database.MedidasDatabase database = new Database.MedidasDatabase();
        public async System.Threading.Tasks.Task<Models.TbMedida> CadastrarBusiness(Models.TbMedida novo)
        {
            if(novo.VlAltura <= 0)
                throw new ArgumentException("Medida da altura do livro não pode ser menor que 0.");
            if(novo.VlLargura <= 0)
                throw new ArgumentException("Medida da largura do livro não pode ser menor que 0.");
            if(novo.VlPeso <= 0)
                throw new ArgumentException("Medida do peso do livro não pode ser menor que 0.");
            if(novo.VlProfundidades <= 0)
                throw new ArgumentException("Medida da profundidade do livro não pode ser menor que 0.");
            

            Models.TbMedida medidas = await database.CadastrarMedidas(novo);
            if(medidas.IdMedida <= 0)
                throw new ArgumentException("Não foi possivel cadastrar essa medida.");
            return medidas;
        }

        public async Task<List<Models.TbMedida>> ListarMedidas()
        {
            List<Models.TbMedida> medidas = await database.ListarMedidas();

            if(medidas == null)
                throw new ArgumentException("Não foi possivel cadastrar essa medida.");
            return medidas;
        }

        public async Task<Models.TbMedida> ConsultarPorIdMedidaBusiness(int id)
        {
            ValidarId(id);
            Models.TbMedida medidas = await database.ConsultarPorIdMedidas(id);
            if(medidas.IdMedida <= 1)
                throw new ArgumentException("Não foi possivel alterar essa medida.");
            return medidas;
        }

        public async Task<Models.TbMedida> AlterarMedidasBusiness(int id,Models.TbMedida novo)
        {
            ValidarId(id);
            if(novo.VlAltura <= 0)
                throw new ArgumentException("Meida da altura do livro não pode ser menor que 0.");
            if(novo.VlLargura <= 0)
                throw new ArgumentException("Meida da largura do livro não pode ser menor que 0.");
            if(novo.VlPeso <= 0)
                throw new ArgumentException("Meida do peso do livro não pode ser menor que 0.");
            if(novo.VlProfundidades <= 0)
                throw new ArgumentException("Meida da profundidade do livro não pode ser menor que 0.");
            

            Models.TbMedida medidas = await database.AlterarMedidas(id, novo);
            if(medidas.IdMedida <= 1)
                throw new ArgumentException("Não foi possivel alterar essa medida.");
            return medidas;
        }
        
        public async Task<Models.TbMedida> DeletarMedidasBusiness(int id)
        {
            ValidarId(id);
            Models.TbMedida medidas = await database.DeletarMedidas(id);
            if(medidas.IdMedida <= 1)
                throw new ArgumentException("Não foi possivel alterar essa medida.");
            return medidas;
        }
    }
}