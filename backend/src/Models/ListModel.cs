using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class ListModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public UserModel User { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
