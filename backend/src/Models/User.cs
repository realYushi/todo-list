using ToDoListAPI.Models.Generated;
namespace ToDoListAPI.Models
{
    public class User : Generated.User
    {

        // Navigation property for lists owned by the user
        public virtual required ICollection<List> Lists { get; set; }

    }
}
