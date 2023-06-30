using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly IMongoCollection<ToDoList> _toDoLists;

        public ToDoListRepository(
            IOptions<ToDoListServiceDatabaseSettings> taskServiceDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                taskServiceDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                taskServiceDatabaseSettings.Value.DatabaseName);

            _toDoLists = mongoDatabase.GetCollection<ToDoList>(
                taskServiceDatabaseSettings.Value.ToDoListsCollectionName);
        }

        public async Task<List<ToDoList>> GetAsync() =>
            await _toDoLists.Find(_ => true).ToListAsync();

        public async Task<ToDoList?> GetAsync(string id) =>
            await _toDoLists.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ToDoList newBook) =>
            await _toDoLists.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, ToDoList updatedBook) =>
            await _toDoLists.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _toDoLists.DeleteOneAsync(x => x.Id == id);

        public async Task<ToDoList?> GetByTitleAsync(string title) =>
            await _toDoLists.Find(x => x.Title == title).FirstOrDefaultAsync();
    }
}
