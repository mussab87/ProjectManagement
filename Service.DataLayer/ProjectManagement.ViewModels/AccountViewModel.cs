using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataLayer.ProjectManagement.ViewModels
{
    public class AccountViewModel
    {                
        [Required(ErrorMessage = "إسم المستخدم حقل إجباري")]
        //[Remote(action: "IsEmailInUse", controller: "Account")]
        public string Username { get; set; }

        [Required(ErrorMessage = "كلمة المرور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [System.ComponentModel.DataAnnotations.Compare("Password",
            ErrorMessage = "كلمة المرور وتأكيد كلمة المرور غير مطابقة")]
        public string ConfirmPassword { get; set; }

        public List<IdentityRole> Roles { get; set; }

    }
}
