using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestDTO
{
    public class ToDoTaskRequestDTO
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        public int ToDoListId { get; set; }
    }
}
