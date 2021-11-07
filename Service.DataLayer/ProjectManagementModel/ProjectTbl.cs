using System;
using System.Collections.Generic;

#nullable disable

namespace Service.DataLayer.ProjectManagementModel
{
    public partial class ProjectTbl
    {
        public ProjectTbl()
        {
            ProjectPhaseTbls = new HashSet<ProjectPhaseTbl>();
        }

        public int ProjectId { get; set; }
        public string ProjectNameEnglish { get; set; }
        public string ProjectNameArabic { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<ProjectPhaseTbl> ProjectPhaseTbls { get; set; }
    }
}
