using System.Threading.Tasks;

namespace Ouvidoria.Interfaces
{
    public interface IEmailService
    {
        Task<bool> EnviarEmail(string destinatario, string assunto, string mensagem);
    }
}
