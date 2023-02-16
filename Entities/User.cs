namespace InvoiceAPI.Entities;

public class User
{
    public int UserId { get; set; }
    public virtual Company Company { get; set; }
    public virtual List<Customer> Customers { get; set; }
    public virtual List<Invoice> Invoices { get; set; }
}
