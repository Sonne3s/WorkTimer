using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkTimer.DataBase
{
    public class WorkingInterval
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }

        public Guid WorkingDayId { get; set; }

        public WorkingDay WorkingDay { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string? Description { get; set; }

        public Guid? TaskId { get; set; }

        public WorkingTask? Task { get; set; }
    }
}
