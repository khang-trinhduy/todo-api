using System.Collections.Generic;
using MongoDB.Driver;
using todo_api.Models;

namespace todo_api.Services
{
    public class TodoServices
    {
        private readonly IMongoCollection<Task> _task;
        public TodoServices(ITodoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Databasename);
            _task = database.GetCollection<Task>(settings.TodoCollectionName);
        }

        public List<Task> Get() => _task.Find(e => true).ToList();

        public Task Get(string id) => _task.Find(e => e.Id == id).FirstOrDefault();

        public Task Create(Task task) {
            _task.InsertOne(task);
            return task;
        }

        public void Update(string id, Task task) {
            _task.ReplaceOne(e => e.Id == id, task);
        }

        public void Remove(string id) => _task.DeleteOne(e => e.Id == id);

        public void Remove(Task task) => _task.DeleteOne(e => e.Id == task.Id);

    }
}