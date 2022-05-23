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
            ToDoList toDoList = await _toDoListRepository.GetToDoListByTitle(newToDoList.Title);

            if (toDoList is not null)
            {
                return new ResultState(false, "ToDoList already exist");
            }

            try
            {
                await _toDoListRepository.CreateToDoList(newToDoList);
                return new ResultState(true, "Successful");
            }
            catch (Exception ex)
            {
                return new ResultState(false, "Unable to create ToDoList", ex);
            }
        }

        public async Task<ResultState> EditToDoList(int toDoListId, ToDoList newToDoList)
        {
            ToDoList toDoList = await _toDoListRepository.GetToDoListById(toDoListId);

            if (toDoList is null)
            {
                return new ResultState(false, "ToDoList don't exist");
            }

            newToDoList.EditedOn = DateTime.UtcNow;

            try
            {
                await _toDoListRepository.EditToDoList(toDoListId, newToDoList);
                return new ResultState(true, "Successful");
            }
            catch (Exception ex)
            {
                return new ResultState(false, "Unable to edit ToDoList", ex);
            }
        }

        public async Task<ResultState> DeleteToDoList(int toDoListId)
        {
            ToDoList toDoList = await _toDoListRepository.GetToDoListById(toDoListId);

            if (toDoList is null)
            {
                return new ResultState(false, "ToDoList don't exist");
            }

            try
            {
                await _toDoListRepository.DeleteToDoList(toDoListId);
                return new ResultState(true, "Successful");
            }
            catch (Exception ex)
            {
                return new ResultState(false, "Unable to delete ToDoList", ex);
            }
        }

        public async Task<ResultState> AddToDoTask(ToDoTask toDoTask, int toDoListId)
        {
            ToDoList toDoList = await _toDoListRepository.GetToDoListById(toDoListId);

            if (toDoList is null)
            {
                return new ResultState(false, "ToDoList don't exist");
            }

            try
            {
                await _toDoListRepository.AddToDoTask(toDoTask, toDoListId);
                return new ResultState(true, "Successful");
            }
            catch (Exception ex)
            {
                return new ResultState(false, "Unable to add task to ToDoList", ex);
            }
        }

        public async Task<List<ToDoTask>> GetToDoListToDoTasks(int toDoListId)
        {
            return await _toDoListRepository.GetToDoListToDoTasks(toDoListId);
        }

        public async Task<ToDoList> GetToDoListByTitle(string title)
        {
            return await _toDoListRepository.GetToDoListByTitle(title);
        }

        public async Task<ToDoList> GetToDoListById(int id)
        {
            return await _toDoListRepository.GetToDoListById(id);
        }
    }

}
