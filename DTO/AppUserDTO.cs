using System;

namespace Quiz_api.DTO
{
    public class AppUserDTO
    {
        public Guid ID {get; set;}
         public string FirstName{get; set;}
        public string LastName { get; set; }
        public string Eamil {get; set;}
        public DateTime  DOB {get; set;}
    }
}