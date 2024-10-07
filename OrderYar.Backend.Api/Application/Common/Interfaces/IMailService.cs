namespace OrderYar.Backend.Api.Application.Common.Interfaces;

public interface IMailService
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
}
