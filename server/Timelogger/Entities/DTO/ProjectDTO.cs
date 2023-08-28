using System;
using System.Collections.Generic;
using System.Text;

namespace Timelogger.Entities.DTO
{
    public class ProjectDTO
    {
        public int Id { get; internal set; }
        public string Name  { get; internal set; }
        public string CustomerName { get; internal set; }
        public string UserName { get; internal set; }
        public ProjectSTATUS Status { get; set; } = ProjectSTATUS.ACTIVE;
        public DateTime ProjectStartDate { get; set; } = DateTime.Now;
        public DateTime ProjectEndDate { get; set; }

        //todo add more fields
        public int Tasks { get; internal set; }
    }
}
