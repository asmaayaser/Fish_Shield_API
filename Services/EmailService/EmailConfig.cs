using MailKit.Net.Smtp;
using MimeKit;

namespace Services.EmailService
{
    public class EmailConfig
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      
    }

   public class Message
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Message(string to,string subject,string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
   } 

    public interface IEmailSender
    {
        Task SendAsync(Message message);
    }

    public class EmailSender : IEmailSender
    {
        private readonly EmailConfig emailConfig;

        public EmailSender(EmailConfig emailConfig)
        {
            this.emailConfig = emailConfig;
        }

        public async Task SendAsync(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

           await SendMessageAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage= new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(emailConfig.From, emailConfig.Email));
            emailMessage.To.Add(new MailboxAddress(message.To, message.To));

            emailMessage.Subject=message.Subject;
            emailMessage.Body= new TextPart() { Text=message.Body};

            return emailMessage;

        }
        private async Task SendMessageAsync(MimeMessage emailMessage)
        {

            using (var client = new SmtpClient())
            {
                try
                {
                
                   await client.ConnectAsync(emailConfig.SmtpServer,emailConfig.Port,MailKit.Security.SecureSocketOptions.StartTls);
                   await client.AuthenticateAsync(emailConfig.Email,emailConfig.Password);
                   await client.SendAsync(emailMessage);
                   
                

                }catch
                {
                    throw;
                }finally
                {
                   await client.DisconnectAsync(quit: true);
                   client.Dispose();
                }
            }
        }

    }
}
