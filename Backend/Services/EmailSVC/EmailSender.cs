using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier.DataAccessModel;
using System.IO;
using DataAccessTier.DataAccessController;


namespace Services
{
   
    public class EmailSender
    {
        CurrectEmail currectEmail = new CurrectEmail();
        DataAccessCompany dataAccess = new DataAccessCompany();
        public async Task SendEmail(Company company, string attachmentPath)
        {
            if (string.IsNullOrWhiteSpace(company?.Email))
            {
                company.Email = currectEmail.EmailCurrection(company.Email);
            }

            var fromEmail = "Osama.Elayan.1993@gmail.com";
            var toEmail = company.Email;
            var subject = "Application for .NET Developer – Full-Time or Freelance Collaboration";

            var body = $@"
<html>
  <body style='font-family: Arial, sans-serif; color: #333; line-height: 1.6; padding: 10px;'>
    <p>Dear <strong>{company.Name}</strong> Team,</p>

    <p>I hope this message finds you well.</p>

    <p>
      My name is <strong>Osama Elayan</strong>, a passionate .NET developer with strong experience in backend development,
      SQL Server database design, and modern web technologies like HTML, CSS, JavaScript, and AngularJS.
    </p>

    <p>
      I am reaching out to express my interest in contributing to your company—either through a full-time role or as a freelance collaborator on any current or upcoming projects.
      I have successfully built and delivered systems such as a property management solution for a Dubai client and a tourism/seafood app for local markets.
    </p>

    <p>
      I would be thrilled to bring my technical expertise, work ethic, and enthusiasm to your team or help remotely as a freelancer.
      Please find my CV attached for your review.
    </p>

    <p>Thank you for your time, and I look forward to the possibility of working together.</p>

    <p style='margin-top: 30px;'>
      Best regards,<br />
      <strong>Osama Elayan</strong><br />
      <a href='mailto:osama.elayan.1993@gmail.com' style='color: #1a73e8;'>osama.elayan.1993@gmail.com</a><br />
      <span>+962 7 9733 5485</span><br />
      <a href='https://www.linkedin.com/in/osama-elayan-b35125115/' style='color: #1a73e8;'>LinkedIn Profile</a> | 
      <a href='https://github.com/Osama-93' style='color: #1a73e8;'>GitHub</a>
    </p>
  </body>
</html>
";

                var message = new MailMessage(fromEmail, toEmail.Replace("\u00A0", "").Replace(" ", ""), subject, body)
                {
                    IsBodyHtml = true
                };

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(fromEmail, "ddgsvehvwxpkjypx")
                };

                if (File.Exists(attachmentPath))
                {
                    Attachment attachment = new Attachment(attachmentPath);
                    message.Attachments.Add(attachment);
                }
            try
            {
                await smtp.SendMailAsync(message);
                company.isActive = false;
                company.sentDate = DateTime.Now;
            }
            catch (SmtpException smtpEx)
            {
                // Log or handle SMTP-specific exceptions
                throw new Exception($"SMTP error: {smtpEx.StatusCode} - {smtpEx.Message}", smtpEx);
            }
            catch (Exception ex)
            {
                // Log or handle general exceptions
                throw new Exception($"Email sending failed: {ex.Message}", ex);
            }



        }
    }
}
