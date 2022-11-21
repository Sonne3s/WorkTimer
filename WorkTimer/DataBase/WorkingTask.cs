using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkTimer.DataBase
{
    public class WorkingTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }

        public int? ParentTaskId { get; set; }

        public WorkingTask? ParentTask { get; set; }

        public List<WorkingTask> SubTasks { get; set;}

        public string Name { get; set; }

        public string? Description { get; set; }

        public Priority Priority { get; set; } = Priority.Normal;
    }
}
