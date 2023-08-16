namespace PulseemCMS.Domain.Entities;
public class Client
{
    public long ClientID { get; set; }

    public string Cellphone { get; set; } =String.Empty;

    public string Email { get; set; } = String.Empty;

    public string ClientName { get; set; } = String.Empty;

    public bool EmailStatus { get; set; }

    public bool SmsStatus { get; set; }
}

