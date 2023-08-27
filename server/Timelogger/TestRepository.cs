using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timelogger.Entities;

namespace Timelogger
{
    public class TestRepository
    {
        private readonly ApiContext _context;
        public TestRepository(ApiContext context)
        {
            _context = context;

        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        internal List<Project> GetAllProjects()
        {
            List<Project> projectList = _context.Projects
               .Include(p => p.Customer)
               .Include(p => p.User)
               .Include(p => p.Tasks).ThenInclude(t => t.Trackings)
               .ToList();

            return projectList;

        }

        internal List<User> GetAllUsers()
        {
            List<User> users = null;
            users = _context.Users.ToList();
            return users;
        }
        internal List<UserTask> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        internal Project LoadProject(int id, int? userId)
        {
            return _context.Projects
                .Include(p => p.Customer)
                .Include(p => p.User)
                .Include(p => p.Tasks).ThenInclude(t => t.Trackings)
                .FirstOrDefault(p => p.Id == id && (userId == null || p.User.UserId == userId));
        }


    }
}
