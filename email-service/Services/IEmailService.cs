using System.Threading.Tasks;

namespace email_service.Services
{
    public interface IEmailService
    {
        /// <summary>
        ///     Sends the register email to the given email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task SendRegisterEmail(string email);
    }
}