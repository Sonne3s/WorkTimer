using Microsoft.EntityFrameworkCore;

namespace WorkTimer.DataBase
{
    public class Repository : IRepository
    {
        public List<WorkingTask> GetTasks()
        {
            using (var db = new Context())
            {
                return db.WorkingTasks.ToList();
            }
        }

        public WorkingTask GetTask(Guid id)
        {
            using (var db = new Context())
            {
                return db.WorkingTasks.FirstOrDefault(t => t.Id == id);
            }
        }

        public WorkingTask CreateTask(string name)
        {
            using (var db = new Context())
            {
                var task = new WorkingTask()
                {
                    Name = name,
                };
                db.WorkingTasks.Add(task);
                db.SaveChanges();

                return task;
            }
        }

        public WorkingTask? UpdateTask(Guid id, string name, int priority, string description)
        {
            using (var db = new Context())
            {
                var task = db.WorkingTasks.FirstOrDefault(t => t.Id == id);
                if(task != null)
                {
                    try
                    {
                        task.Name = name;
                        task.Description = description;
                        task.Priority = (Priority)priority;
                        db.WorkingTasks.Update(task);
                        db.SaveChanges();

                        return task;
                    }
                    catch
                    {
                        throw;
                    }
                }

                return null;
            }
        }

        public WorkingDay? GetLastDay()
        {
            try
            {
                using (var db = new Context())
                {
                    return db.WorkingDays.Include(d => d.Intervals).OrderByDescending(d => d.Number).FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }
        }

        public WorkingDay CreateDay()
        {
            try
            {
                using (var db = new Context())
                {
                    var day = new WorkingDay();
                    db.WorkingDays.Add(day);
                    db.SaveChanges();

                    return day;
                }
            }
            catch
            {
                throw;
            }
        }
        public WorkingInterval CreateWorkingInterval(WorkingDay day)
        {
            try
            {
                using (var db = new Context())
                {
                    var hour = new WorkingInterval
                    {
                        WorkingDayId = day.Id,
                        StartTime = DateTime.Now
                    };
                    db.WorkingIntervals.Add(hour);
                    db.SaveChanges();

                    return hour;
                }
            }
            catch
            {
                throw;
            }
        }

        public IdleInterval CreateIdleInterval(WorkingDay day)
        {
            try
            {
                using (var db = new Context())
                {
                    var hour = new IdleInterval
                    {
                        WorkingDayId = day.Id,
                        StartTime = DateTime.Now
                    };
                    db.IdleIntervals.Add(hour);
                    db.SaveChanges();

                    return hour;
                }
            }
            catch
            {
                throw;
            }
        }

        public WorkingInterval UpdateIntervalEndTime()
        {
            try
            {
                using (var db = new Context())
                {
                    var hour = db.WorkingIntervals.OrderByDescending(i => i.Number).FirstOrDefault();
                    hour.EndTime = DateTime.Now;
                    db.WorkingIntervals.Update(hour);
                    db.SaveChanges();

                    return hour;
                }
            }
            catch
            {
                throw;
            }
        }

        public IdleInterval UpdateIdleIntervalEndTime()
        {
            try
            {
                using (var db = new Context())
                {
                    var hour = db.IdleIntervals.OrderByDescending(i => i.Number).FirstOrDefault();
                    hour.EndTime = DateTime.Now;
                    db.IdleIntervals.Update(hour);
                    db.SaveChanges();

                    return hour;
                }
            }
            catch
            {
                throw;
            }
        }

        public long GetWorkingIntervalsMillisecondsByWorkingDay()
        {
            try
            {
                using (var db = new Context())
                {
                    var day = db.WorkingDays.OrderByDescending(d => d.Number).Select(d => d.Id).LastOrDefault();

                    return (long)db.WorkingIntervals
                        .Where(i => i.WorkingDayId == day && i.EndTime != null)
                        .Select(i => i.EndTime - i.StartTime).ToList().Sum(i => i.Value.TotalMilliseconds);
                }
            }
            catch
            {
                throw;
            }
        }

        public List<WorkingDay> GetWorkingDays()
        {
            try
            {
                using (var db = new Context())
                {
                    return db.WorkingDays.Include(d => d.Intervals).OrderByDescending(d => d.Number).ToList();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
