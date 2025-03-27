using examen2_aaron_lemus_61421189.Models;
using examen2_aaron_lemus_61421189.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace examen2_aaron_lemus_61421189.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;
        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Models.Task>>> GetTasks()
        {
            var tasks = await _taskService.getTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> GetTaskById(int id)
        {
            var task = await _taskService.GetById(id);
            if (task == null) return NotFound("Tarea no encontrada");

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask([FromBody] Models.Task task)
        {
            if (task == null)
            {
                return BadRequest("Datos de tarea vienen vacios");
            }
            var newTask = await _taskService.CreateTask(task);
            return Ok(newTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, [FromBody] Models.Task updatedTask)
        {
            if (updatedTask == null)
            {
                return BadRequest("Datos de tarea vienen vacios");
            }

            var response = await _taskService.UpdateTask(id, updatedTask);

            if (response == false)
            {
                return NotFound("Tarea no encontrada en base de datos");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var response = await _taskService.DeleteTask(id);
            if (response == false)
            {
                return NotFound("Tarea no encontrada en base de datos");
            }
            return NoContent();
        }
    }
}
