using Service.DataLayer.ProjectManagementModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataLayer.ProjectManagement.ViewModels
{
    public class ReportDetailViewModel
    {
        // ProjectTbl 
        public int? ProjectId { get; set; }
        //[Required(ErrorMessage = "إسم المشروع عربي حقل إجباري")]
        [Display(Name = "إسم المشروع انجليزي")]
        public string ProjectNameEnglish { get; set; }
        [Display(Name = "إسم المشروع عربي *")]
        public string ProjectNameArabic { get; set; }
        [Display(Name = "تاريخ الانشاء")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "تاريخ التعديل")]
        public DateTime? UpdatedDate { get; set; }
        [Display(Name = " انشئ بواسطة")]
        public string CreatedBy { get; set; }
        [Display(Name = "تعديل بواسطة")]
        public string UpdatedBy { get; set; }


        //ProjectPhaseTbl
        public int? ProjectPhaseId { get; set; }
        //public int? ProjectIdFk { get; set; }
        [Display(Name = "اسم المرحلة عربي")]
        public string ProjectPhaseNameArabic { get; set; }
        [Display(Name = "اسم المرحلة انجليزي")]
        public string ProjectPhaseNameEnglish { get; set; }
        [Display(Name = "تاريخ البداية")]
        public DateTime? ProjectPhaseStartDate { get; set; }
        [Display(Name = "تاريخ النهاية")]
        public DateTime? ProjectPhaseEndDate { get; set; }
        [Display(Name = "تاريخ الانشاء")]
        public DateTime? ProjectPhaseCreatedDate { get; set; }
        [Display(Name = "تاريخ التعديل")]
        public DateTime? ProjectPhaseUpdatedDate { get; set; }
        [Display(Name = " انشئ بواسطة")]
        public string ProjectPhaseCreatedBy { get; set; }
        [Display(Name = "تعديل بواسطة")]
        public string ProjectPhaseUpdatedBy { get; set; }


        //ProjectPhaseLevelTbl
        public int? ProjectPhaseLevelId { get; set; }
        //public int ProjectPhaseIdFk { get; set; }
        [Display(Name = "اسم المرحلة عربي")]
        public string ProjectPhaseLevelNameArabic { get; set; }
        [Display(Name = "اسم المرحلة انجليزي")]
        public string ProjectPhaseLevelNameEnglish { get; set; }
        [Display(Name = "تاريخ البداية")]
        public DateTime? ProjectPhaseLevelStartDate { get; set; }
        [Display(Name = "تاريخ النهاية")]
        public DateTime? ProjectPhaseLevelEndDate { get; set; }
        [Display(Name = "تاريخ الانشاء")]
        public DateTime? ProjectPhaseLeveCreatedDate { get; set; }
        [Display(Name = "تاريخ التعديل")]
        public DateTime? ProjectPhaseLeveUpdatedDate { get; set; }
        [Display(Name = " انشئ بواسطة")]
        public string ProjectPhaseLeveCreatedBy { get; set; }
        [Display(Name = "تعديل بواسطة")]
        public string ProjectPhaseLeveUpdatedBy { get; set; }

        //ProjectPhaseLevelEvalTbl
        public int ProjectPhaseLevelEvalId { get; set; }
        //public int ProjectPhaseLevelIdFk { get; set; }
        [Display(Name = "التقييم للمرحلة")]
        public int? ProjectPhaseLevelEvaluation { get; set; }
        [Display(Name = "تاريخ الانشاء")]
        public DateTime? ProjectPhaseLevelEvaCreatedDate { get; set; }
        [Display(Name = "تاريخ التعديل")]
        public DateTime? ProjectPhaseLevelEvaUpdatedDate { get; set; }
        [Display(Name = " انشئ بواسطة")]
        public string ProjectPhaseLevelEvaCreatedBy { get; set; }
        [Display(Name = "تعديل بواسطة")]
        public string ProjectPhaseLevelEvaUpdatedBy { get; set; }
    }
}
