using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NEMESYS.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the NEMESYSUser class
    public class NEMESYSUser : IdentityUser
    {
        int number = 0;

        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int NumberOfReports
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }
    }
}
