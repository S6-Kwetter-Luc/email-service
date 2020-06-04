using email_service.Models;

namespace email_service.Helper
{
    public class EmailGenerator : IEmailGenerator
    {
        public Email CreateRegisterEmail()
        {
            var message = new Email
            {
                Subject = "Welcome to Kwetter!",
                Body = "<div><h1>Welcome to <span style='color:#593196'>Kwetter!</span></h1><p>Have fun on this platform!</p></div>"
            };
            return message;
        }
    }
}