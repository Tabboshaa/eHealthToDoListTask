using eHealthToDoListTask.Core.Models;
using eHealthToDoListTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthToDoListTask.Infrastructure.Repositories
{
    public class ToDoItemRepo : IToDoItemRepo
    {
        private readonly ToDoDbContext _dbContext;

        public ToDoItemRepo(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ToDoItem>> GetAllToDoItemsAsync()
        {
            return await _dbContext.ToDoItems.ToListAsync();
        }
        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            return await _dbContext.ToDoItems.FirstOrDefaultAsync(item=>item.Id==id);
        }

 
        public async Task CreateToDoItemAsync(ToDoItem toDoItem)
        {
            _dbContext.ToDoItems.Add(toDoItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateToDoItemAsync(int id, ToDoItem updatedToDoItem)
        {
            var existingTodoItem = await GetToDoItemByIdAsync(id);
            if (existingTodoItem == null)
            {
                throw new InvalidOperationException($"ToDoItem with ID {id} not found.");
            }

            existingTodoItem.Title = updatedToDoItem.Title;
            existingTodoItem.Description = updatedToDoItem.Description;
            existingTodoItem.DueDate = updatedToDoItem.DueDate;
            existingTodoItem.IsCompleted = updatedToDoItem.IsCompleted;

            _dbContext.Entry(existingTodoItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteToDoItemAsync(int id)
        {
            var existingTodoItem = await GetToDoItemByIdAsync(id);
            if (existingTodoItem == null)
            {
                throw new InvalidOperationException($"ToDoItem with ID {id} not found.");
            }

            _dbContext.ToDoItems.Remove(existingTodoItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
