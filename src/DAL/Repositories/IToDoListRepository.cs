using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IToDoListRepository
    {
        public Task CreateToDoList(ToDoList newToDoList);

        public Task<ToDoList> GetToDoListByTitle(string title);
        Task<ToDoList> GetToDoListById(int id);
    }
}
