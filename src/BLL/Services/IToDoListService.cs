using Common;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IToDoListService
    {
        public Task<ResultState> CreateToDoList(ToDoList newToDoList);
    }
}
