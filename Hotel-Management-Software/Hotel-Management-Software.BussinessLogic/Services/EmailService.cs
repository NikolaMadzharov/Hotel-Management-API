namespace Hotel_Management_Software.BBL.Services;

using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    public async Task SendEmailForBookedReservation(Reservation reservation)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("innkeepershotelmanagement@gmail.com"));
        email.To.Add(MailboxAddress.Parse(reservation.Guest.EmailAddress));
        email.Subject = "Reservation Confirmation";

        var htmlBody = $@"
        <!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""UTF-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
  <title>Holiday Getaway Confirmation</title>
  <style>
    body {{
      font-family: Arial, sans-serif;
      margin: 0;
      padding: 0;
      background-color: #f4f4f4;
    }}
    .container {{
      max-width: 600px;
      margin: 20px auto;
      background-color: #fff;
      padding: 20px;
      border-radius: 10px;
      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }}
    h1, h2 {{
      color: #333;
      text-align: center;
    }}
    p {{
      margin-bottom: 15px;
    }}
    .reservation-info {{
      border-top: 2px solid #ccc;
      margin-top: 20px;
      padding-top: 20px;
    }}
    .footer {{
      text-align: center;
      margin-top: 20px;
      color: #666;
    }}
  </style>
</head>
<body>
  <div class=""container"">
    <h1>Holiday Getaway Confirmation</h1>
    <p>Dear {reservation.Guest.FirstName} {reservation.Guest.LastName},</p>
    <p>Your holiday getaway reservation has been confirmed. Below are the details:</p>
    <div class=""reservation-info"">
      <h2>Reservation Details:</h2>
      <p><strong>Reservation ID:</strong> {reservation.Id}</p>
      <p><strong>Check-in Date:</strong> {reservation.From}</p>
      <p><strong>Check-out Date:</strong> {reservation.To}]</p>
      <p><strong>Additional Information:</strong> {reservation.Guest.AdditionalInformation}</p>
      <p><strong>Price:</strong> [cenata na rezervaciqta]</p>
    </div>
    <p>Thank you for choosing us for your holiday getaway. We hope you have a fantastic time!</p>
    <p class=""footer"">Best regards,<br> [imeto na hotela]</p>
  </div>
</body>
</html>"
;

        var builder = new BodyBuilder();
        builder.HtmlBody = htmlBody;
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync("smtp.gmail.com", 587, false);
        await smtp.AuthenticateAsync("innkeepershotelmanagement@gmail.com", "tdwgmatlsyofcuga"); 
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

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
    <title>Password Setup</title>
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
            text-align: center;
        }}
        .code {{
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 30px;
            color: #007bff;
        }}
        .note {{
            color: #999;
            margin-top: 20px;
        }}
        .button {{
            display: inline-block;
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            text-decoration: none;
            border-radius: 5px;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <h1>Welcome to Our Team!</h1>
        <p>Your registration was successful. To ensure the security of your account, please set up your password.</p>
        <p class='code'>Your LogcinCode: {user.UserName}</p>
        <p class='note'>You will use this login code along with your password to log in.</p>
        <p class='note'>Please click the button below to set up your password:</p>
        <a class='button' href='http://localhost:3000/settings/account/pass-reset?token={resetToken}&user={user.UserName}'>Set Password</a>
        <p class='note'>If you did not register for an account, please ignore this email.</p>
    </div>
</body>
</html>
";

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
