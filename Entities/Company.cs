namespace InvoiceAPI.Entities;

public class Company
{
    public int CompanyId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string TIN { get; set; }
    public string AccountNumber { get; set; }
    public string LastInvoiceNumber { get; set; }
}
