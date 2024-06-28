using ToDoListAPI.Models.Generated;
namespace ToDoListAPI.Models
{
    public class List : Generated.List
    {

        // Navigation properties
        public virtual required User User { get; set; }
        public virtual required ICollection<Models.Task> Tasks { get; set; }

    }
}
