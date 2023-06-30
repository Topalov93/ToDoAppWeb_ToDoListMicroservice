using Common;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IToDoListService
    {
        public Task<ResultState> CreateToDoList(ToDoList newToDoList);


        public Task<ResultState> EditToDoList(string toDoListId, ToDoList newToDoList);


        public Task<ResultState> DeleteToDoList(string toDoListId);


        public Task<ResultState> AddToDoTask(string toDoTaskId, string toDoListId);


        //public Task<List<ToDoTask>> GetToDoListToDoTasks(string toDoListId);


        public Task<ToDoList> GetToDoListByTitle(string title);


        public Task<ToDoList> GetToDoListById(string id);

        public Task<List<ToDoList>> GetToDoLists();

    }
}
