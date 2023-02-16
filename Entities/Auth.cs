namespace InvoiceAPI.Entities;

public class Auth
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}