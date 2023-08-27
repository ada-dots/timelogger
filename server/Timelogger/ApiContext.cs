using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Timelogger.Entities;

namespace Timelogger
{

    public class ApiContext : DbContext
    {
        internal DbSet<Project> Projects { get; set; }
        internal DbSet<User> Users { get; set; }
        internal DbSet<Customer> Customers { get; set; }
        internal DbSet<UserTask> UserTasks { get; set; }
        internal DbSet<Tracking> Trackings { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
         : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("economicDB");

            base.OnConfiguring(optionsBuilder);
        }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(project => project.Status)
                .HasConversion(value => value.ToString(), 
                               value => (ProjectSTATUS)Enum.Parse(typeof(ProjectSTATUS), value));

            base.OnModelCreating(modelBuilder);
        }

        public void InitRepository()
        {
            SeedDatabase();
        }

        #region database seeding
        private void SeedDatabase()
        {
            ApiContext context = this;
            #region users
            var user1 = new User()
            {
                Name = "ALEXANDRA",
                UserId = 1
            };

            var user2 = new User()
            {
                Name = "ANOTHER",
                UserId = 2
            };
            context.Users.AddRange(user1, user2);

            #endregion

            #region customers

            var customer1 = new Customer()
            {
                CustomerInfo = "Customer with one project",
                CustomerName = "OneProject",
                Id = 1,
            };

            var customer2 = new Customer()
            {
                CustomerInfo = "Customer without any project",
                CustomerName = "No Project",
                Id = 2,

            };

            var customer3 = new Customer()
            {
                CustomerInfo = "Customer with multiple projects",
                CustomerName = "Multiple projects",
                Id = 3
            };

            context.Customers.AddRange(customer1, customer2, customer3);
            context.SaveChanges();
            #endregion

            AddProjects(context, user1, customer1);
            AddProjects(context, user1, customer3, 10, 5);
            AddProjects(context, user2, customer1, 100, 4);
            context.SaveChanges();

        }

        private static void AddProjects(ApiContext context, User user, Customer customer, int firstid = 1, int howMany = 1)
        {
            for (int i = 0; i < howMany; i++)
            {
                var project = new Project()
                {
                    //CustomerId = customer.Id,
                    Customer = customer,
                    User = user,
                    Name = $"Project {i + 1} from customer {customer.CustomerName}",
                    Id = firstid + i,
                    EndDate = DateTime.Now.AddMonths(12),
                    StartDate = DateTime.Now.AddYears(-1),
                    Status = ProjectSTATUS.ACTIVE,
                };
                context.Projects.Add(project);
                project.Tasks = CreateAddUserTasks(context, user, project, firstid, i + 1);

            }
        }

        private static List<UserTask> CreateAddUserTasks(ApiContext context, User user, Project project, int firstid = 1, int howMany = 1)
        {
            var userTasks = new List<UserTask>();
            for (int i = 0; i < howMany; i++)
            {
                var task = new UserTask()
                {
                    Project = project,
                    TaskCode = $"TASK|{user.UserId}|{project.Id}|{firstid + i}",
                    TaskName = $"Development task for project {project.Name} assigned to user {user.Name}",
                    HourlyRate = 10,
                    OverTimeRate = 20,
                    Default = (i == 0) // only first added task is default
                };
                context.UserTasks.Add(task);
                task.Trackings = CreateAddTracking(context, task, project, firstid);
                firstid = firstid * 10;
                userTasks.Add(task);

            }
            return userTasks;
        }

        private static List<Tracking> CreateAddTracking(ApiContext context, UserTask task, Project project, int firstid = 1)
        {
            List<Tracking> trackings = new List<Tracking>();
            for (int i = 0; i < 5; i++)
            {
                var today = new Tracking()
                {
                    Id = int.Parse($"{project.Id}{firstid + i}"),
                    Note = "note",
                    Task = task,
                    Date = DateTime.Now,
                    Duration = 0.5 * (i + 1)
                };
                context.Trackings.Add(today);
                trackings.Add(today);
            }
            return trackings;
        }

        #endregion



    }
}
