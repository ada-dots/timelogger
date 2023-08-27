using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using Timelogger.Engine;
using Timelogger.Entities;
using Timelogger.Entities.DTO;
using Timelogger.Extensions;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ApiContext _context;
        private const int CURRENT_USER_ID = 1;
        //private readonly ITestRepository _repository;
        private readonly ProjectManager _projectManager;
        private readonly UUserManager _userManager;

        //public ProjectsController(ApiContext context)
        //{
        //    _context = context;

        //}

        public ProjectsController(ApiContext context)
        {
            _context = context;
            _projectManager = new ProjectManager(context);
            _userManager = new UUserManager(context);
        }


        //// Typed lambda expression for Select() method. 
        //private static readonly Expression<Func<Project, Project>> AsBookDto =
        //    x => new BookDto
        //    {
        //        Title = x.Title,
        //        Author = x.Author.Name,
        //        Genre = x.Genre
        //    };

        [HttpGet]
        [Route("hello-world")]
        public string HelloWorld()
        {
            return "Hello Back!";
        }

        // GET api/projects
        [HttpGet]
        public ActionResult<List<ProjectDTO>> GetAllProjects()
        {
            if (!ValidateUserInformation())
                return Unauthorized();

            var projects = _projectManager.GetAllProjects();
            if (!projects.Any())
                return NotFound();
            return projects;
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDTO> GetProjectInfo(int id)
        {
            if (!ValidateUserInformation())
                return Unauthorized();

            var prj = _projectManager.GetProject(id);
            if (prj == null)
                return NotFound();
            return prj;
        }

        [HttpGet("{id}/work")]
        public ActionResult<List<TrackingDTO>> GetWorkReport(int id)
        {
            if (!ValidateUserInformation())
                return Unauthorized();

            var report = _projectManager.GetWorkReport(id, CURRENT_USER_ID);
            if (report == null)
                return NotFound();
            return report;
        }

        [HttpPost("{id}/work")]
        public ActionResult WorkOnDefaultTask(int id, double duration)
        {
            if (!ValidateUserInformation())
                return Unauthorized();

            if (!_projectManager.TryAddWork(id, CURRENT_USER_ID, duration))
                return UnprocessableEntity();

            return Ok();
        }

        #region private functions
        //mocking for always user 1 to be retrieved
        private bool ValidateUserInformation()
        {
            return _userManager.ExistUser(CURRENT_USER_ID);
        }
        #endregion
    }
}
