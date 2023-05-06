using CTTSite.Models;

namespace CTTSite.Services.Interface
{
	public interface IEmailService
	{
		void SendEmail(Email request);
	}
}
