using Common;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IToDoListService
    {
        public Task<ResultState> CreateToDoList(ToDoList newToDoList);


        public Task<ResultState> EditToDoList(int toDoListId, ToDoList newToDoList);


        public Task<ResultState> DeleteToDoList(int toDoListId);


        public Task<ResultState> AddToDoTask(ToDoTask toDoTask, int toDoListId);


        public Task<List<ToDoTask>> GetToDoListToDoTasks(int toDoListId);


        public Task<ToDoList> GetToDoListByTitle(string title);


        public Task<ToDoList> GetToDoListById(int id);

    }
}
