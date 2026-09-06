using Microsoft.AspNetCore.Mvc;
using AdminDashboardAPI.Models;
using AdminDashboardAPI.Services;

// توضيح المرجع لتجنب التعارض مع System.Threading.Tasks.Task
using Task = AdminDashboardAPI.Models.Task;

namespace AdminDashboardAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly JsonDataService _dataService;

    public TasksController(JsonDataService dataService)
    {
        _dataService = dataService;
    }

    // GET: api/tasks
    [HttpGet]
    public ActionResult<IEnumerable<Task>> GetTasks()
    {
        return Ok(_dataService.GetTasks());
    }

    // GET: api/tasks/{id}
    [HttpGet("{id}")]
    public ActionResult<Task> GetTask(int id)
    {
        var task = _dataService.GetTaskById(id);
        if (task == null)
            return NotFound(new { message = $"لم يتم العثور على مهمة برقم {id}" });

        return Ok(task);
    }
}