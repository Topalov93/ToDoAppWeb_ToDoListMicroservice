using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IToDoListRepository
    {
        public Task CreateToDoList(ToDoList newToDoList);

        public Task EditToDoList(int toDoListId, ToDoList newToDoList);

        public Task DeleteToDoList(int toDoListId);

        public Task AddToDoTask(ToDoTask toDoTask, int toDoListId);

        public Task<ToDoList> GetToDoListByTitle(string title);

        public Task<ToDoList> GetToDoListById(int id);

        public Task<List<ToDoTask>> GetToDoListToDoTasks(int toDoListId);
    }
}
