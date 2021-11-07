using System;
using System.Collections.Generic;

#nullable disable

namespace Service.DataLayer.ProjectManagementModel
{
    public partial class ProjectPhaseTbl
    {
        public ProjectPhaseTbl()
        {
            ProjectPhaseLevelTbls = new HashSet<ProjectPhaseLevelTbl>();
        }

        public int ProjectPhaseId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectPhaseNameArabic { get; set; }
        public string ProjectPhaseNameEnglish { get; set; }
        public DateTime? ProjectPhaseStartDate { get; set; }
        public DateTime? ProjectPhaseEndDate { get; set; }
        public DateTime? ProjectPhaseCreatedDate { get; set; }
        public DateTime? ProjectPhaseUpdatedDate { get; set; }
        public string ProjectPhaseCreatedBy { get; set; }
        public string ProjectPhaseUpdatedBy { get; set; }

        public virtual ProjectTbl Project { get; set; }
        public virtual ICollection<ProjectPhaseLevelTbl> ProjectPhaseLevelTbls { get; set; }
    }
}
