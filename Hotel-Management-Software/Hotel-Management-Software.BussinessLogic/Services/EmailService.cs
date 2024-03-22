namespace Hotel_Management_Software.BBL.Services;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    public async Task SendLoginCodeAsync(ApplicationUser UserToDTO)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("innkeepershotelmanagement@gmail.com"));
        email.To.Add(MailboxAddress.Parse(UserToDTO.Email));
        email.Subject = "Your Login Number";

        var htmlBody = $@"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Login Code</title>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #f4f4f4;
                        margin: 0;
                        padding: 0;
                    }}
                    .container {{
                        max-width: 600px;
                        margin: 50px auto;
                        padding: 20px;
                        background-color: #fff;
                        border-radius: 5px;
                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                    }}
                    h1 {{
                        color: #333;
                        text-align: center;
                    }}
                    p {{
                        color: #666;
                        line-height: 1.6;
                    }}
                    .code {{
                        font-size: 24px;
                        font-weight: bold;
                        text-align: center;
                        margin-bottom: 30px;
                        color: #007bff;
                    }}
                    .note {{
                        color: #999;
                        text-align: center;
                        margin-top: 20px;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1>Login Number</h1>
                    <p class='code'>{UserToDTO.UserName}</p>
                    <p class='note'>You will need this number in order to log in our software!</p>
                </div>
            </body>
            </html>";

        var builder = new BodyBuilder();
        builder.HtmlBody = htmlBody;
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync("smtp.gmail.com", 587, false);
        await smtp.AuthenticateAsync("innkeepershotelmanagement@gmail.com", "tdwgmatlsyofcuga"); // needs to be hiddden somewhere else
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public async Task SendResetLinkAsync(ApplicationUser user, string resetToken)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("innkeepershotelmanagement@gmail.com"));
        email.To.Add(MailboxAddress.Parse(user.Email));
        email.Subject = "Your Login Number";

        var htmlBody = $@"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Login Code</title>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #f4f4f4;
                        margin: 0;
                        padding: 0;
                    }}
                    .container {{
                        max-width: 600px;
                        margin: 50px auto;
                        padding: 20px;
                        background-color: #fff;
                        border-radius: 5px;
                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                    }}
                    h1 {{
                        color: #333;
                        text-align: center;
                    }}
                    p {{
                        color: #666;
                        line-height: 1.6;
                    }}
                    .code {{
                        font-size: 24px;
                        font-weight: bold;
                        text-align: center;
                        margin-bottom: 30px;
                        color: #007bff;
                    }}
                    .note {{
                        color: #999;
                        text-align: center;
                        margin-top: 20px;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1>Login Number</h1>
                    <p class='code'>{user.UserName}</p>
                    <p class='note'>You will need this number in order to log in our software!</p>
                    <p class='note'>Folow the link below to set your password.</p>
                    <a href='https://FrontEndPasswordResetEndpoint?token={resetToken}&user={user.UserName}'>Set Password</a>
                </div>
            </body>
            </html>";

        var builder = new BodyBuilder();
        builder.HtmlBody = htmlBody;
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync("smtp.gmail.com", 587, false);
        await smtp.AuthenticateAsync("innkeepershotelmanagement@gmail.com", "tdwgmatlsyofcuga"); // needs to be hiddden somewhere else
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
