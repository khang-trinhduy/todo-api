using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using todo_api.Models;
using todo_api.Services;

namespace todo_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class TasksController : ControllerBase
    {
        private readonly TodoServices _service;
        public TasksController(TodoServices services)
        {
            _service = services;
        }
        [HttpGet]
        public ActionResult<List<Task>> Get() => _service.Get();

        [HttpGet("{id:length(24)}", Name = "GetTask")]
        public ActionResult<Task> Get(string id) 
        {
            var task = _service.Get(id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            _service.Create(task);
            return CreatedAtAction("GetTask", new {id = task.Id});
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Task taskIn)
        {
            var task = _service.Get(id);

            if (task == null)
            {
                return NotFound();
            }

            _service.Update(id, taskIn);

            return NoContent();
        }

        [HttpDelete("id:length(24)")]
        public IActionResult Delete(string id)
        {
            var task = _service.Get(id);
            if (task == null)
            {
                return NotFound();
            }

            _service.Remove(id);
            return NoContent();
        }
    }
}