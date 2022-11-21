using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkTimer.DataBase
{
    public class IdleInterval
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

        public WorkingHoursState State { get; set; }
    }
}
