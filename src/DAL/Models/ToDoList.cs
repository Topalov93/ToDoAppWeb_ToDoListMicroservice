using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ToDoList
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("userId")]
        public int UserId { get; set; }

        [BsonElement("addedOn")]
        public DateTime AddedOn { get; set; }

        [BsonElement("editedOn")]
        public DateTime EditedOn { get; set; }

        [BsonElement("toDoTasks")]
        public virtual ICollection <ToDoTask> ToDoTasks { get; set; } = new List<ToDoTask>();
    }
}
