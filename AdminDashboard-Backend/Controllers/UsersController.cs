using Microsoft.AspNetCore.Mvc;
using AdminDashboardAPI.Models;
using AdminDashboardAPI.Services;

namespace AdminDashboardAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly JsonDataService _dataService;

    public UsersController(JsonDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(_dataService.GetUsers());
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = _dataService.GetUserById(id);
        if (user == null)
            return NotFound(new { message = $"لم يتم العثور على مستخدم برقم {id}" });

        return Ok(user);
    }
}