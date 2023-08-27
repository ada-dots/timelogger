using System;
using System.Collections.Generic;
using System.Text;
using Timelogger.Entities;

namespace Timelogger
{
    public interface ITestRepository
    {
        internal List<Project> GetAllProjects();
        internal List<User> GetAllUsers();
        internal List<UserTask> GetAllTasks();
        internal Project LoadProject(int id, int? userId);
        void SaveChanges();
    }
}
