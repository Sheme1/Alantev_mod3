using System;

public class NotificationEventArgs : EventArgs
{
    public string Notification { get; set; }
}

public class Notification
{
    public event EventHandler<NotificationEventArgs> OnMessage;
    public event EventHandler<NotificationEventArgs> OnCall;
    public event EventHandler<NotificationEventArgs> OnEmail;

    public void SendMessage(string notification)
    {
        OnMessage?.Invoke(this, new NotificationEventArgs { Notification = notification });
    }

    public void MakeCall(string notification)
    {
        OnCall?.Invoke(this, new NotificationEventArgs { Notification = notification });
    }

    public void SendEmail(string notification)
    {
        OnEmail?.Invoke(this, new NotificationEventArgs { Notification = notification });
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var notification = new Notification();

        notification.OnMessage += (sender, e) => Console.WriteLine($"Сообщение: {e.Notification}");
        notification.OnCall += (sender, e) => Console.WriteLine($"Звонок: {e.Notification}");
        notification.OnEmail += (sender, e) => Console.WriteLine($"Электронное письмо: {e.Notification}");

        notification.SendMessage("Привет!");
        notification.MakeCall("Звонок от друга");
        notification.SendEmail("Новое письмо");
    }
}
