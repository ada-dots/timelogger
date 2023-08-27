using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Timelogger.Entities.DTO
{
    public class TrackingDTO
    {
        public string ProjectName { get; internal set; }
        public ProjectSTATUS Status { get; set; } = ProjectSTATUS.ACTIVE;
        public DateTime ProjectStartDate { get; set; } = DateTime.Now;
        public DateTime ProjectEndDate { get; set; }

        public string TaskCode { get; internal set; }
        public string TaskName { get; internal set; }
        public bool Default { get; internal set; }

       
        public decimal HourlyRate { get; internal set; }
        public decimal OverTimeRate { get; internal set; }

        public int Id { get; internal set; }
        public string Note { get; internal set; }
        public DateTime Date { get; internal set; }

        //todo add time from and time to
        public double Duration { get; internal set; } 
    }
}
