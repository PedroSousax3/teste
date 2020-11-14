using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class AcessoDatabase
    {
        Models.db_next_gen_booksContext db = new Models.db_next_gen_booksContext();
        public async Task<Models.TbLogin> ConsultarUsuario(string user, string senha)
        {
            Models.TbLogin login = await db.TbLogin.Include(x => x.TbCliente)
                                                    .Include(x => x.TbFuncionario)
                                                    .FirstOrDefaultAsync(x => x.NmUsuario == user);
            login.DtUltimoLogin = DateTime.Now;
            
            if(login == null)
                throw new ArgumentException("Nome de usuario não cadastrado.");
            
            if(senha != login.DsSenha)
                throw new ArgumentException("Senha informada está incorreta.");
            

            await db.SaveChangesAsync();

            return login;
        }

        public async Task<Models.TbLogin> ConsultarPerfil(string user, string perfil)
        {
            Models.TbLogin login = new Models.TbLogin();

            if(perfil == "cliente")
            {
                login = await db.TbLogin.Include(x => x.TbCliente)
                                        .FirstOrDefaultAsync(x => x.NmUsuario == user);    
            }
            else if (perfil == "funcionario")
            {
                login = await db.TbLogin.Include(x => x.TbFuncionario)
                                        .FirstOrDefaultAsync(x => x.NmUsuario == user);
            }

            return login;
        }
    }
}