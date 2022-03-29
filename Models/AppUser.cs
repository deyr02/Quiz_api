using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Quiz_api.Models
{
    public class AppUser: IdentityUser<Guid>
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public DateTime DOB {get; set;}

        public ICollection<Attempt> attempts {get; set;}

    }


     public class Role: IdentityRole<Guid>{
        
    }
}