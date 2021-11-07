using Service.DataLayer.ProjectManagementModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataLayer.ProjectManagement.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectTbl Project { get; set; }
        public List<ProjectPhaseTbl> ProjectPhase { get; set; }
        public List<ProjectPhaseLevelTbl> ProjectPhaseLevel { get; set; }
        public List<ProjectPhaseLevelEvalTbl> ProjectPhaseLevelEval { get; set; }

        public int? Percentage { get; set; }
    }
}
