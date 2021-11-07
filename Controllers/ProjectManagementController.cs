using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.DataLayer.ProjectManagement.Repository;
using Service.DataLayer.ProjectManagement.ViewModels;
using Service.DataLayer.ProjectManagementModel;
using Service.DataLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class ProjectManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IProjectRepository _projectRepository;

        public ProjectManagementController(UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          RoleManager<IdentityRole> roleManager,
          IProjectRepository _projectRepository)

        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this._projectRepository = _projectRepository;
        }
        /// <summary>
        /// Get All Projects
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var projects = _projectRepository.GetAllProjects();
            return View(projects);
        }

        /// <summary>
        /// Add New Project
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProject(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedBy = HttpContext.User.Identity.Name;
                ProjectViewModel result = _projectRepository.AddProject(model);

                return RedirectToAction("Index");

            }

            return View(model);
        }


        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        public IActionResult UpdateProject(int ProjectId)
        {
            var UserId = userManager.GetUserId(HttpContext.User);

            //ViewBag.ListofCourses = traineeRepository.GetAllCourses();

            var ProjectModel = _projectRepository.getProjectById(ProjectId);

            return View(ProjectModel);
        }


        [HttpPost]
        public IActionResult UpdateProject(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UpdatedDate = DateTime.Now;
                model.UpdatedBy = HttpContext.User.Identity.Name;

                var UpdateProject = _projectRepository.UpdateProject(model);

                if (UpdateProject == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "حدث خطأ فضلا تواصل مع مدير النظام");

                    //ViewBag.ListofCourses = traineeRepository.GetAllCourses();
                    return View(model);
                }

            }

            ModelState.AddModelError("", "فضلا اكمل ادخال البيانات المطلوبة");

            //ViewBag.ListofCourses = traineeRepository.GetAllCourses();
            return View(model);
        }

        /// <summary>
        /// Review All Project Data
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        public IActionResult ReviewProject(int ProjectId)
        {
            var UserId = userManager.GetUserId(HttpContext.User);            

            var ProjectModel = _projectRepository.GetProjectDetails(ProjectId);

            return View(ProjectModel);
        }

        /// <summary>
        /// Delete Project
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteProject(int ProjectId)
        {            
            var model = _projectRepository.DeleteProject(ProjectId);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Review All Project Data
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        public IActionResult InsertProjectPhases(int ProjectId)
        {
            var UserName = HttpContext.User.Identity.Name;

            var ProjectModel = _projectRepository.InsertProjectPhases(ProjectId, UserName);

            return RedirectToAction("ReviewProject", new { ProjectId = ProjectId });
        }

        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        public IActionResult EditPhaseAndLevel(int ProjectId, int PhaseId, int LevelId, int EvalId)
        {
            //var UserId = userManager.GetUserId(HttpContext.User);

            //ViewBag.ListofCourses = traineeRepository.GetAllCourses();

            var ProjectModel = _projectRepository.GetProjectDetailsById(ProjectId, PhaseId, LevelId, EvalId);

            return View(ProjectModel);
        }


        [HttpPost]
        public IActionResult EditPhaseAndLevel(PhaseDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var UserName = HttpContext.User.Identity.Name;
                model.UpdatedBy = UserName;
                model.ProjectPhaseUpdatedBy = UserName;
                model.ProjectPhaseLeveUpdatedBy = UserName;
                model.ProjectPhaseLevelEvaUpdatedBy = UserName;

                var UpdateProject = _projectRepository.UpdateAllProjectData(model);

                if (UpdateProject == true)
                {
                    return RedirectToAction("ReviewProject", new { ProjectId = model.ProjectId });
                }
                else
                {
                    ModelState.AddModelError("", "حدث خطأ فضلا تواصل مع مدير النظام");

                    return View(model);
                }

            }

            ModelState.AddModelError("", "فضلا اكمل ادخال البيانات المطلوبة");

            //ViewBag.ListofCourses = traineeRepository.GetAllCourses();
            return View(model);
        }
    }
}
