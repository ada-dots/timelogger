using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using Timelogger.Entities.DTO;
using Timelogger.Extensions;

namespace Timelogger.Entities
{

    public enum ProjectSTATUS
    {
        [Description("Active project - work currently in progress")]
        ACTIVE,
        [Description("Closed - no work")]
        CLOSED,
        [Description("Cancelled - no work")]
        CANCELLED
    }

    internal class Project : BaseDocument<ProjectDTO>
    {
        [Key]
        public int Id { get; set; }

        #region references by FK
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int UserId {get;set; }
        public User User { get; set; }
        #endregion

        public string Name { get; set; }
        public ProjectSTATUS Status { get; set; } = ProjectSTATUS.ACTIVE;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public List<UserTask> Tasks { get; set; } = new List<UserTask>();

        internal bool IsOpen()
        {
            return Status == ProjectSTATUS.ACTIVE && DateTime.Today >= this.StartDate && DateTime.Today <= this.EndDate;
        }

        internal override ProjectDTO AsDTO()
        {
            return new ProjectDTO()
            {
                Id = Id,
                CustomerName = Customer.CustomerName,
                Name = Name,
                ProjectEndDate = EndDate,
                ProjectStartDate = StartDate,
                Status = Status,
                Tasks = Tasks.Count,
                UserName = User.Name
            };
        }
    }
}
