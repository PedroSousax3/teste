using System;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace api.Business
{
    public class EnviarEmailBusiness
    {
        public void EnvioEmail(string destinatario, string titulo, string corpo)
        {

            MailMessage mensagem = new MailMessage("nextgenbooks3@gmail.com", destinatario, titulo, corpo);
            mensagem.IsBodyHtml = true;
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("nextgenbooks3@gmail.com", "nextgenbooks1234!");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 20_000;
                smtpClient.Send(mensagem);
            }
        }
      
      public async Task<Models.TbLogin> EnviarCodigoRecuperarSenha(Models.Request.EmailRequest.EmailRecuperarSenha request)
        {
            Database.LoginDatabase database = new Database.LoginDatabase();
            string codigo = GerarCodigolAleatorio();

           Models.TbLogin login = await database.VerificarEmailRecuperarSenha(request,codigo);
           string titulo = "Resetar Senha";
           string corpo = $"<div><h3>Paresce que você esqueceu sua senha :(</h3></div>"+$"<div>não se preocupe, basta digitar esse código {codigo}</div>"+
           $"<div>na pagina para qual foi direcionado.</div>";
           
           this.EnvioEmail(request.Email,titulo,corpo);
           
           return login;
        
        }

        private string GerarCodigolAleatorio()
        {
            int Tamanho = 6;
            string codigoFinal = string.Empty;
            for (int i = 0; i < Tamanho; i++)
            {
                Random random = new Random();
                int codigo = random.Next(0, 10);

                    string _char = codigo.ToString();
                    if (!codigoFinal.Contains(_char))
                    {
                        codigoFinal += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
            return codigoFinal;
        }
    }
}
               
              
            