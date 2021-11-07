using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataLayer.ProjectManagement.ViewModels
{
    public class ProjectViewModel
    {
        public int? ProjectId { get; set; }
        [Display(Name = "إسم المشروع انجليزي")]
        public string ProjectNameEnglish { get; set; }

        [Required(ErrorMessage = "إسم المشروع عربي حقل إجباري")]
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
    }
}
