using System.ComponentModel.DataAnnotations;

namespace Models.ResponseDTO
{
    public class ToDoTaskResponseDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        public int ToDoListId { get; set; }
    }
}
