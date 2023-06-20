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
        public string Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public int UserId { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime EditedOn { get; set; }

        public virtual ICollection <ToDoTask> ToDoTasks { get; set; }
    }
}
