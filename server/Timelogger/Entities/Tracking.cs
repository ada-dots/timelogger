using System;
using System.ComponentModel.DataAnnotations.Schema;
using Timelogger.Entities.DTO;

namespace Timelogger.Entities
{
    internal class Tracking : BaseDocument<TrackingDTO>
    {
        private DateTime _timeTo = DateTime.MinValue;
        private DateTime _timeFrom = DateTime.MinValue;

        public int Id { get; set; }
        public UserTask Task { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        [NotMapped]
        public DateTime TimeFrom { get => _timeFrom; set => _timeFrom = value; }

        [NotMapped]
        public DateTime TimeTo
        {
            get { return _timeTo; }
            set
            {
                if (value > TimeFrom)
                    Duration = (value - TimeFrom).TotalHours;
                else
                    Duration = 0.5;
                _timeTo = value;
            }
        }

        public double Duration { get; set; } = 0.5;

        internal override TrackingDTO AsDTO()
        {
            return new TrackingDTO()
            {
                ProjectName = Task.Project.Name,
                Status = Task.Project.Status,
                ProjectStartDate = Task.Project.StartDate,
                ProjectEndDate = Task.Project.EndDate,

                TaskCode = Task.TaskCode,
                TaskName = Task.TaskName,
                Default = Task.Default,
                HourlyRate = Task.HourlyRate,
                OverTimeRate = Task.OverTimeRate,

                Id = Id,
                Note = Note,
                Date = Date,

                Duration = Duration

            };
        }

    }
}
