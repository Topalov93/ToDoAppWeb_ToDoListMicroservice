using Common;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            ToDoList toDoList = await _toDoListRepository.GetByTitleAsync(newToDoList.Title);

            if (toDoList is not null)
            {
                return new ResultState(false, "ToDoList with that name already exist");
            }

            try
            {
                await _toDoListRepository.CreateAsync(newToDoList);
                return new ResultState(true, "Successful");
            }
            catch (Exception ex)
            {
                return new ResultState(false, "Unable to create ToDoList", ex);
            }
        }

        public async Task<ResultState> EditToDoList(string toDoListId, ToDoList newToDoList)
        {
            ToDoList toDoList = await _toDoListRepository.GetAsync(toDoListId);

            if (toDoList is null)
            {
                return new ResultState(false, "ToDoList don't exist");
            }

            newToDoList.EditedOn = DateTime.UtcNow;

            try
            {
                await _toDoListRepository.UpdateAsync(toDoListId, newToDoList);
                return new ResultState(true, "Successful");
            }
            catch (Exception ex)
            {
                return new ResultState(false, "Unable to edit ToDoList", ex);
            }
        }

        public async Task<ResultState> DeleteToDoList(string toDoListId)
        {
            ToDoList toDoList = await _toDoListRepository.GetAsync(toDoListId);

            if (toDoList is null)
            {
                return new ResultState(false, "ToDoList don't exist");
            }

            try
            {
                await _toDoListRepository.RemoveAsync(toDoListId);
                return new ResultState(true, "Successful");
            }
            catch (Exception ex)
            {
                return new ResultState(false, "Unable to delete ToDoList", ex);
            }
        }

        public async Task<ResultState> AddToDoTask(string toDoListId)
        {
            ToDoList toDoList = await _toDoListRepository.GetAsync(toDoListId);

            if (toDoList is null)
            {
                return new ResultState(false, "ToDoList don't exist");
            }

            var tasks = await GetTasksBacklog();
            if (tasks is null) return new ResultState(false, "Unsuccessful fetching ot tasks backlog");

            //Pick task form the backlog
            var todoTask = tasks.First();

            toDoList.ToDoTasks.Add(todoTask);
            try
            {
                await _toDoListRepository.UpdateAsync(toDoListId, toDoList);
                return new ResultState(true, "Successful");
            }
            catch (Exception ex)
            {
                return new ResultState(false, "Unable to add task to ToDoList", ex);
            }
        }

        public async Task<ToDoList> GetToDoListByTitle(string title)
        {
            return await _toDoListRepository.GetByTitleAsync(title);
        }

        public async Task<ToDoList> GetToDoListById(string id)
        {
            return await _toDoListRepository.GetAsync(id);
        }

        public async Task<List<ToDoList>> GetToDoLists()
        {
            return await _toDoListRepository.GetAsync();
        }

        public async Task<List<ToDoTask>> GetTasksBacklog()
        {
            using var client = new HttpClient();
            List<ToDoTask> backlog = new List<ToDoTask>();
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.GetAsync("http://localhost:5001/api/ToDoTask/backlog");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (response.IsSuccessStatusCode)
            {
                var backlogAsString = await response.Content.ReadAsStringAsync();
                backlog = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ToDoTask>>(backlogAsString);
            }
            else
            {
                await Console.Out.WriteLineAsync(response.Content.ToString());
            }

            return backlog;
        }

        public async Task<List<ToDoTask>> GetUsersList()
        {
            using var client = new HttpClient();
            List<ToDoTask> backlog = new List<ToDoTask>();
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.GetAsync("http://localhost:5001/api/ToDoTask/backlog");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (response.IsSuccessStatusCode)
            {
                var backlogAsString = await response.Content.ReadAsStringAsync();
                backlog = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ToDoTask>>(backlogAsString);
            }
            else
            {
                await Console.Out.WriteLineAsync(response.Content.ToString());
            }

            return backlog;
        }
    }

}
