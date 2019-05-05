using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Interfaces;
using Services.Interfaces;
using Web.Models.ClientModels;
using Web.Models.TaskModels;

namespace Web.Controllers
{
    [Route("api/client")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ITaskService _taskService;
        private readonly IMappingService _mappingService;

        public ClientController(IClientService clientService, ITaskService taskService, IMappingService mappingService)
        {
            _clientService = clientService;
            _taskService = taskService;
            _mappingService = mappingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var clients = await _clientService.GetAsync();

            var clientsModel = _mappingService.Map<IEnumerable<Client>, List<ClientViewModel>>(clients);

            return Json(clientsModel);
        }    

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasksAsync(int id)
        {
            var tasks = await _taskService.GetTasksAsync(id);

            var tasksModel = _mappingService.Map<IEnumerable<ClientTask>, List<TaskViewModel>>(tasks);

            return Json(tasksModel);
        }     
    }
}