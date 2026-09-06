using Microsoft.AspNetCore.Mvc;
using AdminDashboardAPI.Models;
using AdminDashboardAPI.Services;

namespace AdminDashboardAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly JsonDataService _dataService;

    public ContactsController(JsonDataService dataService)
    {
        _dataService = dataService;
    }

    // GET: api/contacts
    [HttpGet]
    public ActionResult<IEnumerable<Contact>> GetContacts()
    {
        return Ok(_dataService.GetContacts());
    }

    // GET: api/contacts/{id}
    [HttpGet("{id}")]
    public ActionResult<Contact> GetContact(int id)
    {
        var contact = _dataService.GetContactById(id);
        if (contact == null)
            return NotFound(new { message = $"لم يتم العثور على جهة اتصال برقم {id}" });

        return Ok(contact);
    }
}