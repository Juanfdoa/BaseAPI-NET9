namespace BaseApi.Application.Interfaces.Providers
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
        Task SendTemplateAsync(string to,string subject,string templateName,Dictionary<string, object?> placeholders);
    }
}
