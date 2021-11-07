using Service.DataLayer.ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DataLayer.ProjectManagementModel;
using Service.DataLayer.ProjectManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Service.DataLayer.Constants;

namespace Service.DataLayer.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly EvaluationDBContext context;

        public ProjectRepository(EvaluationDBContext context)
        {
            this.context = context;
        }

        public ProjectViewModel AddProject(ProjectViewModel model)
        {
            try
            {
                ProjectTbl project = null;                

                if (model != null)
                {
                    project = new ProjectTbl();

                    project.ProjectNameEnglish = model.ProjectNameEnglish;
                    project.ProjectNameArabic = model.ProjectNameArabic;
                    project.CreatedDate = DateTime.Now;
                    project.CreatedBy = model.CreatedBy;
                    

                    //Add new project record to Db
                    context.ProjectTbls.Add(project);
                    context.SaveChanges();
                }

                return model;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public ProjectTbl DeleteProject(int ProjectId)
        {
            //delete Trainee course table if trainee has course 
            //if (TraineeTrsId.ToString() != null)
            //{
            //    TraineeCourseTable traineeCourse = context.TraineeCourseTables.Find(TraineeTrsId);
            //    if (traineeCourse != null)
            //    {
            //        context.TraineeCourseTables.Remove(traineeCourse);
            //        context.SaveChanges();
            //    }
            //}
            ProjectTbl project = context.ProjectTbls.Find(ProjectId);
            if (project != null)
            {
                context.ProjectTbls.Remove(project);
                context.SaveChanges();
            }
            return project;
        }

        public List<ProjectTbl> GetAllProjects()
        {
            return context.ProjectTbls.ToList();
        }

        public ProjectViewModel getProjectById(int ProjectId)
        {
            ProjectViewModel viewModel = null;

           var model = context.ProjectTbls.Where(p => p.ProjectId == ProjectId).FirstOrDefault();
            if (model != null)
            {
                viewModel = new ProjectViewModel();

                viewModel.ProjectId = model.ProjectId;
                viewModel.ProjectNameArabic = model.ProjectNameArabic;
                viewModel.ProjectNameEnglish = model.ProjectNameEnglish;
                viewModel.CreatedDate = model.CreatedDate;
                viewModel.UpdatedDate = model.UpdatedDate;
                viewModel.CreatedBy = model.CreatedBy;
                viewModel.UpdatedBy = model.UpdatedBy;
            }
            return viewModel;
        }

        public ProjectDetailsViewModel GetProjectDetails(int ProjectId)
        {
            try
            {
                ProjectDetailsViewModel DetailModel = null;

                var resultCheckPhases = context.ProjectPhaseTbls.Where(p => p.ProjectId == ProjectId).ToList();

                if (resultCheckPhases.Count > 0)
                {
                    var result = (from p in context.ProjectTbls
                                  join ph in context.ProjectPhaseTbls on p.ProjectId equals ph.ProjectId
                                  join pl in context.ProjectPhaseLevelTbls on ph.ProjectPhaseId equals pl.ProjectPhaseId
                                  join pe in context.ProjectPhaseLevelEvalTbls on pl.ProjectPhaseLevelId equals pe.ProjectPhaseLevelId
                                  where p.ProjectId == ProjectId
                                  select new { p, ph, pl, pe }).ToList();

                    if (result.Count > 0)
                    {
                        DetailModel = new ProjectDetailsViewModel();

                        DetailModel.ProjectPhase = new List<ProjectPhaseTbl>();
                        DetailModel.ProjectPhaseLevel = new List<ProjectPhaseLevelTbl>();
                        DetailModel.ProjectPhaseLevelEval = new List<ProjectPhaseLevelEvalTbl>();

                        DetailModel.Project = (ProjectTbl)result[0].p;
                        //foreach (var item in result[0].ph)
                        //{

                        //}
                        DetailModel.ProjectPhase.Add(result[0].ph);
                        DetailModel.ProjectPhaseLevel.Add(result[0].pl);
                        DetailModel.ProjectPhaseLevelEval.Add(result[0].pe);

                    }


                }
                else
                {
                    var resultGetProject = context.ProjectTbls.Where(p => p.ProjectId == ProjectId).SingleOrDefault();
                    if (resultGetProject != null)
                    {
                        DetailModel = new ProjectDetailsViewModel();

                        DetailModel.Project = (ProjectTbl)resultGetProject;
                    }
                }

                return DetailModel;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public bool InsertProjectPhases(int ProjectId, string UserName)
        {
            try
            {
                ProjectPhaseTbl projectPhases = null;
                //ProjectPhaseLevelTbl projectPhasesLevel = new ProjectPhaseLevelTbl();
                //ProjectPhaseLevelEvalTbl projectPhasesLevelEval = new ProjectPhaseLevelEvalTbl();

                //Insert Phases
                DbConstants.Params PhasesObj = new DbConstants.Params();

                var getPhasesArabic = PhasesObj.getPhasesList();
                var getPhasesEnglish = PhasesObj.getPhasesListEnglish();

                for (int i = 0; i < getPhasesArabic.Count; i++)
                {
                    projectPhases = new ProjectPhaseTbl();
                    projectPhases.ProjectId = ProjectId;
                    projectPhases.ProjectPhaseNameArabic = getPhasesArabic[i];
                    projectPhases.ProjectPhaseNameEnglish = getPhasesEnglish[i];
                    projectPhases.ProjectPhaseCreatedDate = DateTime.Now;
                    projectPhases.ProjectPhaseCreatedBy = UserName;

                    //Add new project record to Db
                    context.ProjectPhaseTbls.Add(projectPhases);
                    context.SaveChanges();
                }

                //get phaceLevel
                var getPhasesForInsertLevel = context.ProjectPhaseTbls.Where(p => p.ProjectId == ProjectId).ToList();

                if (getPhasesForInsertLevel.Count > 0)
                {
                    foreach (var item in getPhasesForInsertLevel)
                    {
                        switch (item.ProjectPhaseNameEnglish)
                        {
                            case "Analysis Phase":
                                Analysis(item, UserName);
                                break;
                            case "Prototype Phase":
                                Prototype(item, UserName);
                                break;
                            case "Sofware Archetucure and DB Design Phase":
                                Archetucure(item, UserName);
                                break;
                            case "Development Phase":
                                Development(item, UserName);
                                break;
                            case "Testing Phase":
                                Testing(item, UserName);
                                break;
                            case "Execution Phase":
                                Execution(item, UserName);
                                break;
                            case "Delivery Phase":
                                Delivery(item, UserName);
                                break;
                            default:
                                break;
                        }
                    }
                }

                //get phaceLevelEval
                var getPhaseLevel = context.ProjectPhaseTbls.Where(p => p.ProjectId == ProjectId).ToList();

                foreach (var item in getPhaseLevel)
                {
                    var getPhasesLevelEvalForInserttion = context.ProjectPhaseLevelTbls.Where(p => p.ProjectPhaseId == item.ProjectPhaseId).ToList();

                    foreach (var level in getPhasesLevelEvalForInserttion)
                    {
                        ProjectPhaseLevelEvalTbl projectPhaseLevelEval = new ProjectPhaseLevelEvalTbl();

                        projectPhaseLevelEval.ProjectPhaseLevelId = level.ProjectPhaseLevelId;
                        projectPhaseLevelEval.ProjectPhaseLevelEvaluation = 0;
                        projectPhaseLevelEval.CreatedDate = DateTime.Now;
                        projectPhaseLevelEval.CreatedBy = UserName;

                        //Add new project record to Db
                        context.ProjectPhaseLevelEvalTbls.Add(projectPhaseLevelEval);
                        context.SaveChanges();
                    }
                }                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool UpdateProject(ProjectViewModel model)
        {
            try
            {
                ProjectTbl project = null;
                //TraineeCourseTable traineecourseTbl = null;

                if (model != null)
                {

                    project = new ProjectTbl();

                    project.ProjectId = (int)model.ProjectId;
                    project.ProjectNameEnglish = model.ProjectNameEnglish;
                    project.ProjectNameArabic = model.ProjectNameArabic;
                    project.CreatedDate = model.CreatedDate;
                    project.UpdatedDate = DateTime.Now;
                    project.CreatedBy = model.CreatedBy;
                    project.UpdatedBy = model.UpdatedBy;

                    var UpdateProject = context.ProjectTbls.Attach(project);

                    UpdateProject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();

                    //if (model.TraineeTrsId.ToString() != null)
                    //{
                    //    traineecourseTbl = new TraineeCourseTable()
                    //    {
                    //        TraineeTrsId = (int)model.TraineeTrsId,
                    //        TraineeId = (int)model.TraineeIdCourseLink,
                    //        CourseId = (int)model.CourseId
                    //    };

                    //var UpdateCourseTrainee = context.TraineeCourseTables.Attach(traineecourseTbl);

                    //UpdateCourseTrainee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    //context.SaveChanges();

                    return true;
                }

                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Analysis (ProjectPhaseTbl phaseTbl, string UserName) 
        {
            ProjectPhaseLevelTbl projectPhasesLevel = null;

            DbConstants.Params PhasesObj = new DbConstants.Params();

            var getAnalysisPhasesLevelAr = PhasesObj.getAnalysisListAr();
            var getAnalysisPhasesLeveEn = PhasesObj.getAnalysisListEn();

            for (int i = 0; i < getAnalysisPhasesLevelAr.Count; i++)
            {
                projectPhasesLevel = new ProjectPhaseLevelTbl();

                projectPhasesLevel.ProjectPhaseId = phaseTbl.ProjectPhaseId;
                projectPhasesLevel.ProjectPhaseLevelNameArabic = getAnalysisPhasesLevelAr[i];
                projectPhasesLevel.ProjectPhaseLevelNameEnglish = getAnalysisPhasesLeveEn[i];
                projectPhasesLevel.CreatedDate = DateTime.Now;
                projectPhasesLevel.CreatedBy = UserName;

                //Add new project record to Db
                context.ProjectPhaseLevelTbls.Add(projectPhasesLevel);
                context.SaveChanges();
            }
        }

        public void Prototype(ProjectPhaseTbl phaseTbl, string UserName)
        {
            ProjectPhaseLevelTbl projectPhasesLevel = new ProjectPhaseLevelTbl();

                projectPhasesLevel.ProjectPhaseId = phaseTbl.ProjectPhaseId;
                projectPhasesLevel.ProjectPhaseLevelNameArabic = DbConstants.Params.PARAM_PrototypeAr;
                projectPhasesLevel.ProjectPhaseLevelNameEnglish = DbConstants.Params.PARAM_PrototypeEn;
                projectPhasesLevel.CreatedDate = DateTime.Now;
                projectPhasesLevel.CreatedBy = UserName;

                //Add new project record to Db
                context.ProjectPhaseLevelTbls.Add(projectPhasesLevel);
                context.SaveChanges();
            
        }

        public void Archetucure(ProjectPhaseTbl phaseTbl, string UserName)
        {
            ProjectPhaseLevelTbl projectPhasesLevel = null;

            DbConstants.Params PhasesObj = new DbConstants.Params();

            var getArchetucurePhasesLevelAr = PhasesObj.getArchetucureListAr();
            var getArchetucurePhasesLeveEn = PhasesObj.getArchetucureListEn();

            for (int i = 0; i < getArchetucurePhasesLevelAr.Count; i++)
            {
                projectPhasesLevel = new ProjectPhaseLevelTbl();

                projectPhasesLevel.ProjectPhaseId = phaseTbl.ProjectPhaseId;
                projectPhasesLevel.ProjectPhaseLevelNameArabic = getArchetucurePhasesLevelAr[i];
                projectPhasesLevel.ProjectPhaseLevelNameEnglish = getArchetucurePhasesLeveEn[i];
                projectPhasesLevel.CreatedDate = DateTime.Now;
                projectPhasesLevel.CreatedBy = UserName;

                //Add new project record to Db
                context.ProjectPhaseLevelTbls.Add(projectPhasesLevel);
                context.SaveChanges();
            }
        }

        public void Development(ProjectPhaseTbl phaseTbl, string UserName)
        {
            ProjectPhaseLevelTbl projectPhasesLevel = null;

            DbConstants.Params PhasesObj = new DbConstants.Params();

            var getDevelopmentPhasesLevelAr = PhasesObj.getDevelopmentListAr();
            var getDevelopmentPhasesLeveEn = PhasesObj.getDevelopmentListEn();

            for (int i = 0; i < getDevelopmentPhasesLevelAr.Count; i++)
            {
                projectPhasesLevel = new ProjectPhaseLevelTbl();
                projectPhasesLevel.ProjectPhaseId = phaseTbl.ProjectPhaseId;
                projectPhasesLevel.ProjectPhaseLevelNameArabic = getDevelopmentPhasesLevelAr[i];
                projectPhasesLevel.ProjectPhaseLevelNameEnglish = getDevelopmentPhasesLeveEn[i];
                projectPhasesLevel.CreatedDate = DateTime.Now;
                projectPhasesLevel.CreatedBy = UserName;

                //Add new project record to Db
                context.ProjectPhaseLevelTbls.Add(projectPhasesLevel);
                context.SaveChanges();
            }
        }

        public void Testing(ProjectPhaseTbl phaseTbl, string UserName)
        {
            ProjectPhaseLevelTbl projectPhasesLevel = null;

            DbConstants.Params PhasesObj = new DbConstants.Params();

            var getTestingPhasesLevelAr = PhasesObj.getTestingListAr();
            var getTestingPhasesLeveEn = PhasesObj.getTestingListEn();

            for (int i = 0; i < getTestingPhasesLevelAr.Count; i++)
            {
                projectPhasesLevel = new ProjectPhaseLevelTbl();
                projectPhasesLevel.ProjectPhaseId = phaseTbl.ProjectPhaseId;
                projectPhasesLevel.ProjectPhaseLevelNameArabic = getTestingPhasesLevelAr[i];
                projectPhasesLevel.ProjectPhaseLevelNameEnglish = getTestingPhasesLeveEn[i];
                projectPhasesLevel.CreatedDate = DateTime.Now;
                projectPhasesLevel.CreatedBy = UserName;

                //Add new project record to Db
                context.ProjectPhaseLevelTbls.Add(projectPhasesLevel);
                context.SaveChanges();
            }
        }

        public void Execution(ProjectPhaseTbl phaseTbl, string UserName)
        {
            ProjectPhaseLevelTbl projectPhasesLevel = new ProjectPhaseLevelTbl();

            projectPhasesLevel.ProjectPhaseId = phaseTbl.ProjectPhaseId;
            projectPhasesLevel.ProjectPhaseLevelNameArabic = DbConstants.Params.PARAM_ExecutionAr;
            projectPhasesLevel.ProjectPhaseLevelNameEnglish = DbConstants.Params.PARAM_ExecutionEn;
            projectPhasesLevel.CreatedDate = DateTime.Now;
            projectPhasesLevel.CreatedBy = UserName;

            //Add new project record to Db
            context.ProjectPhaseLevelTbls.Add(projectPhasesLevel);
            context.SaveChanges();

        }

        public void Delivery(ProjectPhaseTbl phaseTbl, string UserName)
        {
            ProjectPhaseLevelTbl projectPhasesLevel = new ProjectPhaseLevelTbl();

            projectPhasesLevel.ProjectPhaseId = phaseTbl.ProjectPhaseId;
            projectPhasesLevel.ProjectPhaseLevelNameArabic = DbConstants.Params.PARAM_DeliveryAr;
            projectPhasesLevel.ProjectPhaseLevelNameEnglish = DbConstants.Params.PARAM_DeliveryEn;
            projectPhasesLevel.CreatedDate = DateTime.Now;
            projectPhasesLevel.CreatedBy = UserName;

            //Add new project record to Db
            context.ProjectPhaseLevelTbls.Add(projectPhasesLevel);
            context.SaveChanges();

        }

        public PhaseDetailViewModel GetProjectDetailsById(int ProjectId, int PhaseId, int LevelId, int EvalId)
        {
            try
            {
                PhaseDetailViewModel PhaseDetailModel = null;

                var ProjectDetails = context.ProjectTbls.Where(p => p.ProjectId == ProjectId).ToList();

                var ProjectPhaseDetails = context.ProjectPhaseTbls.Where(p => p.ProjectPhaseId == PhaseId).ToList();

                var ProjectPhaseLevelDetails = context.ProjectPhaseLevelTbls.Where(p => p.ProjectPhaseLevelId == LevelId).ToList();

                var ProjectPhaseLevelEvalDetails = context.ProjectPhaseLevelEvalTbls.Where(p => p.ProjectPhaseLevelEvalId == EvalId).ToList();

                if (ProjectDetails.Count > 0)
                {
                    PhaseDetailModel = new PhaseDetailViewModel();

                    //project Info
                    PhaseDetailModel.ProjectId = ProjectDetails[0].ProjectId;
                    PhaseDetailModel.ProjectNameArabic = ProjectDetails[0].ProjectNameArabic;
                    PhaseDetailModel.ProjectNameEnglish = ProjectDetails[0].ProjectNameEnglish;
                    PhaseDetailModel.CreatedDate = ProjectDetails[0].CreatedDate;
                    PhaseDetailModel.UpdatedDate = ProjectDetails[0].UpdatedDate;
                    PhaseDetailModel.CreatedBy = ProjectDetails[0].CreatedBy;
                    PhaseDetailModel.UpdatedBy = ProjectDetails[0].UpdatedBy;


                    //project phase Info
                    PhaseDetailModel.ProjectPhaseId = ProjectPhaseDetails[0].ProjectPhaseId;
                    PhaseDetailModel.ProjectPhaseNameArabic = ProjectPhaseDetails[0].ProjectPhaseNameArabic;
                    PhaseDetailModel.ProjectPhaseNameEnglish = ProjectPhaseDetails[0].ProjectPhaseNameEnglish;
                    PhaseDetailModel.ProjectPhaseStartDate = ProjectPhaseDetails[0].ProjectPhaseStartDate;
                    PhaseDetailModel.ProjectPhaseEndDate = ProjectPhaseDetails[0].ProjectPhaseEndDate;
                    PhaseDetailModel.ProjectPhaseCreatedDate = ProjectPhaseDetails[0].ProjectPhaseCreatedDate;
                    PhaseDetailModel.ProjectPhaseUpdatedDate = ProjectPhaseDetails[0].ProjectPhaseUpdatedDate;
                    PhaseDetailModel.ProjectPhaseCreatedBy = ProjectPhaseDetails[0].ProjectPhaseCreatedBy;
                    PhaseDetailModel.ProjectPhaseUpdatedBy = ProjectPhaseDetails[0].ProjectPhaseUpdatedBy;

                    //project phase Level
                    PhaseDetailModel.ProjectPhaseLevelId = ProjectPhaseLevelDetails[0].ProjectPhaseLevelId;
                    PhaseDetailModel.ProjectPhaseLevelNameArabic = ProjectPhaseLevelDetails[0].ProjectPhaseLevelNameArabic;
                    PhaseDetailModel.ProjectPhaseLevelNameEnglish = ProjectPhaseLevelDetails[0].ProjectPhaseLevelNameEnglish;
                    PhaseDetailModel.ProjectPhaseLevelStartDate = ProjectPhaseLevelDetails[0].ProjectPhaseLevelStartDate;
                    PhaseDetailModel.ProjectPhaseLevelEndDate = ProjectPhaseLevelDetails[0].ProjectPhaseLevelEndDate;
                    PhaseDetailModel.ProjectPhaseLeveCreatedDate = ProjectPhaseLevelDetails[0].CreatedDate;
                    PhaseDetailModel.ProjectPhaseLeveUpdatedDate = ProjectPhaseLevelDetails[0].UpdatedDate;
                    PhaseDetailModel.ProjectPhaseLeveCreatedBy = ProjectPhaseLevelDetails[0].CreatedBy;
                    PhaseDetailModel.ProjectPhaseLeveUpdatedBy = ProjectPhaseLevelDetails[0].UpdatedBy;

                    //project phase Level Eval
                    PhaseDetailModel.ProjectPhaseLevelEvalId = ProjectPhaseLevelEvalDetails[0].ProjectPhaseLevelEvalId;
                    PhaseDetailModel.ProjectPhaseLevelEvaluation = ProjectPhaseLevelEvalDetails[0].ProjectPhaseLevelEvaluation;
                    PhaseDetailModel.ProjectPhaseLevelEvaCreatedDate = ProjectPhaseLevelEvalDetails[0].CreatedDate;
                    PhaseDetailModel.ProjectPhaseLevelEvaUpdatedDate = ProjectPhaseLevelEvalDetails[0].UpdatedDate;
                    PhaseDetailModel.ProjectPhaseLevelEvaCreatedBy = ProjectPhaseLevelEvalDetails[0].CreatedBy;
                    PhaseDetailModel.ProjectPhaseLevelEvaUpdatedBy = ProjectPhaseLevelEvalDetails[0].UpdatedBy;
                    


                }
                else
                {
                   
                }

                return PhaseDetailModel;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public List<ProjectDetailsViewModel> GetAllProjectsForReport()
        {
            try
            {
               List<ProjectDetailsViewModel> DetailModel = null;

                var result = context.ProjectTbls.ToList();

                int percentage = 0;             

                if (result.Count > 0)
                {
                    DetailModel = new List<ProjectDetailsViewModel>();

                    foreach (var item in result)
                    {
                        percentage = 0;
                        ProjectDetailsViewModel obj = new ProjectDetailsViewModel();
                        obj.ProjectPhase = new List<ProjectPhaseTbl>();
                        obj.ProjectPhaseLevel = new List<ProjectPhaseLevelTbl>();
                        obj.ProjectPhaseLevelEval = new List<ProjectPhaseLevelEvalTbl>();

                        obj.Project = item;

                        var resultPhase = context.ProjectPhaseTbls.Where(p => p.ProjectId == item.ProjectId).ToList();
                        foreach (var phasee in resultPhase)
                        {
                            obj.ProjectPhase.Add(phasee);

                            var resultPhaseLevel = context.ProjectPhaseLevelTbls.Where(p => p.ProjectPhaseId == phasee.ProjectPhaseId).ToList();
                            foreach (var levell in resultPhaseLevel)
                            {
                                obj.ProjectPhaseLevel.Add(levell);

                                var resultPhaseLevelEval = context.ProjectPhaseLevelEvalTbls.Where(p => p.ProjectPhaseLevelId == levell.ProjectPhaseLevelId).ToList();
                                foreach (var eval in resultPhaseLevelEval)
                                {
                                    obj.ProjectPhaseLevelEval.Add(eval);
                                    percentage = percentage + (int) eval.ProjectPhaseLevelEvaluation;
                                }
                            }
                        }
                        obj.Percentage = percentage;
                        DetailModel.Add(obj);

                    }
                }
                return DetailModel;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public bool UpdateAllProjectData(PhaseDetailViewModel model)
        {
            try
            {
                ProjectUpdate(model);

                ProjectPhaseUpdate(model);

                ProjectPhaseLevelUpdate(model);

                ProjectPhaseLevelEvalUpdate(model);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void ProjectUpdate(PhaseDetailViewModel model)
        {
            ProjectTbl project = null;

            if (model != null)
            {

                project = new ProjectTbl();

                project.ProjectId = (int)model.ProjectId;
                project.ProjectNameEnglish = model.ProjectNameEnglish;
                project.ProjectNameArabic = model.ProjectNameArabic;
                project.CreatedDate = model.CreatedDate;
                project.UpdatedDate = DateTime.Now;
                project.CreatedBy = model.CreatedBy;
                project.UpdatedBy = model.UpdatedBy;

                var UpdateProject = context.ProjectTbls.Attach(project);

                UpdateProject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();                
            }            
        }

        private void ProjectPhaseUpdate(PhaseDetailViewModel model)
        {
            ProjectPhaseTbl project = null;

            if (model != null)
            {

                project = new ProjectPhaseTbl();

                project.ProjectPhaseId = (int)model.ProjectPhaseId;
                project.ProjectId = (int)model.ProjectId;
                project.ProjectPhaseNameArabic = model.ProjectPhaseNameArabic;
                project.ProjectPhaseNameEnglish = model.ProjectPhaseNameEnglish;
                project.ProjectPhaseStartDate = model.ProjectPhaseStartDate;
                project.ProjectPhaseEndDate = model.ProjectPhaseEndDate;
                project.ProjectPhaseCreatedDate = model.ProjectPhaseCreatedDate;
                project.ProjectPhaseUpdatedDate = DateTime.Now;
                project.ProjectPhaseCreatedBy = model.ProjectPhaseCreatedBy;
                project.ProjectPhaseUpdatedBy = model.ProjectPhaseUpdatedBy;

                var UpdateProject = context.ProjectPhaseTbls.Attach(project);

                UpdateProject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();                
            }            
        }

        private void ProjectPhaseLevelUpdate(PhaseDetailViewModel model)
        {
            ProjectPhaseLevelTbl project = null;

            if (model != null)
            {

                project = new ProjectPhaseLevelTbl();

                project.ProjectPhaseLevelId = (int)model.ProjectPhaseLevelId;
                project.ProjectPhaseId = (int)model.ProjectPhaseId;                
                project.ProjectPhaseLevelNameArabic = model.ProjectPhaseLevelNameArabic;
                project.ProjectPhaseLevelNameEnglish = model.ProjectPhaseLevelNameEnglish;
                project.ProjectPhaseLevelStartDate = model.ProjectPhaseLevelStartDate;
                project.ProjectPhaseLevelEndDate = model.ProjectPhaseLevelEndDate;
                project.CreatedDate = model.ProjectPhaseLeveCreatedDate;
                project.UpdatedDate = DateTime.Now;
                project.CreatedBy = model.ProjectPhaseLeveCreatedBy;
                project.UpdatedBy = model.ProjectPhaseLeveUpdatedBy;

                var UpdateProject = context.ProjectPhaseLevelTbls.Attach(project);

                UpdateProject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        private void ProjectPhaseLevelEvalUpdate(PhaseDetailViewModel model)
        {
            ProjectPhaseLevelEvalTbl project = null;

            if (model != null)
            {

                project = new ProjectPhaseLevelEvalTbl();

                project.ProjectPhaseLevelEvalId = (int)model.ProjectPhaseLevelEvalId;
                project.ProjectPhaseLevelId = (int)model.ProjectPhaseLevelId;
                project.ProjectPhaseLevelEvaluation = model.ProjectPhaseLevelEvaluation;
                project.CreatedDate = model.ProjectPhaseLevelEvaCreatedDate;
                project.UpdatedDate = DateTime.Now;
                project.CreatedBy = model.ProjectPhaseLevelEvaCreatedBy;
                project.UpdatedBy = model.ProjectPhaseLevelEvaUpdatedBy;

                var UpdateProject = context.ProjectPhaseLevelEvalTbls.Attach(project);

                UpdateProject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
