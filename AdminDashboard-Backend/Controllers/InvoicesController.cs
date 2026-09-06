using Microsoft.AspNetCore.Mvc;
using AdminDashboardAPI.Models;
using AdminDashboardAPI.Services;

namespace AdminDashboardAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController : ControllerBase
{
    private readonly JsonDataService _dataService;

    public InvoicesController(JsonDataService dataService)
    {
        _dataService = dataService;
    }

    // GET: api/invoices
    [HttpGet]
    public ActionResult<IEnumerable<Invoice>> GetInvoices()
    {
        return Ok(_dataService.GetInvoices());
    }

    // GET: api/invoices/{id}
    [HttpGet("{id}")]
    public ActionResult<Invoice> GetInvoice(int id)
    {
        var invoice = _dataService.GetInvoiceById(id);
        if (invoice == null)
            return NotFound(new { message = $"لم يتم العثور على فاتورة برقم {id}" });

        return Ok(invoice);
    }
}