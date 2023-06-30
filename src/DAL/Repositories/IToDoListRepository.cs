using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IToDoListRepository
    {
        public Task<List<ToDoList>> GetAsync();

        public Task<ToDoList?> GetAsync(string id);

        public Task CreateAsync(ToDoList newBook);

        public Task UpdateAsync(string id, ToDoList updatedBook);

        public Task RemoveAsync(string id);

        public Task<ToDoList?> GetByTitleAsync(string title);
    }
}
