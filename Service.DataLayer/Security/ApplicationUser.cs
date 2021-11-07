using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataLayer.Security
{
    public class ApplicationUser : IdentityUser
    {
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        //public string Email { get; set; }
    }
}
