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

        public async Task<ResultState> CreateToDoList(ToDoList newToDoList)
        {
            //ToDoList toDoList = await _toDoListRepository.GetToDoTaskByTitle(newToDoTask.Title);

            //if (toDoTask is not null)
            //{
            //    return new ResultState(false, Messages.ToDoTaskAlreadyExist);
            //}

            //newToDoTask.IsCompleted = false;

            //try
            //{
            await _toDoListRepository.CreateToDoList(newToDoList);
            return new ResultState(true, "Successful");
            //}
            //catch (Exception ex)
            //{
            //    return new ResultState(false, Messages.UnableToCreateToDoTask, ex);
            //}
        }

        public async Task<ToDoList> GetToDoListByTitle(string title)
        {
            return await _toDoListRepository.GetToDoListByTitle(title);
        }

        public async Task<ToDoList> GetToDoListById(int id)
        {
            return await _toDoListRepository.GetToDoListById(id);
        }

        public async Task<ResultState> DeleteToDoList(int taskId)
        {
            ToDoTask toDoTask = await _toDoTaskRepository.GetToDoTaskById(taskId);

            if (toDoTask is null)
            {
                return new ResultState(false, Messages.ToDoTaskDoesntExist);
            }

            try
            {
                await _toDoTaskRepository.DeleteToDoTask(taskId);
                return new ResultState(true, Messages.ToDoTaskDeletedSuccessfull);
            }
            catch (Exception ex)
            {
                return new ResultState(false, Messages.UnableToDeleteToDoTask, ex);
            }
        }
    }
}
