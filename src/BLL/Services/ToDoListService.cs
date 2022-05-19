using Common;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ToDoListService : IToDoListService
    {
        public IToDoListRepository _toDoListRepository;

        public ToDoListService(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        //public async Task<ResultState> CreateTask(ToDoList newToDoTask)
        //{
            //ToDoList toDoList = await _toDoListRepository.GetToDoTaskByTitle(newToDoTask.Title);

            //if (toDoTask is not null)
            //{
            //    return new ResultState(false, Messages.ToDoTaskAlreadyExist);
            //}

            //newToDoTask.IsCompleted = false;

            //try
            //{
            //    await _toDoTaskRepository.CreateToDoTask(newToDoTask);
            //    return new ResultState(true, Messages.ToDoTaskCreationSuccessfull);
            //}
            //catch (Exception ex)
            //{
            //    return new ResultState(false, Messages.UnableToCreateToDoTask, ex);
            //}
        //}
    }
}
