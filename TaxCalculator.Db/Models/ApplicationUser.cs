using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Db.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add additional profile data for application users by adding properties to this class
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }

}
