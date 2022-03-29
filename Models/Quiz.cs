using System.Collections.Generic;

namespace Quiz_api.Models
{
    public class Quiz
    {
        public long  ID {get; set;}
        public string Question {get; set;}

        public long Answer {get; set;}

        public bool ContiansImage{get; set;}

        public ICollection<AttemptLines> attemptLines {get; set;}

        public ICollection<Option> options {get; set;}
        public ICollection<QuizImage> QuizImages{get; set;}
    }
}