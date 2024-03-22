using eHealthToDoListTask.Core.Models;
using eHealthToDoListTask.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eHealthToDoListTask.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoItemRepo _toDoItemRepository;

        public ToDoItemsController(IToDoItemRepo toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetAllTasks()
        {
            var toDoItems = await _toDoItemRepository.GetAllToDoItemsAsync();
            return Ok(toDoItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetTaskById(int id)
        {
            var toDoItem = await _toDoItemRepository.GetToDoItemByIdAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            return Ok(toDoItem);
        }
        [HttpPost]
        public async Task<ActionResult<Task>> CreateTask(ToDoItem toDoItem)
        {
            await _toDoItemRepository.CreateToDoItemAsync(toDoItem);
            return CreatedAtAction(nameof(GetTaskById), new { id = toDoItem.Id }, toDoItem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, ToDoItem toDoItem)
        {
            try
            {
                await _toDoItemRepository.UpdateToDoItemAsync(id, toDoItem);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the toDoItem");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                await _toDoItemRepository.DeleteToDoItemAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while Deleteing the ToDoItem");
            }
        }
    }
}
