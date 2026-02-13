namespace MyTodoApp.API.Services;

public class LocalMailService : IMailService
{
    private string _mailTo = "test@example.com";
    private string _mailFrom = "noreply@example.com";

    public void SendMail(string subject, string message)
    {
        Console.WriteLine($"Mail from {_mailFrom} to {_mailTo} with {nameof(LocalMailService)}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {message}");
    }
}