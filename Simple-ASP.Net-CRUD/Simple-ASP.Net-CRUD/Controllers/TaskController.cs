using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_ASP.Net_CRUD.Models;
using Simple_ASP.Net_CRUD.Repositories.Interfaces;

namespace Simple_ASP.Net_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetAll();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> FindById(int id)
        {
            TaskModel task = await _taskRepository.FindById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> SignUp([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.Add(taskModel);

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel task = await _taskRepository.Update(taskModel, id);

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {
            bool taskRemoved = await _taskRepository.Delete(id);
            return Ok(taskRemoved);
        }
    }
}
