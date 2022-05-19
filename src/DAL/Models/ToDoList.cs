using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ToDoList
    {
        public List<int> ToDoTasksIds { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime EditedOn { get; set; }
    }
}
