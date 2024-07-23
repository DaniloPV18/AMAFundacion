using FundacionAMA.Domain.DTO.EmailServiceProfile;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace FundacionAMA.Infrastructure.Email;

public class SMTPService : ISMTPService
{
    public async Task<(bool IsSuccessful, string Message)> SendEmailAsync(EmailRequest email, SmtpConfiguration configuration)
    {

        using var smtp = CreateSMTP(configuration);
        try
        {
            var _mimeMessage = new MimeMessage();
            _mimeMessage.Sender = MailboxAddress.Parse(configuration.Mail);

            foreach (var _mail in email.To)
            {
                try
                {
                    _mimeMessage.To.Add(MailboxAddress.Parse(_mail));
                }
                catch
                {
                }

            }
            if (_mimeMessage.To.Count == 0)
                return (IsSuccessful: false, Message: "No se hay emails validos.");


            if (email.Cc is not null)
                foreach (var item in email.Cc)
                {
                    try
                    {
                        _mimeMessage.Cc.Add(MailboxAddress.Parse(item));
                    }
                    catch
                    {

                    }
                }

            if (email.Bcc is not null)
                foreach (var item in email.Bcc)
                {
                    try
                    {
                        _mimeMessage.Bcc.Add(MailboxAddress.Parse(item));
                    }
                    catch
                    {

                    }
                }

            _mimeMessage.Sender.Name = configuration.DisplayName;
            _mimeMessage.Subject = email.Subject;
            _mimeMessage.From.Add(new MailboxAddress(configuration.DisplayName, configuration.Mail));

            var builder = new BodyBuilder();
            if (email.Attachments != null)
            {
                foreach (var file in email.Attachments)
                {
                    if (file.Bytes.Length > 0)
                        builder.Attachments.Add(file.Name, file.Bytes, ContentType.Parse(file.ContentType));
                }
            }

            builder.HtmlBody = email.Body;
            _mimeMessage.Body = builder.ToMessageBody();


            await smtp.SendAsync(_mimeMessage);

            return (IsSuccessful: true, Message: string.Empty);

        }
        catch (Exception ex)
        {
            if (smtp != null)
                smtp.Disconnect(true);
            return (IsSuccessful: false, Message: ex.Message);
        }
        finally
        {
            if (smtp != null)
                smtp.Disconnect(true);
        }

    }


    private SmtpClient CreateSMTP(SmtpConfiguration configuration)
    {

        var smtp = new SmtpClient();

        smtp.ServerCertificateValidationCallback += (sender, cert, chain, error) => true;


        smtp.SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13;

        if (configuration.Port == 0)
        {
            smtp.Connect(configuration.Host, options: SecureSocketOptions.Auto);
        }

        if (configuration.Port == 25)
            smtp.Connect(configuration.Host, port: configuration.Port, options: SecureSocketOptions.None);


        if (configuration.Port == 465)
            smtp.Connect(configuration.Host, port: configuration.Port, options: SecureSocketOptions.SslOnConnect);


        if (configuration.Port == 587)
            smtp.Connect(configuration.Host, port: configuration.Port, options: SecureSocketOptions.StartTlsWhenAvailable);



        if (!new int[] { 0, 25, 465, 587 }.Contains(configuration.Port))
            smtp.Connect(configuration.Host, port: configuration.Port, options: SecureSocketOptions.Auto);

        if (configuration.Authenticate)
            smtp.Authenticate(configuration.Mail, configuration.Password);

        return smtp;
    }
}
