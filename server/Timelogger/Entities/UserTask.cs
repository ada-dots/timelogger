using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Timelogger.Entities.DTO;

namespace Timelogger.Entities
{
    /// <summary>
    /// List of tasks that can be done by a user for a specific project.
    /// Can be one or many
    /// for example: development, design, support, testing
    /// added separate assignment to support different hourly rate & overtime rate per assignment
    /// </summary>
    internal class UserTask: BaseDocument<UserTaskDTO>
    {
        [Key]
        public string TaskCode { get; set; }
        public bool Default { get; set; } = true;
        public string TaskName { get; set; }
       
        public decimal HourlyRate { get; set; }
        public decimal OverTimeRate { get; set; }


        public List<Tracking> Trackings { get; set; }
        public Project Project { get; set; }

        internal void WorkToday(double duration, string note = null)
        {
            Trackings.Add(new Tracking()
            {
                Date = DateTime.Now,
                Duration = duration,
                Note = note,
                Task = this
            });
        }

        internal override UserTaskDTO AsDTO()
        {
            return new UserTaskDTO()
            {
                TaskCode = TaskCode,
                TaskName = TaskName,
                Default = Default,
                HourlyRate = HourlyRate,
                OverTimeRate = OverTimeRate
            };
        }
    }
}