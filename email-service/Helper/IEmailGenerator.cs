using email_service.Models;

namespace email_service.Helper
{
    public interface IEmailGenerator
    {
        /// <summary>
        /// Creates an email object for the register action
        /// </summary>
        /// <returns></returns>
        Email CreateRegisterEmail();
    }
}