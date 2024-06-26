using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Models
{
    public class TaskModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime DueDate { get; set; }

        [Required]
        public string Status { get; set; }

        public string ListId { get; set; }

        [ForeignKey("ListId")]
        public ListModel List { get; set; }
    }
}
