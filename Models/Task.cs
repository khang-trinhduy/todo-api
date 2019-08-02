using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace todo_api.Models
{
    public class Task
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public List<Task> Steps { get; set; }

        public Task()
        {
        }

        public void Complete() => IsCompleted = true;
    }
}