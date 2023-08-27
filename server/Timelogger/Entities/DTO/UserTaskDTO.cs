using System;
using System.Collections.Generic;
using System.Text;

namespace Timelogger.Entities.DTO
{
    public class UserTaskDTO
    {
        public string TaskCode { get; internal set; }
        public string TaskName { get; internal set; }
        public bool Default { get; internal set; }
        public decimal HourlyRate { get; internal set; }
        public decimal OverTimeRate { get; internal set; }
    }
}
