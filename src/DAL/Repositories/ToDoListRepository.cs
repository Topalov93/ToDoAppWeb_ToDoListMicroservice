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

        public async Task<ToDoList> GetToDoListByTitle(string title)
        {
            return await _context.ToDoLists.FirstOrDefaultAsync(t => t.Title == title);
        }

        public async Task<ToDoList> GetToDoListById(int id)
        {
            return await _context.ToDoLists.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
