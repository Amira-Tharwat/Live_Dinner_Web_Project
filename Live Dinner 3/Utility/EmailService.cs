using Microsoft.AspNetCore.Identity.UI.Services;

namespace Live_Dinner_3.Utility
{
    public class EmailService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            //logic email
            return Task.CompletedTask;
        }
    }
}
