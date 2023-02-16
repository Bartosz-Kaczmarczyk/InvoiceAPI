namespace InvoiceAPI.Entities;
public enum PaymentMethod
{
    Gotówka, Karta, Przelew
}
public class Invoice
{
    public int InvoiceId { get; set; }
    public int UserId { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime InvoiceDue { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual List<Item> Items { get; set; }

    public decimal TatalNetValue => Items.Sum(i => i.NetValue);
    public decimal TotalTaxValue => Items.Sum(i => i.TaxValue);
    public decimal TotalGrossValue => Items.Sum(i => i.GrossValue);
    public decimal TotalPaid { get; set; }
    public decimal TotalLeftToPay => (TotalGrossValue-TotalPaid);
}