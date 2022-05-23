using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private ToDoListDbContext _context;

        public ToDoListRepository(ToDoListDbContext context)
        {
            _context = context;
        }

        public async Task CreateToDoList(ToDoList newToDoList)
        {
            await _context.ToDoLists.Add(newToDoList).ReloadAsync();
            _context.SaveChanges();
        }

        public async Task EditToDoList(int toDoListId, ToDoList newToDoList)
        {
            ToDoList toDoList = await GetToDoListById(toDoListId);

            toDoList.Title = newToDoList.Title;
            toDoList.Description = newToDoList.Description;
            toDoList.AddedOn = newToDoList.AddedOn;
            toDoList.EditedOn = newToDoList.EditedOn;

            _context.SaveChanges();
        }

        public async Task DeleteToDoList(int toDoListId)
        {
            ToDoList toDoList = await GetToDoListById(toDoListId);

            _context.ToDoLists.Remove(toDoList);

            _context.SaveChanges();
        }

        public async Task<ToDoList> GetToDoListByTitle(string title)
        {
            return await _context.ToDoLists.FirstOrDefaultAsync(t => t.Title == title);
        }

        public async Task<ToDoList> GetToDoListById(int id)
        {
            return await _context.ToDoLists.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<ToDoTask>> GetToDoListToDoTasks(int toDoListId)
        {
            return await _context.ToDoLists.SelectMany(l => l.ToDoTasks).Where(l => l.Id == toDoListId).ToListAsync();
        }
    }
}
