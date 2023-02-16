using InvoiceAPI.Entities;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace InvoiceAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PrintController : ControllerBase
{
    private readonly ITemplateService _templateService;

    public PrintController(ITemplateService templateService)
    {
        _templateService = templateService;
    }

    [HttpGet]
   public async Task<IActionResult> Print()
   {
       var model = new Invoice
       {
            InvoiceId = 1,
            UserId = 1,
            InvoiceNumber = "FV 02/2023",
            InvoiceDate = DateTime.Now,
            InvoiceDue = DateTime.Now.AddDays(7),
            PaymentMethod  = PaymentMethod.Przelew,
            CompanyId = 1,
            Company = new Company()
            {
                CompanyId = 1,
                UserId = 1,
                Name = "Ogrody",
                Street = "Zielona",
                Number = "1",
                City = "Skawina",
                ZipCode = "32-050",
                TIN = "921255658",
                AccountNumber = "50 1000 1000 1000 1000 1000 1000",
                LastInvoiceNumber = "FV 01/2023"
            },
            CustomerId = 1,
            Customer = new Customer()
            {
                CustomerId =1,
                UserId = 1,
                Name = "Klient",
                Street = "Wczasowa",
                Number = "1",
                City = "Skawina",
                ZipCode = "32-050", 
                TIN = "921255658"
            },
            Items = new List<Item>
            {
                new Item()
                {
                    ItemId = 1,
                    InvoiceId = 1,
                    Description = "Koszenie trawy",
                    Amount = 150m,
                    UnitNetPrice = 0.50m,
                    TaxRate = 8,
                },
                new Item()
                {
                    ItemId = 2,
                    InvoiceId = 1,
                    Description = "Sadzenie drzew",
                    Amount = 20m,
                    UnitNetPrice = 25m,
                    TaxRate = 8,
                }
            },
            TotalPaid = 0m
       };
       var html = await _templateService.RenderAsync("Templates/InvoiceTemplate", model);
       await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
       {
           Headless = true,
           ExecutablePath = PuppeteerExtensions.ExecutablePath
       });
       await using var page = await browser.NewPageAsync();
       await page.EmulateMediaTypeAsync(MediaType.Screen);
       await page.SetContentAsync(html);
       var pdfContent = await page.PdfStreamAsync(new PdfOptions
       {
           Format = PaperFormat.A4,
           PrintBackground = true
       });
       return File(pdfContent, "application/pdf", $"Invoice-{model.InvoiceId}.pdf");
   }
}
