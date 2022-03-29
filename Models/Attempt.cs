using System;
using System.Collections.Generic;

namespace Quiz_api.Models
{
    public class Attempt
    {
        public long ID {get; set;}
        public bool IsSubmitted {get; set;}
        public int TotalQuestions {get; set;}
        public int TotalCorrectAnswer {get; set;}

        public Guid AppUserId {get; set;}
        public AppUser AppUser {get; set;}

        public ICollection<AttemptLines> Attemptlines {get; set;}
    }
}