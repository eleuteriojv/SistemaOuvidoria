using System.Threading.Tasks;

namespace Ouvidoria.Interfaces
{
    public interface IConfigEmail
    {
        Task<bool> EnviarEmail(string destinatario, string assunto, string mensagem);
    }
}
