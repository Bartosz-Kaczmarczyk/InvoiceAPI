namespace InvoiceAPI.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string TIN { get; set; }
}