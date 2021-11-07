using System;
using System.Collections.Generic;

#nullable disable

namespace Service.DataLayer.ProjectManagementModel
{
    public partial class ProjectPhaseLevelEvalTbl
    {
        public int ProjectPhaseLevelEvalId { get; set; }
        public int ProjectPhaseLevelId { get; set; }
        public int? ProjectPhaseLevelEvaluation { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ProjectPhaseLevelTbl ProjectPhaseLevel { get; set; }
    }
}
