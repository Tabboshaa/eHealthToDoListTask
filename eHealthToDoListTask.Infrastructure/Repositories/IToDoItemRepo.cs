using eHealthToDoListTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthToDoListTask.Infrastructure.Repositories
{
    public interface IToDoItemRepo
    {
        Task<ToDoItem> GetToDoItemByIdAsync(int id);
        Task<IEnumerable<ToDoItem>> GetAllToDoItemsAsync();
        Task CreateToDoItemAsync(ToDoItem toDoItem);
        Task UpdateToDoItemAsync(int id, ToDoItem updatedToDoItem);
        Task DeleteToDoItemAsync(int id);
    }
}
