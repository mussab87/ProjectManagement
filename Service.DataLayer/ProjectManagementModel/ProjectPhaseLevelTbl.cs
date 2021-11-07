using System;
using System.Collections.Generic;

#nullable disable

namespace Service.DataLayer.ProjectManagementModel
{
    public partial class ProjectPhaseLevelTbl
    {
        public ProjectPhaseLevelTbl()
        {
            ProjectPhaseLevelEvalTbls = new HashSet<ProjectPhaseLevelEvalTbl>();
        }

        public int ProjectPhaseLevelId { get; set; }
        public int ProjectPhaseId { get; set; }
        public string ProjectPhaseLevelNameArabic { get; set; }
        public string ProjectPhaseLevelNameEnglish { get; set; }
        public DateTime? ProjectPhaseLevelStartDate { get; set; }
        public DateTime? ProjectPhaseLevelEndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ProjectPhaseTbl ProjectPhase { get; set; }
        public virtual ICollection<ProjectPhaseLevelEvalTbl> ProjectPhaseLevelEvalTbls { get; set; }
    }
}
