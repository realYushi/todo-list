using ToDoListAPI.Models.Generated;
namespace ToDoListAPI.Models
{
    public class List : Generated.List
    {

        // Navigation properties
        public virtual User User { get; set; }
        public virtual ICollection<Models.Task> Tasks { get; set; }

    }
}
