using Service.DataLayer.ProjectManagementModel;
using Service.DataLayer.ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataLayer.ProjectManagement.Repository
{
    public interface IProjectRepository
    {
        ProjectViewModel AddProject(ProjectViewModel model);
        //IEnumerable<ViewAllViewModel> getAllTraineeAndCourses();

        //TraineeCourseTable AddCourseTable(TraineeTbl trainee, int courseId);

        List<ProjectTbl> GetAllProjects();

        //AddCourseViewModel AddCourse(AddCourseViewModel course);
        ProjectDetailsViewModel GetProjectDetails(int ProjectId);

        PhaseDetailViewModel GetProjectDetailsById(int ProjectId, int PhaseId, int LevelId, int EvalId);

        ProjectTbl DeleteProject(int ProjectId);

        ProjectViewModel getProjectById(int ProjectId);

        bool UpdateProject(ProjectViewModel model);

        bool InsertProjectPhases(int ProjectId, string UserName);

        bool UpdateAllProjectData(PhaseDetailViewModel model);

        List<ProjectDetailsViewModel> GetAllProjectsForReport();


    }
}
