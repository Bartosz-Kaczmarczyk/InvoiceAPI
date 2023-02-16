namespace InvoiceAPI.Entities;

public class Item
{
    public int ItemId { get; set; }
    public int InvoiceId { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public decimal UnitNetPrice { get; set; }
    public decimal NetValue  => Math.Round((Amount*UnitNetPrice), 2);
    public int TaxRate { get; set; }
    public decimal TaxValue => Math.Round((NetValue*TaxRate*0.01m), 2);
    public decimal GrossValue => (NetValue+TaxValue);
}