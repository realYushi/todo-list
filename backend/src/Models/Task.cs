using ToDoListAPI.Models.Generated;
namespace ToDoListAPI.Models
{
    public class Task : Generated.Task
    {

        // Navigation properties
        // Existing properties...


        // Navigation property
        public virtual List List { get; set; }

    }
}
