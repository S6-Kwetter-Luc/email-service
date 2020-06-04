using System;
using System.Text.Json;
using System.Threading.Tasks;
using email_service.Messages;
using email_service.Services;
using MessageBroker;

namespace email_service.MessageHandlers
{
    public class RegisterEmailHandler : IMessageHandler<RegisterMessage>
    {
        private readonly IEmailService _emailService;

        public RegisterEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public Task HandleMessageAsync(string messageType, RegisterMessage sendable)
        {
            Task.Run(() => { _emailService.SendRegisterEmail(sendable.Email); });

            return Task.CompletedTask;
        }

        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType,
                JsonSerializer.Deserialize<RegisterMessage>((ReadOnlySpan<byte>) obj, (JsonSerializerOptions) null));
        }
    }
}