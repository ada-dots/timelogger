using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;
using Timelogger.Entities.DTO;
using Timelogger.Entities;
using Timelogger.Extensions;
using System.Linq;

namespace Timelogger.Engine
{
    public class ProjectManager : BaseManager
    {
        internal const double MIN_DURATION = 0.5; 

        public ProjectManager(ApiContext context) : base(context)
        {

        }

        public List<ProjectDTO> GetAllProjects(int? userID = null)
        {
            if (userID == null)
                return _repository.GetAllProjects().AsDTO();
            else
                return _repository.GetAllProjects()
                                  .Where(x => x.UserId == userID)
                                  .ToList<Project>()
                                  .AsDTO();
        }

        public ProjectDTO GetProject(int id, int? userId =null)
        {
            var currentProject = _repository.LoadProject(id, userId);

            if (userId != null && currentProject.User.UserId != userId)
                currentProject = null;
            
            return currentProject == null ? null : currentProject.AsDTO(); 
        }

        public List<TrackingDTO> GetWorkReport(int id, int userId)
        {
            var proj = _repository.LoadProject(id, userId);
            var workTracked = new List<Tracking>();

            foreach (var task in proj.Tasks)
            {
                workTracked.AddRange(task.Trackings);
            }

            return workTracked.AsDTO();
        }



        #region engine methods
        public bool TryAddWork(int id, int userId, double duration, string note = null, string taskCode = null)
        {
            bool success = true;
            try
            {
                AddWork(id, userId, duration, note, taskCode);
            }
            catch
            {
                //do something with e
                success = false;
            }
            return success;
        }

        internal void AddWork(int id, int userId, double duration, string note, string taskCode = null)
        {
            if (duration < MIN_DURATION)
                throw new ArgumentOutOfRangeException(nameof(duration));
            var prj = _repository.LoadProject(id, userId);
            if (!prj.IsOpen())
                throw new Exception("Project must be open"); //TOODO define a custom Exception


            var task = prj.Tasks.Find(t => (String.IsNullOrWhiteSpace(taskCode)) ? t.Default : t.TaskCode == taskCode);
            if (task == null)
                throw new ArgumentNullException(nameof(taskCode));

            task.WorkToday(duration, note);

            _repository.SaveChanges();

        }

        #endregion
    }
}
