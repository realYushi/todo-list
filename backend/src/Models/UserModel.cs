using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class UserModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }

        public ICollection<ListModel> Lists { get; set; }
    }
}
