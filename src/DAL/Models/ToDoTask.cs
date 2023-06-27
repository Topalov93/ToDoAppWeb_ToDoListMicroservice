using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ToDoTask
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        public int ToDoListId { get; set; }

        public virtual ToDoList ToDoList { get; set; } = new ToDoList();
    }
}
