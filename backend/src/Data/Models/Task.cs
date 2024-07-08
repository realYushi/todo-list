using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? TaskId { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = "";
        public DateTime? DueDate { get; set; }

        public enum StatusEnum
        {
            Pending = 1,
            InProgress = 2,
            Completed = 3
        }

        public StatusEnum Status { get; set; } = StatusEnum.Pending;
        public required Guid ListId { get; set; }
        public required Guid UserId { get; set; }
        public virtual List List { get; set; }
        public virtual User User { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}