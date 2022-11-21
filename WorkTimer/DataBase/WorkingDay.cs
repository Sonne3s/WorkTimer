using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkTimer.DataBase
{
    public class WorkingDay
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }

        public List<WorkingInterval> Intervals { get; set; }

        public List<IdleInterval> IdleIntervals { get; set; }
    }
}
