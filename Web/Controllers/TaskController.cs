using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Interfaces;
using Services.Interfaces;
using Web.Models.TaskModels;

namespace Web.Controllers
{
    [Route("api/task")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IMappingService _mappingService;

        public TaskController(ITaskService taskService, IMappingService mappingService)
        {
            _taskService = taskService;
            _mappingService = mappingService;
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskAsync(int id)
        {
            var task = await _taskService.GetAsync(id);

            var taskModel = _mappingService.Map<ClientTask, TaskViewModel>(task);

            return Json(taskModel);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateTask(int id, [FromBody] TaskModel taskModel)
        {
            var task = _mappingService.Map<TaskModel, ClientTask>(taskModel);

            task.ClientId = id;

            await _taskService.CreateAsync(task);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task UpdateTask(int id, [FromBody] TaskModel taskModel)
        {
            var task = await _taskService.GetAsync(id);

            _mappingService.Map(taskModel, task);

            await _taskService.UpdateAsync(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteAsync(id);

            return Ok();
        }
    }
}