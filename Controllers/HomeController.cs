using ProjectManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Service.DataLayer.ProjectManagement.Repository;

namespace ProjectManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectRepository _projectRepository;

        public HomeController(ILogger<HomeController> logger, IProjectRepository _projectRepository)
        {
            _logger = logger;
            this._projectRepository = _projectRepository;
        }

        //[AllowAnonymous]
        public IActionResult Index()
        {
            var ProjectModel = _projectRepository.GetAllProjectsForReport();
            

            int notFinishProjects = 0;
            int FinishProjects = 0;
            foreach (var item in ProjectModel)
            {
                if (item.Percentage < 100)
                {
                    notFinishProjects = notFinishProjects + 1;
                }

                if (item.Percentage == 100)
                {
                    FinishProjects = FinishProjects + 1;
                }
            }

            ViewBag.ProjectsCounts = ProjectModel.Count();
            ViewBag.notFinishProjects = notFinishProjects;
            ViewBag.FinishProjects = FinishProjects;

            return View(ProjectModel);
        }

        //[Authorize]
        //[AllowAnonymous]
        public IActionResult Home() {

            return View();
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
