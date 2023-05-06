using CTTSite.Models;
using CTTSite.Services.Interface;
using MimeKit;

namespace CTTSite.Services.NormalService
{
	public class EmailService : IEmailService
	{
		// Made by Christian

		private readonly IConfiguration _config;

		public EmailService(IConfiguration config) 
		{ 
		     _config = config;
		}

		public void SendEmail(Email request)
		{
			var email = new MimeMessage();
			email.From.Add(MailboxAddress.Parse("CTT_Test@outlook.com")); // Add your email address
			email.To.Add(MailboxAddress.Parse(request.To));
			email.Subject = request.Subject;
			email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = request.Body };

			using var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls); // Add your email provider
			smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value); // Add your email address and password
			smtp.Send(email);
			smtp.Disconnect(true);
		}
	}
}
